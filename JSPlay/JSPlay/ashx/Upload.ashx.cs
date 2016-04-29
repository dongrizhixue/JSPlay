using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace JSPlay.ashx
{
    /// <summary>
    /// Upload 的摘要说明
    /// </summary>
    public class Upload : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files == null || context.Request.Files.Count == 0)
            {
                ResponseWriteEnd(context, "File is empty");//请选择要上传的文件   
            }
            else
            {
                HttpPostedFile _upfile = context.Request.Files[0];
                if (_upfile == null)
                {
                    ResponseWriteEnd(context, "File not found");//请选择要上传的文件   
                }
                else
                {
                    string fileName = _upfile.FileName;
                    string path = HttpContext.Current.Server.MapPath("~/Voice/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    _upfile.SaveAs(path + fileName);//保存   
                    ResponseWriteEnd(context, "ok  adress " + path + fileName); //上传成功   
                }
            }
        }

        private void ResponseWriteEnd(HttpContext context, string msg)
        {
            context.Response.Write(msg);
            context.Response.End();
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