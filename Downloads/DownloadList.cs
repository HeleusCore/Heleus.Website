using System;
using System.Collections.Generic;
using System.Linq;

namespace Heleus.Website.Downloads
{
    public class DownloadList
    {
        readonly Dictionary<string, Dictionary<string, List<DownloadItem>>> _items = new Dictionary<string, Dictionary<string, List<DownloadItem>>>();

        public void AddDownload(string filename, int size, string app, string os, Version version/*, Uri verifyLink*/)
        {
            var appInfo = AppInfo.GetAppInfo(app);
            if (appInfo == null)
                return;

            os = AppInfo.GetValidOsString(os);
            if (os == null)
                return;

            if (!_items.ContainsKey(appInfo.Name))
            {
                var downloads = new Dictionary<string, List<DownloadItem>>
                {
                    { os, new List<DownloadItem>() }
                };
                _items.Add(appInfo.Name, downloads);
            }

            if (!_items[appInfo.Name].ContainsKey(os))
            {
                _items[appInfo.Name].Add(os, new List<DownloadItem>());
            }

            var list = _items[appInfo.Name][os];
            //list.Add(new DownloadItem(filename, size, version, verifyLink));
            list.Sort((a, b) => a.Version.CompareTo(b.Version) * -1);
        }

        public List<DownloadItem> GetDownloads(string app, string os)
        {
            if (_items.TryGetValue(app, out var appitem))
            {
                if (appitem.TryGetValue(os, out var ositem))
                {
                    return ositem;
                }
            }

            return new List<DownloadItem>();
        }
    }
}
