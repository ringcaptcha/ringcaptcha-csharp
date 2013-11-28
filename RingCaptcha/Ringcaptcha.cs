using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;

namespace RingCaptcha
{
    public class Ringcaptcha
    {
        const string RC_SERVER = "api.ringcaptcha.com";
        const string USER_AGENT = "ringcaptcha-c#/1.0";

        const string SUCCESS = "SUCCESS";
        const string ERROR = "ERROR";
        const string UNDEFINED = "UNDEFINED";


        string version = "1.0";

        bool isSecure;

        string appKey;
        string secretKey;
        int retryAttempts;

        int status;

        public Ringcaptcha(string appKey, string secretKey)
        {
            this.appKey = appKey;
            this.secretKey = secretKey;
            this.retryAttempts = 0;
            this.isSecure = true;
            this.status = -1;
        }

        public class JsonDataClass
        {
            public string status { get; set; }
            public string id { get; set; }
            public string phone { get; set; }
            public bool geolocation { get; set; }
            public string message { get; set; }
            public string phone_type { get; set; }
            public string carrier { get; set; }
            public string device { get; set; }
            public string isp { get; set; }
        }

        public bool isValid(string pinCode, string token)
        {
            var data = new Hashtable {
                { "secret_key" , this.secretKey },
                { "token" , token },
                { "code" , pinCode }
            };

            this.SanitizeData(data);

            var server = string.Format("{0}{1}", this.isSecure ? "https://" : "http://", RC_SERVER);

            var resource = "/" + this.appKey + "/verify";

            var jsonData = default(JsonDataClass);

            try
            {
                var response = this.ringcaptchaVerifyRESTCall(server, resource, data);

                using (var responseStream = response.GetResponseStream())
                {
                    var jsonSerializer = new DataContractJsonSerializer(typeof(JsonDataClass));
                    jsonData = jsonSerializer.ReadObject(responseStream) as JsonDataClass;
                }

                this.status = jsonData.status == SUCCESS ? 1 : 0;
            }
            catch (Exception ex)
            {
                this.status = 0;
                this.Message = ex.Message;
                return false;
            }

            this.Id = jsonData.id;
            this.PhoneNumber = jsonData.phone;
            this.Geolocated = jsonData.geolocation;
            this.Message = jsonData.message;

            this.PhoneType = jsonData.phone_type;
            this.CarrierName = jsonData.carrier;

            this.DeviceName = jsonData.device;
            this.IspName = jsonData.isp;

            return this.status == 1;
        }

        private HttpWebResponse ringcaptchaVerifyRESTCall(string server, string resource, Hashtable data, int port = 80)
        {
            var query = string.Join("&", data.Keys.Cast<string>().Select(key => string.Format("{0}={1}", key, data[key])).ToArray());
            var url = server + (!this.isSecure ? port.ToString() : string.Empty) + resource;

            var request = WebRequest.Create(url) as HttpWebRequest;

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = query.Length;
            request.UserAgent = USER_AGENT;

            using (var writeStream = request.GetRequestStream())
            {
                var encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(query);
                writeStream.Write(bytes, 0, bytes.Length);
            }

            return request.GetResponse() as HttpWebResponse;
        }

        private void SanitizeData(Hashtable data)
        {
            var keys = data.Keys.Cast<string>().ToList();
            foreach (var k in keys)
            {
                data[k] = data[k] != null ? HttpUtility.HtmlEncode(data[k].ToString()).Trim() : string.Empty;
            }
        }

        public void SetSecure(bool secure)
        {
            this.isSecure = secure;
        }

        public string Status
        {
            get
            {
                switch (this.status)
                {
                    case 1:
                        return SUCCESS;
                    case 0:
                        return ERROR;
                    default:
                        return UNDEFINED;
                }
            }
        }

        public string Message { get; private set; }

        public string Id { get; private set; }

        public string PhoneNumber { get; private set; }

        public bool Geolocated { get; private set; }

        public string PhoneType { get; private set; }

        public string CarrierName { get; private set; }

        public string DeviceName { get; private set; }

        public string IspName { get; private set; }
    }
}
