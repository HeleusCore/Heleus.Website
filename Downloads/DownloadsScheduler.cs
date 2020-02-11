using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Heleus.Website.Downloads
{
    public static class DownloadsScheduler
    {
        static readonly object _lock = new object();

        static DirectoryInfo _downloadsPath;
        static DownloadList _downloads = new DownloadList();

        static DateTime _lastRefresh;
        static bool _forceRefresh;

        static readonly TimeSpan _refreshDelay = TimeSpan.FromHours(1);
        static readonly TimeSpan _forceRefreshDelay = TimeSpan.FromMinutes(1);

        public static DownloadList Downloads
        {
            get
            {
                lock (_lock)
                    return _downloads;
            }
        }

        public static string DownloadPath
        {
            get
            {
                return GetDownloadPath()?.FullName;
            }
        }

        static DirectoryInfo GetDownloadPath()
        {
            lock (_lock)
                return _downloadsPath;
        }

        public static void Start(DirectoryInfo downloadsPath)
        {
            lock (_lock)
            {
                _downloadsPath = downloadsPath;
                _downloads = null;
            }

            ScanDownloads();
            _ = RefreshLoop();
        }

        public static void Stop()
        {
            lock(_lock)
            {
                _downloadsPath = null;
                _downloads = null;
            }
        }

        static async Task RefreshLoop()
        {
            while(true)
            {
                var path = GetDownloadPath();
                if (path == null)
                    break;

                var scan = false;
                lock (_lock)
                {
                    var now = DateTime.UtcNow;
                    if (now > (_lastRefresh + _refreshDelay) || (_forceRefresh && now > (_lastRefresh + _forceRefreshDelay)))
                    {
                        scan = true;
                        _forceRefresh = false;
                    }
                }
                
                if (scan)
                    ScanDownloads();

                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }

        public static string GetFilePath(string filename)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filename))
                {
                    var parts = filename.Split('_');
                    if (parts.Length == 3)
                    {
                        var app = parts[0];
                        var os = parts[1];

                        var items = Downloads?.GetDownloads(app, os);
                        if (items != null)
                        {
                            foreach (var item in items)
                            {
                                if (item.Filename == filename)
                                {
                                    lock (_lock)
                                    {
                                        if (_downloadsPath != null)
                                            return Path.Combine(_downloadsPath.FullName, item.Filename);
                                    }
                                }
                            }
                        }
                    }
                }
            }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
            catch { }
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
            return null;
        }
    
        static void ScanDownloads()
        {
            var path = GetDownloadPath();
            if(path != null)
            {
                var downloads = new DownloadList();
                var files = path.GetFiles();
                foreach(var file in files)
                {
                    try
                    {
                        var parts = Path.GetFileNameWithoutExtension(file.Name).Split('_');
                        if (parts.Length == 3)
                        {
                            var app = parts[0];
                            var os = parts[1];
                            var versionparts = parts[2].Split('.');
                            if (versionparts.Length == 3 && int.TryParse(versionparts[0], out var major) && int.TryParse(versionparts[1], out var minor) && int.TryParse(versionparts[2], out var build))
                            {
                                var version = new Version(major, minor, build);

                                //var verifyFile = file.FullName + ".verifylink.txt";
                                //if (File.Exists(verifyFile))
                                {
                                    //var verifyLink = File.ReadAllText(verifyFile).Trim();
                                    //if (verifyLink.StartsWith("https://heleuscore.com/wallet/action/viewverification/", StringComparison.Ordinal))
                                    {
                                        //var id = verifyLink.Split('/').Last();
                                        //if(long.TryParse(id, out _))
                                            downloads.AddDownload(file.Name, (int)file.Length, app, os, version/*, new Uri(verifyLink)*/);
                                    }
                                }
                            }
                        }
                    }
#pragma warning disable RECS0022 // A catch clause that catches System.Exception and has an empty body
                    catch { }
#pragma warning restore RECS0022 // A catch clause that catches System.Exception and has an empty body
                }

                lock (_lock)
                {
                    _downloads = downloads;
                    _lastRefresh = DateTime.UtcNow;
                }
            }
        }

        public static void ForceRefresh()
        {
            lock (_lock)
                _forceRefresh = true;
        }
    }
}
