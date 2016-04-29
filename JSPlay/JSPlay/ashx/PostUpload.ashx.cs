using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace JSPlay.ashx
{
    /// <summary>
    /// PostUpload 的摘要说明
    /// </summary>
    public class PostUpload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string path = context.Request["path"];
            using (WebClient wc = new WebClient())
            {
                wc.UploadFile("http://localhost:26714/ashx/upload.ashx", path);
            }
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}