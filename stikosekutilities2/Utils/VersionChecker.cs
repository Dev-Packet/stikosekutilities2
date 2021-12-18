using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Reflection;

namespace stikosekutilities2.Utils
{
    public static class VersionChecker
    {
        private static readonly bool init;
        public static bool UpdateAvailable;

        static VersionChecker()
        {
            if (!init)
            {
                try
                {
                    using var client = new WebClient();
                    // Some random user agent because with others it responds with 403
                    client.Headers.Add("User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:93.0) Gecko/20100101 Firefox/93.0");

                    string json = client.DownloadString(PluginConstants.ReleasesAPI);

                    JArray jArr = JArray.Parse(json);

                    string stringVersion = jArr[0].ToObject<JObject>().GetValue("tag_name").ToObject<string>();

                    // Compare GitHub and Local Version
                    Version git = new(stringVersion);
                    Version current = Assembly.GetExecutingAssembly().GetName().Version;

                    int result = current.CompareTo(git);

                    if (result < 0)
                    {
                        UpdateAvailable = true;
                    }

                    init = true;
                }
                catch (Exception)
                {
                    Loader.Log.LogWarning("Couldn't fetch updates from GitHub!");
                }
            }
        }

    }
}
