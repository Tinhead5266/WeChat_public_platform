using CommonHelp;
using CommonHelp.CommonHelp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace WeChat_public_platform_test
{
    /// <summary>
    /// CheckWeChatPublicPlatform 的摘要说明 微信公众平台验证
    /// </summary>
    public class CheckWeChatPublicPlatform : IHttpHandler
    {

        public void ProcessRequest(HttpContext param_context)
        {
            string postString = string.Empty;
            //用户发送消息或点击等事件一般都是POST过来，微信服务器向接口发送POST请求，根据请求我们进行处理反馈
            if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
            {
                using (Stream stream = HttpContext.Current.Request.InputStream)
                {
                    Byte[] postBytes = new Byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    postString = Encoding.UTF8.GetString(postBytes);
                    Handle(postString);
                    CommonUtility.Logger.Info("微信回发消息（postString）：" + postString);
                }
            }
            else
            {
                //第一次配置接口地址的时候，微信服务器会向接口发送一个GET请求来验证你的接口地址
                //InterfaceTest();

                //验证签名
                if (CheckSignature())
                {
                    HttpContext.Current.Response.Write(HttpContext.Current.Request.QueryString["echoStr"]);
                }
                else
                {
                    HttpContext.Current.Response.Write("error");
                }
            }
        }

        /// <summary>
        /// 检查签名
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool CheckSignature()
        {
            string token = System.Configuration.ConfigurationManager.AppSettings["WeChatToken"];

            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            List<string> list = new List<string>();
            list.Add(token);
            list.Add(timestamp);
            list.Add(nonce);
            //排序
            list.Sort();
            //拼串
            string input = string.Empty;
            foreach (var item in list)
            {
                input += item;
            }
            //加密
            string new_signature = CommonUtility.SHA1Encrypt(input);
            //验证
            if (new_signature == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 处理信息并应答
        /// </summary>
        private void Handle(string postStr)
        {
            MessageHelp help = new MessageHelp();
            string responseContent = help.ReturnMessage(postStr);

            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.Write(responseContent);
        }

        //成为开发者url测试，返回echoStr
        public void InterfaceTest()
        {
            string token = "Tinhead";
            if (string.IsNullOrEmpty(token))
            {
                return;
            }

            //微信服务器会将下面几个参数发送到接口，接口这边返回接收到的echoStr就说明验证通过，
            //主要为了防止别人盗用你的接口，我这边没做逻辑判断直接返回接收到的echoStr来通过验证
            string echoString = HttpContext.Current.Request.QueryString["echoStr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            if (!string.IsNullOrEmpty(echoString))
            {
                HttpContext.Current.Response.Write(echoString);
                HttpContext.Current.Response.End();
            }
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