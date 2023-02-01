using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace YUTU.BLL.Common
{
    public static class DevelopTool
    {
        public static void getProperties<T>(T t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return;
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);

                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    System.Console.WriteLine("string " + name + " = " + "tb" + name + ".Text");
                }
                else
                {
                    getProperties(t);
                }
            }
            return;
        }

        public static string GetInsertProperties<T>(T t)
        {
            string[] sysType = { "Int32", "Decimal", "DateTime", "Double" };
            string insert = "insert into " + typeof(T).Name;
            StringBuilder names = new StringBuilder();
            names.Append("(");
            StringBuilder values = new StringBuilder();
            values.Append("(");
            if (t == null)
            {
                return "";
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return "";
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                string fValue = "";
                if (name.ToLower() == "id")
                {
                    continue;
                }
                if (!item.PropertyType.IsValueType && item.PropertyType.Name.StartsWith("String"))
                {
                    fValue = string.Format("{0}{1}{0},", "'", value ?? "");

                }
                if (item.PropertyType.IsValueType && (sysType.Contains(item.PropertyType.Name)))
                {
                    fValue = string.Format("{0},", value ?? 0);
                }
                names.Append(name + ",");
                values.Append(fValue);
            }
            names.Remove(names.Length - 1, 1);
            values.Remove(values.Length - 1, 1);
            names.Append(")");
            values.Append(")");
            insert += names + " Values " + values;
            return insert;
        }

        public static string GetObjectKeyAndValue<T>(T t)
        {
            string[] sysType = { "Int32", "Decimal", "DateTime", "Double" };
            string result = "insert into " + typeof(T).Name;

            StringBuilder names = new StringBuilder();

            if (t == null)
            {
                return "";
            }
            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return "";
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                string fValue = "";

                string tmp = string.Format("\"{0}\":\"{1}\",", name, value ?? "");
                //string tmp = string.Format("{0}=\"{1}\"，", name, "");
                names.Append(tmp);
            }
            result = names.ToString();
            return result;
        }
    }
}
