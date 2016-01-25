using System.IO;
using System.Net;
using System.Text;
using Aton.Core.Library.Rest.Client.Support;

namespace Aton.Core.Library.Rest.Client
{
    public static partial class GenericProxies
    {
        public static ClientConfiguration DefaultConfiguration { get; set; }

        // static Constructtor
        static GenericProxies()
        {
            // Initiate the default configuration
            DefaultConfiguration = new ClientConfiguration();
            DefaultConfiguration.ContentType = "application/json";
            DefaultConfiguration.Accept = "application/json";
            DefaultConfiguration.RequrieSession = false;
            DefaultConfiguration.OutBoundSerializerAdapter = new JavaScriptSerializerAdapter();
            DefaultConfiguration.InBoundSerializerAdapter = new JavaScriptSerializerAdapter();
        }

        // Create a request object according to the configuration
        private static HttpWebRequest CreateRequest(string url,
            ClientConfiguration clientConfig)
        {
            return (clientConfig.RequrieSession) ? CookiedHttpWebRequestFactory.Create(url) :
                (HttpWebRequest)WebRequest.Create(url);
        }

        // Post data to the service
        private static void PostData<T>(HttpWebRequest request,
            ClientConfiguration clientConfig, T data)
        {
            var jsonRequestString = clientConfig.OutBoundSerializerAdapter.Serialize(data);
            var bytes = Encoding.UTF8.GetBytes(jsonRequestString);

            using (var postStream = request.GetRequestStream())
            {
                postStream.Write(bytes, 0, bytes.Length);
            }
        }

        // Receive data from the service
        private static T ReceiveData<T>(HttpWebRequest request,
            ClientConfiguration clientConfig)
        {
            string jsonResponseString;
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var stream = response.GetResponseStream();
                if (stream == null) { return default(T); }
                using (var streamReader = new StreamReader(stream))
                {
                    jsonResponseString = streamReader.ReadToEnd();
                }
            }

            return clientConfig.InBoundSerializerAdapter.Deserialize<T>(jsonResponseString);
        }
    }
}
