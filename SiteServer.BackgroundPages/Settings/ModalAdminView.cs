﻿using System;
using System.Collections.Specialized;
using System.Web.UI.WebControls;
using BaiRong.Core;

namespace SiteServer.BackgroundPages.Settings
{
	public class ModalAdminView : BasePage
    {
        protected Literal LtlUserName;
        protected Literal LtlDisplayName;
        protected Literal LtlCreationDate;
        protected Literal LtlLastActivityDate;
        protected Literal LtlEmail;
        protected Literal LtlMobile;
        protected Literal LtlRoles;

        public static string GetOpenWindowString(string userName)
        {
            return PageUtils.GetOpenLayerString("查看管理员资料", PageUtils.GetSettingsUrl(nameof(ModalAdminView), new NameValueCollection
            {
                {"UserName", userName}
            }), 400, 450);
        }
	
		public void Page_Load(object sender, EventArgs e)
        {
            if (IsForbidden) return;

            var userName = Body.GetQueryString("UserName");
            var adminInfo = BaiRongDataProvider.AdministratorDao.GetByUserName(userName);
            LtlUserName.Text = adminInfo.UserName;
            LtlDisplayName.Text = adminInfo.DisplayName;
            LtlCreationDate.Text = DateUtils.GetDateAndTimeString(adminInfo.CreationDate);
            LtlLastActivityDate.Text = DateUtils.GetDateAndTimeString(adminInfo.LastActivityDate);
            LtlEmail.Text = adminInfo.Email;
            LtlMobile.Text = adminInfo.Mobile;
            LtlRoles.Text = AdminManager.GetRolesHtml(userName);
		}
	}
}
