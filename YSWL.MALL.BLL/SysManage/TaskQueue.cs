﻿using System;
using System.Data;
using System.Collections.Generic;
using YSWL.Common;
using YSWL.MALL.Model.SysManage;
using YSWL.MALL.DALFactory;
using YSWL.MALL.IDAL.SysManage;
namespace YSWL.MALL.BLL.SysManage
{
	/// <summary>
	/// TaskQueue
	/// </summary>
	public partial class TaskQueue
	{
        private readonly ITaskQueue dal = DASysManage.CreateTaskQueue();
		public TaskQueue()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID,int Type)
		{
			return dal.Exists(ID,Type);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(YSWL.MALL.Model.SysManage.TaskQueue model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(YSWL.MALL.Model.SysManage.TaskQueue model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID,int Type)
		{
			
			return dal.Delete(ID,Type);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public YSWL.MALL.Model.SysManage.TaskQueue GetModel(int ID,int Type)
		{
			
			return dal.GetModel(ID,Type);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public YSWL.MALL.Model.SysManage.TaskQueue GetModelByCache(int ID,int Type)
		{
			
			string CacheKey = "TaskQueueModel-" + ID+Type;
			object objModel = YSWL.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID,Type);
					if (objModel != null)
					{
						 int ModelCache = Globals.SafeInt(BLL.SysManage.ConfigSystem.GetValueByCache("ModelCache"), 30);
						YSWL.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (YSWL.MALL.Model.SysManage.TaskQueue)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YSWL.MALL.Model.SysManage.TaskQueue> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<YSWL.MALL.Model.SysManage.TaskQueue> DataTableToList(DataTable dt)
		{
			List<YSWL.MALL.Model.SysManage.TaskQueue> modelList = new List<YSWL.MALL.Model.SysManage.TaskQueue>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				YSWL.MALL.Model.SysManage.TaskQueue model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
				}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod
        /// <summary>
        /// 删除所有文章任务
        /// </summary>
        public bool DeleteArticle()
        {
            return dal.DeleteArticle();
        }

        public List<YSWL.MALL.Model.SysManage.TaskQueue> GetContinueTask(int type)
        {
            DataSet ds = dal.GetContinueTask(type);
            return DataTableToList(ds.Tables[0]);
        }

        public YSWL.MALL.Model.SysManage.TaskQueue GetLastModel(int type)
        {
            return dal.GetLastModel(type);
        }

        /// <summary>
        /// 删除所有指定类型任务
        /// </summary>
        public bool DeleteTask(int Type)
        {
            return dal.DeleteTask(Type);
        }
		#endregion  ExtensionMethod
	}
}

