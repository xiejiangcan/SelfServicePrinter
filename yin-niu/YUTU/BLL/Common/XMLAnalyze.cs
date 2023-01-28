using System;
using System.IO;
using System.Xml;

namespace YUTU.BLL.Common
{

    class XmlAnalyze
    {
        XmlDocument xmldoc;
        XmlElement xmlelem;
        private string path = Tools.GetCurrentPath() + "\\Users.xml";
        /*
         *用户信息 start
         */
        #region 用户信息

        public void CreateXml(string userCode, string userName, string organCode, string roleCode, string pwd)
        {
            try
            {
                xmldoc = new XmlDocument();
                XmlDeclaration xmldecl = xmldoc.CreateXmlDeclaration("1.0", "gb2312", null);
                xmldoc.AppendChild(xmldecl);
                //加入一个根元素
                xmlelem = xmldoc.CreateElement("", "Users", "");
                xmldoc.AppendChild(xmlelem);
                //加入另外一个元素
                XmlNode root = xmldoc.SelectSingleNode("Users");
                XmlElement xe1 = xmldoc.CreateElement("Node");
                root.AppendChild(xe1);
                XmlElement xesub1 = xmldoc.CreateElement("UserCode");
                xesub1.InnerText = userCode;
                xe1.AppendChild(xesub1);
                XmlElement xesub2 = xmldoc.CreateElement("UserName");
                xesub2.InnerText = userName;
                xe1.AppendChild(xesub2);
                XmlElement xesub3 = xmldoc.CreateElement("OrganCode");
                xesub3.InnerText = organCode;
                xe1.AppendChild(xesub3);
                XmlElement xesub4 = xmldoc.CreateElement("RoleCode");
                xesub4.InnerText = roleCode;
                xe1.AppendChild(xesub4);
                XmlElement xesub5 = xmldoc.CreateElement("Pwd");
                xesub5.InnerText = pwd;
                xe1.AppendChild(xesub5);
                xmldoc.Save(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool FindXml(string userCode)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                var selectSingleNode = xmlDoc.SelectSingleNode("Users");
                if (selectSingleNode != null)
                {
                    XmlNodeList nodeList = selectSingleNode.ChildNodes;
                    if (nodeList.Count < 1) return false;
                    int i = 0;
                    foreach (XmlNode xn in nodeList)
                    {
                        if (i >= 10) return false;
                        XmlNodeList nodeList1 = xmlDoc.GetElementsByTagName("UserCode");
                        XmlNode node = nodeList1.Item(i);
                        if (node.InnerText == userCode)
                        {
                            return true;
                        }
                        i++;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public string FindNodeXml(string nodeName)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                var selectSingleNode = xmlDoc.SelectSingleNode("Users");
                if (selectSingleNode != null)
                {
                    XmlNodeList nodeList = xmlDoc.GetElementsByTagName(nodeName);
                    if (nodeList.Count < 1) return "";
                    XmlNode node = nodeList.Item(nodeList.Count - 1);
                    return node.InnerText;
                }
                return "";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertXml(string userCode, string userName, string organCode, string roleCode, string pwd)
        {
            try
            {
                if (!FindXml(userCode) && !string.IsNullOrEmpty(userCode))
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(path);
                    XmlNode root = xmlDoc.SelectSingleNode("Users");
                    XmlElement xe1 = xmlDoc.CreateElement("Node");
                    XmlElement xesub1 = xmlDoc.CreateElement("UserCode");
                    xesub1.InnerText = userCode;
                    xe1.AppendChild(xesub1);
                    XmlElement xesub2 = xmlDoc.CreateElement("UserName");
                    xesub2.InnerText = userName;
                    xe1.AppendChild(xesub2);
                    XmlElement xesub3 = xmlDoc.CreateElement("OrganCode");
                    xesub3.InnerText = organCode;
                    xe1.AppendChild(xesub3);
                    XmlElement xesub4 = xmlDoc.CreateElement("RoleCode");
                    xesub4.InnerText = roleCode;
                    xe1.AppendChild(xesub4);
                    XmlElement xesub5 = xmlDoc.CreateElement("Pwd");
                    xesub5.InnerText = pwd;
                    xe1.AppendChild(xesub5);
                    root.AppendChild(xe1);
                    xmlDoc.Save(path);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteXmlNode()
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                XmlNode root = xmlDoc.SelectSingleNode("Users");
                if (root != null)
                {
                    XmlNodeList xnList = root.ChildNodes;
                    if (xnList.Count < 1) return;
                    foreach (XmlNode xn in xnList)
                    {
                        root.RemoveChild(xn);
                        xmlDoc.Save(path);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModifyNodeXml(string nodeName, string val)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                var selectSingleNode = xmlDoc.SelectSingleNode("Users");
                if (selectSingleNode != null)
                {
                    XmlNodeList nodeList = xmlDoc.GetElementsByTagName(nodeName);
                    if (nodeList.Count < 1) return;
                    XmlNode node = nodeList.Item(nodeList.Count - 1);
                    node.InnerText = val;
                }
                xmlDoc.Save(path);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool FileExist()
        {
            return File.Exists(path);
        }

        #endregion
    }
}
