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

            if (!_items.ContainsKey(appInfo.DownloadName))
            {
                var downloads = new Dictionary<string, List<DownloadItem>>
                {
                    { os, new List<DownloadItem>() }
                };
                _items.Add(appInfo.DownloadName, downloads);
            }

            if (!_items[appInfo.DownloadName].ContainsKey(os))
            {
                _items[appInfo.DownloadName].Add(os, new List<DownloadItem>());
            }

            var list = _items[appInfo.DownloadName][os];
            list.Add(new DownloadItem(filename, size, version/*, verifyLink*/));
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
