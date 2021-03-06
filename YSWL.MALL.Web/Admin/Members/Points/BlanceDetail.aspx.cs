﻿/**
* PointsDetail.cs
*
* 功 能： [N/A]
* 类 名： PointsDetail
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2012/8/20 14:44:45  Administrator    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：小鸟科技（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using YSWL.Accounts.Bus;
using System.Drawing;
using System.Data;

namespace YSWL.MALL.Web.Admin.Members.Points
{
    public partial class BlanceDetail : PageBaseAdmin
    {
        private User currentUser;
        protected override int Act_PageLoad { get { return 301; } } //用户管理_积分详情页
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if ((Request.Params["userid"] != null) && (Request.Params["userid"].ToString() != ""))
                {
                    if (Common.PageValidate.IsNumber(Request.Params["userid"]))
                    {
                        int userid = int.Parse(Request.Params["userid"]);
                        currentUser = new User(userid);
                        if (currentUser == null)
                        {
                            Response.Write("<script language=javascript>window.alert('" + Resources.Site.TooltipUserExist + "\\');history.back();</script>");
                            return;
                        }
                        this.txtUserName.Text = currentUser.NickName + "的资金明细";

                     
                    }
                }
            }
        }

        #region gridView

        public void BindData()
        {
            if ((Request.Params["userid"] != null) && (Request.Params["userid"].ToString() != ""))
            {
                if (Common.PageValidate.IsNumber(Request.Params["userid"]))
                {
                    int userid = int.Parse(Request.Params["userid"]);

                    DataSet ds = new DataSet();
                    
                    YSWL.MALL.BLL.Pay.BalanceDetails balanceDetBLL = new BLL.Pay.BalanceDetails();
                    //获取资金
                    ds = balanceDetBLL.GetList(" UserId=" + userid + "");

                    if (ds != null)
                    {
                        gridView.DataSetSource = ds;
                    }
                }
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            gridView.OnBind();
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#F4F4F4");
                }
                else
                {
                    e.Row.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#FFFFFF");
                }
            }
        }

        //返回处理
        public void btnReturn_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/Admin/Accounts/Admin/UserAdmin.aspx");
        }
        /// <summary>
        /// 根据积分类型获取积分名字
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string GetRuleName(object rule)
        {
            int ruleId = Common.Globals.SafeInt(rule, 0);
            if (ruleId ==(int)YSWL.MALL.Model.Members.Enum.PointRule.Order)
            {
                return "完成订单";
            }
            YSWL.MALL.BLL.Members.PointsRule RuleBll = new BLL.Members.PointsRule();
            return RuleBll.GetRuleName(ruleId);
        }


        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gridView.OnBind();
        }
    }
}