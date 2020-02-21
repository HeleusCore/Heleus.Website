using System.Collections.Generic;
using System.Linq;

namespace Heleus.Website
{
    public class AppInfo
    {
        static readonly string[] _availableOs = { "Windows", "Linux", "macOS", "Android", "iOS" };

        public static string Windows => _availableOs[0];
        public static string Linux = _availableOs[1];
        public static string macOS = _availableOs[2];
        public static string Android = _availableOs[3];
        public static string iOS = _availableOs[4];

        public static bool IsValidOs(string os)
        {
            return GetValidOsString(os) != null;
        }

        public static void Init()
        {

        }

        public static string GetValidOsString(string os)
        {
            //os = os.ToLower();
            if (_availableOs.Any((o) => o == os))
                return os;
            return null;
        }

        static readonly Dictionary<string, AppInfo> _appInfos = new Dictionary<string, AppInfo>();

        public static AppInfo GetAppInfo(string app)
        {
            _appInfos.TryGetValue(app, out var appInfo);
            return appInfo;
        }

        public string Fullname { get; private set; }
        public string Name { get; private set; }
        public string DownloadName { get; private set; }
        public string Schema { get; private set; }

        readonly Dictionary<string, string> _storeLinkIds = new Dictionary<string, string>();
        readonly HashSet<string> _requests = new HashSet<string>();

        protected AppInfo(string fullname, string name)
        {
            Fullname = fullname;
            Name = name.ToLower();
            Schema = fullname.ToLower().Replace(" ", "");
            DownloadName = fullname.Replace(" ", "");
            _appInfos[DownloadName] = this;
        }

        protected void AddRequests(params string[] requests)
        {
            foreach (var request in requests)
                _requests.Add(request);
        }

        public bool IsValidRequest(string request)
        {
            if (string.IsNullOrWhiteSpace(request))
                return false;

            return _requests.Contains(request);
        }

        protected void AddStoreLink(string os, string linkId)
        {
            os = GetValidOsString(os);
            _storeLinkIds[os] = linkId;
        }

        public string GetStoreId(string os)
        {
            os = GetValidOsString(os);
            _storeLinkIds.TryGetValue(os, out var linkid);
            return linkid;
        }

        public string GetStoreLink(string os)
        {
            os = GetValidOsString(os);
            if(_storeLinkIds.TryGetValue(os, out var linkid))
            {
                if (os == Windows)
                    return $"https://www.microsoft.com/store/apps/{linkid}";
                else if (os == Android)
                    return $"https://play.google.com/store/apps/details?id={linkid}";
                else if (os == iOS)
                    return $"https://apps.apple.com/app/id{linkid}";
                else if (os == macOS)
                    return $"https://apps.apple.com/app/id{linkid}?mt=12";
            }

            return null;
        }

        public bool HasStoreEntry(string os)
        {
            return GetStoreLink(os) != null;
        }

        public static AppInfo Heleus = new HeleusAppInfo();
        public static AppInfo Verify = new VerifyAppInfo();
        public static AppInfo Note = new NoteAppInfo();
        public static AppInfo Todo = new TodoAppInfo();
        public static AppInfo Status = new StatusAppInfo();
        public static AppInfo Message = new MessageAppInfo();
    }

    public class HeleusAppInfo : AppInfo
    {
        public HeleusAppInfo() : base("Heleus", "heleus")
        {
            //AddStoreLink(Windows, "hohoho");

            AddRequests("transfercoins",
            			"revenue",
                        "authorizeservice",
                        "authorizeservicederived",
                        "authorizepurchase",
                        "viewtransactions",
                        "viewprofile",
                        "editprofile");
        }
    }

    public class VerifyAppInfo : AppInfo
    {
        public VerifyAppInfo() : base("Heleus Verify", "verify")
        {
            AddRequests("addservicenode",
                        "verification");
        }
    }

    public class NoteAppInfo : AppInfo
    {
        public NoteAppInfo() : base("Heleus Note", "note")
        {
            AddRequests("addservicenode");
        }
    }

    public class TodoAppInfo : AppInfo
    {
        public TodoAppInfo() : base("Heleus Todo", "todo")
        {
            AddRequests("addservicenode",
                        "requestinvitation",
                        "invitation");
        }
    }

    public class StatusAppInfo : AppInfo
    {
        public StatusAppInfo() : base("Heleus Status", "status")
        {
            AddRequests("addservicenode",
                        "viewaccount",
                        "viewmessage");
        }
    }

    public class MessageAppInfo : AppInfo
    {
        public MessageAppInfo() : base("Heleus Message", "message")
        {
            AddRequests("addservicenode",
                        "viewchat",
                        "viewfriend");
        }
    }
}
