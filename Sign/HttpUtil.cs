using System.Net;
using System.Text;

namespace Sign
{
    internal class HttpUtil
    {
        private static CookieContainer m_Cookie = new CookieContainer();
        private static string SPost(string postURL, string postData, Encoding pageEncoding)
        {
            HttpWebRequest httpWebRequest;
            HttpWebResponse httpWebResponse;

            byte[] bytesToPost = pageEncoding.GetBytes(postData);
            try
            {
                httpWebRequest = WebRequest.Create(postURL) as HttpWebRequest;
                httpWebRequest.Method = "POST";
                httpWebRequest.KeepAlive = true;
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.CookieContainer = m_Cookie;//设置上一个访问页面的cookie 保持session
                httpWebRequest.ContentLength = bytesToPost.Length;
                httpWebRequest.Host = "student.wozaixiaoyuan.com";
                httpWebRequest.Referer = "https://servicewechat.com/wxce6d08f781975d91/147/page-frame.html";

                Stream requestStream = httpWebRequest.GetRequestStream();
                requestStream.Write(bytesToPost, 0, bytesToPost.Length);//写入post信息
                requestStream.Close();

                httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
                m_Cookie = httpWebRequest.CookieContainer;//访问后更新cookie
                Stream responseStream = httpWebResponse.GetResponseStream();
                string resData;

                using (StreamReader resSR = new StreamReader(responseStream, pageEncoding))
                {
                    resData = resSR.ReadToEnd();
                    resSR.Close();
                    responseStream.Close();
                }
                return resData;


            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public static string Post(string url, Dictionary<string, string> dic, string usr, string pwd)
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/x-www-form-urlencoded";
            req.Host = "student.wozaixiaoyuan.com";
            // req.Connection = "keep-alive"; // Exception： Keep-Alive and Close may not be set using this property. Arg_ParamName_Name
            //req.ContentLength = 450;
            //req.Referer = "https://servicewechat.com/wxce6d08f781975d91/147/page-frame.html";
            //req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36 MicroMessenger/7.0.9.501 NetType/WIFI MiniProgramEnv/Windows WindowsWechat";
            req.Headers.Add("JWSESSION:" + GetJWSession(usr, pwd));
            //req.Headers.Add("Accept-Encoding:gzip,deflate,br");

            dic.Add("anwsers:", "[\"0\",\"0\",\"1\"]");

            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (var item in dic)
            {
                if (i > 0)
                    builder.Append("&");
                builder.AppendFormat("{0}={1}", item.Key, item.Value);
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            req.ContentLength = data.Length;
            using (Stream reqStream = req.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }

            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream stream = resp.GetResponseStream();

            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        private static string GetJWSession(string usr, string pwd)
        {
            string result = SPost("https://gw.wozaixiaoyuan.com/basicinfo/mobile/login", "?username=" + usr + "&password=" + pwd, Encoding.UTF8);
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://gw.wozaixiaoyuan.com/basicinfo/mobile/login/username");
            //req.Method = "POST";
            //req.ContentType = "application/x-www-form-urlencoded";
            //req.Host = "student.wozaixiaoyuan.com";
            ////// req.Connection = "keep-alive";
            ////req.ContentLength = 450;
            ////req.Referer = "https://servicewechat.com/wxce6d08f781975d91/147/page-frame.html";
            ////req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36 MicroMessenger/7.0.9.501 NetType/WIFI MiniProgramEnv/Windows WindowsWechat";
            ////req.Headers.Add("Accept-Encoding:gzip,deflate,br");
            ////req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9";

            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("username", usr);
            //dic.Add("password", pwd);
            //StringBuilder builder = new StringBuilder();
            //int i = 0;
            //foreach (var item in dic)
            //{
            //    if (i > 0)
            //        builder.Append("&");
            //    builder.AppendFormat("{0}={1}", item.Key, item.Value);
            //    i++;
            //}
            //byte[] data = Encoding.UTF8.GetBytes(builder.ToString());
            //req.ContentLength = data.Length;
            //using (Stream reqStream = req.GetRequestStream())
            //{
            //    reqStream.Write(data, 0, data.Length);
            //    reqStream.Close();
            //}

            //HttpWebResponse resp = (HttpWebResponse)req.GetResponse();

            //result = resp.GetResponseHeader("JWSESSION");
            return result;
        }
    }
}
