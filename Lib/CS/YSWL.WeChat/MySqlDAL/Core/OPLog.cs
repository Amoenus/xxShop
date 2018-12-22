﻿/**  版本信息模板在安装目录下，可自行修改。
* OPLog.cs
*
* 功 能： N/A
* 类 名： OPLog
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/1/6 18:34:25   N/A    初版
*
* Copyright (c) 2012 YSWL Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：云商未来（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using YSWL.WeChat.IDAL.Core;
using YSWL.DBUtility;//Please add references
using MySql.Data.MySqlClient;
namespace YSWL.WeChat.MySqlDAL.Core
{
	/// <summary>
	/// 数据访问类:OPLog
	/// </summary>
	public partial class OPLog:IOPLog
	{
		public OPLog()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from WeChat_OPLog");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int64)
			};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public long Add(YSWL.WeChat.Model.Core.OPLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WeChat_OPLog(");
			strSql.Append("UserName,OpenId,Address,Longitude,Latitude,Url,ActionId,OPType,OPTime,Remark)");
			strSql.Append(" values (");
			strSql.Append("?UserName,?OpenId,?Address,?Longitude,?Latitude,?Url,?ActionId,?OPType,?OPTime,?Remark)");
			strSql.Append(";select last_insert_id()");
			MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?OpenId", MySqlDbType.VarChar,200),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?Longitude", MySqlDbType.Float,8),
					new MySqlParameter("?Latitude", MySqlDbType.Float,8),
					new MySqlParameter("?Url", MySqlDbType.VarChar,500),
					new MySqlParameter("?ActionId", MySqlDbType.Int32,4),
					new MySqlParameter("?OPType", MySqlDbType.Int32,4),
					new MySqlParameter("?OPTime", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.OpenId;
			parameters[2].Value = model.Address;
			parameters[3].Value = model.Longitude;
			parameters[4].Value = model.Latitude;
			parameters[5].Value = model.Url;
			parameters[6].Value = model.ActionId;
			parameters[7].Value = model.OPType;
			parameters[8].Value = model.OPTime;
			parameters[9].Value = model.Remark;

			object obj = DbHelperMySQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt64(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.WeChat.Model.Core.OPLog model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WeChat_OPLog set ");
			strSql.Append("UserName=?UserName,");
			strSql.Append("OpenId=?OpenId,");
			strSql.Append("Address=?Address,");
			strSql.Append("Longitude=?Longitude,");
			strSql.Append("Latitude=?Latitude,");
			strSql.Append("Url=?Url,");
			strSql.Append("ActionId=?ActionId,");
			strSql.Append("OPType=?OPType,");
			strSql.Append("OPTime=?OPTime,");
			strSql.Append("Remark=?Remark");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?UserName", MySqlDbType.VarChar,200),
					new MySqlParameter("?OpenId", MySqlDbType.VarChar,200),
					new MySqlParameter("?Address", MySqlDbType.VarChar,200),
					new MySqlParameter("?Longitude", MySqlDbType.Float,8),
					new MySqlParameter("?Latitude", MySqlDbType.Float,8),
					new MySqlParameter("?Url", MySqlDbType.VarChar,500),
					new MySqlParameter("?ActionId", MySqlDbType.Int32,4),
					new MySqlParameter("?OPType", MySqlDbType.Int32,4),
					new MySqlParameter("?OPTime", MySqlDbType.DateTime),
					new MySqlParameter("?Remark", MySqlDbType.VarChar,-1),
					new MySqlParameter("?ID", MySqlDbType.Int64,8)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.OpenId;
			parameters[2].Value = model.Address;
			parameters[3].Value = model.Longitude;
			parameters[4].Value = model.Latitude;
			parameters[5].Value = model.Url;
			parameters[6].Value = model.ActionId;
			parameters[7].Value = model.OPType;
			parameters[8].Value = model.OPTime;
			parameters[9].Value = model.Remark;
			parameters[10].Value = model.ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WeChat_OPLog ");
			strSql.Append(" where ID=?ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int64)
			};
			parameters[0].Value = ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from WeChat_OPLog ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
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
		public YSWL.WeChat.Model.Core.OPLog GetModel(long ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,UserName,OpenId,Address,Longitude,Latitude,Url,ActionId,OPType,OPTime,Remark from WeChat_OPLog ");
            strSql.Append(" where ID=?ID LIMIT 1 ");
			MySqlParameter[] parameters = {
					new MySqlParameter("?ID", MySqlDbType.Int64)
			};
			parameters[0].Value = ID;

			YSWL.WeChat.Model.Core.OPLog model=new YSWL.WeChat.Model.Core.OPLog();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
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
		public YSWL.WeChat.Model.Core.OPLog DataRowToModel(DataRow row)
		{
			YSWL.WeChat.Model.Core.OPLog model=new YSWL.WeChat.Model.Core.OPLog();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=long.Parse(row["ID"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["OpenId"]!=null)
				{
					model.OpenId=row["OpenId"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Longitude"]!=null && row["Longitude"].ToString()!="")
				{
					model.Longitude=decimal.Parse(row["Longitude"].ToString());
				}
				if(row["Latitude"]!=null && row["Latitude"].ToString()!="")
				{
					model.Latitude=decimal.Parse(row["Latitude"].ToString());
				}
				if(row["Url"]!=null)
				{
					model.Url=row["Url"].ToString();
				}
				if(row["ActionId"]!=null && row["ActionId"].ToString()!="")
				{
					model.ActionId=int.Parse(row["ActionId"].ToString());
				}
				if(row["OPType"]!=null && row["OPType"].ToString()!="")
				{
					model.OPType=int.Parse(row["OPType"].ToString());
				}
				if(row["OPTime"]!=null && row["OPTime"].ToString()!="")
				{
					model.OPTime=DateTime.Parse(row["OPTime"].ToString());
				}
				if(row["Remark"]!=null)
				{
					model.Remark=row["Remark"].ToString();
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
			strSql.Append("select ID,UserName,OpenId,Address,Longitude,Latitude,Url,ActionId,OPType,OPTime,Remark ");
			strSql.Append(" FROM WeChat_OPLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			
			strSql.Append(" ID,UserName,OpenId,Address,Longitude,Latitude,Url,ActionId,OPType,OPTime,Remark ");
			strSql.Append(" FROM WeChat_OPLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
            if (Top > 0)
            {
                strSql.Append(" LIMIT " + Top.ToString());
            }
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM WeChat_OPLog ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperMySQL.GetSingle(strSql.ToString());
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT T.* from WeChat_OPLog T ");
            if (!string.IsNullOrWhiteSpace(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrWhiteSpace(orderby.Trim()))
            {
                strSql.Append(" order by T." + orderby);
            }
            else
            {
                strSql.Append(" order by T.ID desc");
            }
            strSql.AppendFormat(" LIMIT {0},{1}", startIndex - 1, endIndex - startIndex + 1);
            return DbHelperMySQL.Query(strSql.ToString());
		}

	


		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}
