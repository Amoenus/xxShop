﻿using System;
using System.Data;
namespace YSWL.MALL.IDAL.Members
{
	/// <summary>
	/// 接口层UserRank
	/// </summary>
	public interface IUserRank
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int RankId);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(YSWL.MALL.Model.Members.UserRank model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		bool Update(YSWL.MALL.Model.Members.UserRank model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		bool Delete(int RankId);
		bool DeleteList(string RankIdlist );
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		YSWL.MALL.Model.Members.UserRank GetModel(int RankId);
		YSWL.MALL.Model.Members.UserRank DataRowToModel(DataRow row);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		int GetRecordCount(string strWhere);
		DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
		#region  MethodEx
        string GetUserLevel(int grades);

	    /// <summary>
	    /// 获得会员等级数据
	    /// </summary>
	    /// <param name="ruleId">批发规则Id</param>
	    /// <returns></returns>
	    DataSet GetList(int ruleId);

	    #endregion  MethodEx
	} 
}