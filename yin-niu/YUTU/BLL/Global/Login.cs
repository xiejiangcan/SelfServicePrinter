using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YUTU.BLL.Global
{
    public static class Login
    {
        public static string UserCode = "0001";
        public static string UserName = "张三";
        public static string UserPassword = "aaaaaa";
        public static string RoleCode = "R001";
        //public static IList<Data dataAuthoritys = null;
        //public static ChangE.Authority[] authoritys = null;
        public static IList<Authority> authoritys = null;
        public static string UserOrganCode = "";
        public static string OrganCode = "";
        public static string OrganName = "";
        static bool isSystemAdministrator = false;

        /// <summary>
        /// 检查是否是管理员或属于管理员角色
        /// </summary>
        public static bool IsSystemAdministrator
        {
            get
            {
                if (Login.UserCode == "admin" || Login.RoleCode == "admin")
                {
                    isSystemAdministrator = true;
                }
                else
                {
                    isSystemAdministrator = false;
                }
                return true;//TODO 暂时放开权限 add by sqj at 2021-9-23 10:37:29
            }
            set { Login.isSystemAdministrator = value; }
        }

        /// <summary>
        /// 检查是否有某个功能的权限
        /// </summary>
        /// <param name="functionCode"></param>
        /// <returns></returns>
        public static bool CheckAuthority(string functionCode)
        {
            if (authoritys == null) { throw new Exception("未获取到您的权限列表！"); }

            var authority = authoritys.SingleOrDefault(c => c.FunctionCode == functionCode);// && c.UserCode == Login.UserCode
            if (authority == null)
            {
                throw new Exception("此功能的操作权限编号不存在，请与管理员联系");
            }
            else
            {
                if (authority.IsEnable == 1)
                {
                    return true;
                }
                else
                {
                    throw new Exception("无权限");
                }
            }
        }

        /// <summary>
        /// 检查是否有某个功能的权限
        /// </summary>
        /// <param name="functionCode"></param>
        /// <returns></returns>
        public static bool CheckAuthorityEx(string functionCode)
        {
            if (authoritys == null) { return false; }

            var authority = authoritys.SingleOrDefault(c => c.FunctionCode == functionCode);// && c.UserCode == Login.UserCode
            if (authority == null)
            {
                //throw new Exception("此功能的操作权限编号不存在，请与管理员联系");
                return false;
            }
            else
            {
                if (authority.IsEnable == 1)
                {
                    return true;
                }
                else
                {
                    //throw new Exception("此功能的操作权限编号不存在，请与管理员联系");
                    return false;
                }
            }
        }
    }
    /// <summary>
    /// 角色和用户公用权限实体
    /// </summary>
    public class Authority
    {
        /// <summary>
        /// 编号
        /// </summary>
        public virtual string Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 模块编号
        /// </summary>
        public virtual string ModuleCode { get; set; }

        /// <summary>
        /// 功能编号
        /// </summary>
        public virtual string FunctionCode { get; set; }

        /// <summary>
        /// 权限标志，1有，0无
        /// </summary>
        public virtual int IsEnable { get; set; }
    }
}
