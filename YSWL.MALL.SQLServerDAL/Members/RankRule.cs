﻿/**  版本信息模板在安装目录下，可自行修改。
* RankRule.cs
*
* 功 能： N/A
* 类 名： RankRule
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/17 16:54:41   N/A    初版
*
* Copyright (c) 2012 YS56 Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.MALL.IDAL.Members;
using YSWL.DBUtility;//Please add references
namespace YSWL.MALL.SQLServerDAL.Members
{
	/// <summary>
	/// 数据访问类:RankRule
	/// </summary>
	public partial class RankRule:IRankRule
	{
		public RankRule()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DBHelper.DefaultDBHelper.GetMaxID("RuleId", "Accounts_RankRule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int RuleId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Accounts_RankRule");
			strSql.Append(" where RuleId=@RuleId");
			SqlParameter[] parameters = {
					new SqlParameter("@RuleId", SqlDbType.Int,4)
			};
			parameters[0].Value = RuleId;

			return DBHelper.DefaultDBHelper.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(YSWL.MALL.Model.Members.RankRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Accounts_RankRule(");
			strSql.Append("ActionId,LimitID,Name,Score,Description,TargetId,TargetType)");
			strSql.Append(" values (");
			strSql.Append("@ActionId,@LimitID,@Name,@Score,@Description,@TargetId,@TargetType)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ActionId", SqlDbType.Int,4),
					new SqlParameter("@LimitID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,-1),
					new SqlParameter("@TargetId", SqlDbType.Int,4),
					new SqlParameter("@TargetType", SqlDbType.Int,4)};
			parameters[0].Value = model.ActionId;
			parameters[1].Value = model.LimitID;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Score;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.TargetId;
			parameters[6].Value = model.TargetType;

			object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.MALL.Model.Members.RankRule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Accounts_RankRule set ");
			strSql.Append("ActionId=@ActionId,");
			strSql.Append("LimitID=@LimitID,");
			strSql.Append("Name=@Name,");
			strSql.Append("Score=@Score,");
			strSql.Append("Description=@Description,");
			strSql.Append("TargetId=@TargetId,");
			strSql.Append("TargetType=@TargetType");
			strSql.Append(" where RuleId=@RuleId");
			SqlParameter[] parameters = {
					new SqlParameter("@ActionId", SqlDbType.Int,4),
					new SqlParameter("@LimitID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Score", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,-1),
					new SqlParameter("@TargetId", SqlDbType.Int,4),
					new SqlParameter("@TargetType", SqlDbType.Int,4),
					new SqlParameter("@RuleId", SqlDbType.Int,4)};
			parameters[0].Value = model.ActionId;
			parameters[1].Value = model.LimitID;
			parameters[2].Value = model.Name;
			parameters[3].Value = model.Score;
			parameters[4].Value = model.Description;
			parameters[5].Value = model.TargetId;
			parameters[6].Value = model.TargetType;
			parameters[7].Value = model.RuleId;

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RuleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Accounts_RankRule ");
			strSql.Append(" where RuleId=@RuleId");
			SqlParameter[] parameters = {
					new SqlParameter("@RuleId", SqlDbType.Int,4)
			};
			parameters[0].Value = RuleId;

			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string RuleIdlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Accounts_RankRule ");
			strSql.Append(" where RuleId in ("+RuleIdlist + ")  ");
			int rows=DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YSWL.MALL.Model.Members.RankRule GetModel(int RuleId)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RuleId,ActionId,LimitID,Name,Score,Description,TargetId,TargetType from Accounts_RankRule ");
			strSql.Append(" where RuleId=@RuleId");
			SqlParameter[] parameters = {
					new SqlParameter("@RuleId", SqlDbType.Int,4)
			};
			parameters[0].Value = RuleId;

			YSWL.MALL.Model.Members.RankRule model=new YSWL.MALL.Model.Members.RankRule();
			DataSet ds=DBHelper.DefaultDBHelper.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YSWL.MALL.Model.Members.RankRule DataRowToModel(DataRow row)
		{
			YSWL.MALL.Model.Members.RankRule model=new YSWL.MALL.Model.Members.RankRule();
			if (row != null)
			{
				if(row["RuleId"]!=null && row["RuleId"].ToString()!="")
				{
					model.RuleId=int.Parse(row["RuleId"].ToString());
				}
				if(row["ActionId"]!=null && row["ActionId"].ToString()!="")
				{
					model.ActionId=int.Parse(row["ActionId"].ToString());
				}
				if(row["LimitID"]!=null && row["LimitID"].ToString()!="")
				{
					model.LimitID=int.Parse(row["LimitID"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=int.Parse(row["Score"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["TargetId"]!=null && row["TargetId"].ToString()!="")
				{
					model.TargetId=int.Parse(row["TargetId"].ToString());
				}
				if(row["TargetType"]!=null && row["TargetType"].ToString()!="")
				{
					model.TargetType=int.Parse(row["TargetType"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RuleId,ActionId,LimitID,Name,Score,Description,TargetId,TargetType ");
			strSql.Append(" FROM Accounts_RankRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" RuleId,ActionId,LimitID,Name,Score,Description,TargetId,TargetType ");
			strSql.Append(" FROM Accounts_RankRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Accounts_RankRule ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.RuleId desc");
			}
			strSql.Append(")AS Row, T.*  from Accounts_RankRule T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DBHelper.DefaultDBHelper.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Accounts_RankRule";
			parameters[1].Value = "RuleId";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DBHelper.DefaultDBHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
        #region 扩展方法
        public string GetRuleName(int ruleid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT Name  ");
            strSql.Append("FROM Accounts_RankRule ");
            strSql.AppendFormat("WHERE RuleId={0}", ruleid);
            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString());

            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public YSWL.MALL.Model.Members.RankRule GetModel(int ActionId, int TargetId, int TargetType)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Accounts_RankRule ");
            strSql.Append(" where ActionId=@ActionId  and  TargetId=@TargetId and TargetType=@TargetType");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionId", SqlDbType.Int,4),
                    new SqlParameter("@TargetId", SqlDbType.Int,4),
                    new SqlParameter("@TargetType", SqlDbType.Int,4)
			};
            parameters[0].Value = ActionId;
            parameters[1].Value = TargetId;
            parameters[2].Value = TargetType;

            YSWL.MALL.Model.Members.RankRule model = new YSWL.MALL.Model.Members.RankRule();
            DataSet ds = DBHelper.DefaultDBHelper.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public bool Exists(int ActionId, int targetId, int targetType)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_RankRule");
            strSql.Append(" where ActionId=@ActionId and TargetId=@TargetId and TargetType=@TargetType");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionId", SqlDbType.Int,4),
                    new SqlParameter("@TargetId", SqlDbType.Int,4),
                    new SqlParameter("@TargetType", SqlDbType.Int,4)
			};
            parameters[0].Value = ActionId;
            parameters[1].Value = targetId;
            parameters[2].Value = targetType;

            return DBHelper.DefaultDBHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该规则码
        /// </summary>
        public bool ExistsActionId(int ActionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_RankRule");
            strSql.Append(" where ActionId=@ActionId");
            SqlParameter[] parameters = {
					new SqlParameter("@ActionId", SqlDbType.Int,4)
			};
            parameters[0].Value = ActionId;

            return DBHelper.DefaultDBHelper.Exists(strSql.ToString(), parameters);
        }
        #endregion
	}
}

