using System;

namespace Heleus.Website.Downloads
{
    public class DownloadItem
    {
        public readonly string Filename;
        public readonly Version Version;
        //public readonly Uri VerifyLink;
        public readonly int Size;

        public DownloadItem(string filename, int size, Version version/*, Uri verifyLink*/)
        {
            Filename = filename;
            Size = size;
            Version = version;
            //VerifyLink = verifyLink;
        }
    }
}
