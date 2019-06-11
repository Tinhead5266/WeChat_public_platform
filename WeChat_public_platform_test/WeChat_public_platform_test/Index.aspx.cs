using CommonHelp.CommonHelp;
using CommonHelp.WeChatCommonHelp;
using System;

namespace WeChat_public_platform_test
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////第一次载入的时候，生成一个初始的标志    
            //if (null == Session["Token"])
            //{
            //    SetToken();
            //}
        }

        #region MyRegion

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    if (Request.Form.Get("hiddenTestN").Equals(GetToken()))
        //    {
        //        lblMessage.ForeColor = System.Drawing.Color.Blue;
        //        lblMessage.Text = "正常提交表单"; SetToken();
        //        //别忘了最后要更新Session中的标志   
        //    }
        //    else
        //    {
        //        lblMessage.ForeColor = System.Drawing.Color.Red;
        //        lblMessage.Text = "刷新提交表单";
        //    }
        //}

        ////获得当前Session里保存的标志  
        //public string GetToken()
        //{
        //    if (null != Session["Token"])
        //    {
        //        return Session["Token"].ToString();
        //    }
        //    else { return string.Empty; }
        //}

        ////生成标志，并保存到Session 
        //private void SetToken()
        //{
        //    Session.Add("Token", UserMd5(Session.SessionID + DateTime.Now.Ticks.ToString()));
        //}

        ////这个函数纯粹是为了让标志稍微短点儿，一堆乱码还特有神秘感，另外，这个UserMd5函数是网上找来的现成儿的   
        //protected string UserMd5(string str1)
        //{
        //    string cl1 = str1; string pwd = ""; MD5 md5 = MD5.Create();
        //    // 加密后是一个字节类型的数组     
        //    byte[] s = md5.ComputeHash(Encoding.Unicode.GetBytes(cl1));
        //    // 通过使用循环，将字节类型的数组转换为字符串，此字符串 是常规字符格式化所得  
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        // 将得到的字符串使用十六进制类型格式。格式后的字符是 小写的字母，如果使用大写（X）则格式后的字符是大写字符 
        //        pwd = pwd + s[i].ToString("X");
        //    }
        //    return pwd;
        //} 
        #endregion

        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnGetToken_Click(object sender, EventArgs e)
        {
            tbToken.Text = AccessTokenHelp.AccessToken;
        }

        /// <summary>
        /// 发送模板消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSendTemplateMessage_Click(object sender, EventArgs e)
        {
            var data = new
            {
                first = new
                {
                    value = "恭喜你购买成功",
                    color = "#173177"
                }
            };
            string templateId = tbTemplateId.Text;
            TemplateMessage.SendTemplate("oj0gV1QPEHwE7bbAUeTGB9J5RSNw", templateId, data);
        }

        /// <summary>
        /// 创建自定义菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnCreateMenu_Click(object sender, EventArgs e)
        {
            var createMenJsonStr = tbCreateMenuJson.Text;
            if (string.IsNullOrWhiteSpace(createMenJsonStr))
            {
                return;
            }
            CommonUtility.Logger.Info("创建自定义菜单Json:" + createMenJsonStr);
            MenuHelp.CreateMenu(JsonUtility.FromJsonTo<object>(createMenJsonStr));
        }

        /// <summary>
        /// 获取所有素材
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btGetAllBatchgetMaterial_Click(object sender, EventArgs e)
        {
            tbAllBatchgetMaterialJson.Text = BatchgetMaterialHelp.GetBatchgetMaterialsByType();

        }
    }
}