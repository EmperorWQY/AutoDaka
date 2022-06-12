using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sign
{
    internal class SignInfo
    {
        public string JWSESSION { get; set; }
        public string url { get; set; } = "https://student.wozaixiaoyuan.com/health/save.json";
        public string token { get; set; }
        public Dictionary<string,string> data { get; set; } = new Dictionary<string, string>();
        public SignInfo(string jWSESSION, string url, string token, Dictionary<string, string> data)
        {
            JWSESSION = jWSESSION;
            this.url = url;
            this.token = token;
            this.data = data;
        }
    }
}
