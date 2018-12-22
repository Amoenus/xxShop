using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using YSWL.Accounts.IData;
using YSWL.DBUtility;

namespace YSWL.Accounts.Data
{
    /// <summary>
    /// ��ɫ����
    /// </summary>    
    public class Role : IRole
    {
        //public Role(string newConnectionString) 
        //{ }

        public Role()
        { }

        /// <summary>
        /// �Ƿ���ڸý�ɫ
        /// </summary>
        public bool RoleExists(string Description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Accounts_Roles");
            strSql.Append(" where Description=@Description");
            SqlParameter[] parameters = {
                    new SqlParameter("@Description", SqlDbType.NVarChar, 50)
            };
            parameters[0].Value = Description;

            return DBHelper.DefaultDBHelper.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ���ӽ�ɫ
        /// </summary>       
        public int Create(string description)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("INSERT INTO Accounts_Roles(Description) VALUES(@Description)  ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters =
              {
                    new SqlParameter("@Description", SqlDbType.NVarChar, 50)
                };
            parameters[0].Value = description;

            object obj = DBHelper.DefaultDBHelper.GetSingle(strSql.ToString(), parameters);
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
        /// ���½�ɫ��Ϣ
        /// </summary>
        public bool Update(int roleId, string description)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE Accounts_Roles SET Description = @Description WHERE RoleID = @RoleID  ");
            SqlParameter[] parameters =
                  {
                    new SqlParameter("@RoleID", SqlDbType.Int, 4),
                    new SqlParameter("@Description", SqlDbType.NVarChar, 50)
                };
            parameters[0].Value = roleId;
            parameters[1].Value = description;

            int rows = DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
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
        /// ɾ����ɫ
        /// </summary>
        public bool Delete(int roleId)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("DELETE Accounts_RolePermissions  ");
            strSql.Append(" WHERE RoleID = @RoleID ");
            SqlParameter[] parameters =
                 {
                    new SqlParameter("@RoleID", SqlDbType.Int, 4)
                };
            parameters[0].Value = roleId;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);


            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append("DELETE Accounts_UserRoles  ");
            strSql2.Append(" WHERE RoleID = @RoleID");
            SqlParameter[] parameters2 =
                {
                     new SqlParameter("@RoleID", SqlDbType.Int, 4)
                };
            parameters2[0].Value = roleId;
            cmd = new CommandInfo(strSql2.ToString(), parameters2, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);



            StringBuilder strSql3 = new StringBuilder();
            strSql3.Append("DELETE Accounts_Roles ");
            strSql3.Append("WHERE RoleID = @RoleID ");
            SqlParameter[] parameters3 =
                {
                      new SqlParameter("@RoleID", SqlDbType.Int, 4)
                };
            parameters3[0].Value = roleId;
            cmd = new CommandInfo(strSql3.ToString(), parameters3, EffentNextType.ExcuteEffectRows);
            sqllist.Add(cmd);

            int rowsAffected = DBHelper.DefaultDBHelper.ExecuteSqlTran(sqllist);
            return rowsAffected > 0;
        }

        /// <summary>
        /// ���ݽ�ɫID��ȡ��ɫ����Ϣ
        /// </summary>
        public DataRow Retrieve(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT RoleID, Description FROM Accounts_Roles WHERE RoleID = @RoleID   ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RoleID", SqlDbType.Int, 4)
                };
            parameters[0].Value = roleId;
            DataSet roles = DBHelper.DefaultDBHelper.Query(strSql.ToString(), parameters);
            return roles.Tables[0].Rows[0];
        }

        /// <summary>
        /// Ϊ��ɫ����Ȩ��
        /// </summary>
        public void AddPermission(int roleId, int permissionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("  delete FROM Accounts_RolePermissions WHERE   RoleID = @RoleID and PermissionID = @PermissionID ");
            strSql.Append(" INSERT INTO Accounts_RolePermissions(RoleID, PermissionID)  ");
            strSql.Append(" 	VALUES(@RoleID, @PermissionID)    ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RoleID", SqlDbType.Int, 4),
                    new SqlParameter("@PermissionID", SqlDbType.Int, 4)
                };
            parameters[0].Value = roleId;
            parameters[1].Value = permissionId;
             DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// �ӽ�ɫ�Ƴ�Ȩ��
        /// </summary>
        public void RemovePermission(int roleId, int permissionId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" DELETE Accounts_RolePermissions WHERE RoleID = @RoleID and PermissionID = @PermissionID");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RoleID", SqlDbType.Int, 4),
                    new SqlParameter("@PermissionID", SqlDbType.Int, 4)
                };
            parameters[0].Value = roleId;
            parameters[1].Value = permissionId;
            DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// ��ս�ɫ��Ȩ��
        /// </summary>
        public void ClearPermissions(int roleId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" DELETE Accounts_RolePermissions WHERE RoleID = @RoleID ");
            SqlParameter[] parameters =
                {
                    new SqlParameter("@RoleID", SqlDbType.Int, 4),
            };
            parameters[0].Value = roleId;
            DBHelper.DefaultDBHelper.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// ��ȡ���н�ɫ���б�
        /// </summary>
        public DataSet GetRoleList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT RoleID, Description FROM Accounts_Roles ORDER BY Description ASC");
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetRoleList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select RoleID,Description ");
            strSql.Append(" FROM Accounts_Roles ");
            if (idlist.Trim() != "")
            {
                strSql.Append(" where RoleID in (" + idlist + ")");
            }
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }

        #region  ��ȡ���еĽ�ɫȨ�޹������Լ��û���ɫ����
        /// <summary>
        ///��ȡ���е��û���ɫ
        /// </summary>
        /// <returns></returns>
        public DataSet GetALLUserRole()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_UserRoles ");
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }


        /// <summary>
        ///��ȡ���е��û���ɫ
        /// </summary>
        /// <returns></returns>
        public DataSet GetALLRolePerm()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Accounts_RolePermissions ");
            return DBHelper.DefaultDBHelper.Query(strSql.ToString());
        }
        #endregion
    }
}
