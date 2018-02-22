using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorradLogFileHelper.Classes
{
    class AppServerDetails : IEquatable<AppServerDetails>
    {
        public string AppName { get; set; }
        public string AppIP { get; set; }

        public bool Equals(AppServerDetails obj)
        {
            if (obj == null) return false;
            AppServerDetails objAsPart = obj as AppServerDetails;
            if (objAsPart == null) return false;
            else return Equals(objAsPart);
        }

        internal static string getAppName(string IPAdd)
        {
            string APPName = "";
            // Create a list of parts.
            List<AppServerDetails> APPList = new List<AppServerDetails>();
            try
            {
                // Add parts to the list.
                APPList.Add(new AppServerDetails() { AppName = "SPACESWS", AppIP = "52.74.150.149" });
                APPList.Add(new AppServerDetails() { AppName = "SPACESAPP", AppIP = "52.220.165.49" });
                APPList.Add(new AppServerDetails() { AppName = "ETOUCH", AppIP = "10.20.1.8" });
                APPList.Add(new AppServerDetails() { AppName = "OPMANAGER", AppIP = "10.9.192.165" });
                APPList.Add(new AppServerDetails() { AppName = "SMS", AppIP = "10.20.1.4" });
                APPList.Add(new AppServerDetails() { AppName = "EXPATS", AppIP = "192.168.22.202" });
                APPList.Add(new AppServerDetails() { AppName = "CRM", AppIP = "10.9.179.35" });
                APPList.Add(new AppServerDetails() { AppName = "EINVOICE", AppIP = "192.168.22.200" });
                APPList.Add(new AppServerDetails() { AppName = "EPRF", AppIP = "10.9.179.200" });

                bool existed = APPList.Find(r => r.AppIP.Contains(IPAdd)) != null ? true : false;
                if (existed)
                    APPName = APPList.Find(x => x.AppIP.Contains(IPAdd)).AppName.ToString();
                else
                    APPName = "N/A";
            }
            catch (Exception ex)
            {

            }
            return APPName;
        }
        //public const string SPACESWSIP = "52.74.150.149";
        //public const string ETOUCHIP = "10.20.1.8";
        //public const string OPMANAGERIP = "10.9.192.165";
        //public const string SMSIP = "10.20.1.4";
        //public const string EXPATSIP = "192.168.22.202";
        //public const string CRMIP = "10.9.179.35";
        //public const string EINVOICEIP = "192.168.22.200";
        //public const string EPRFIP = "10.9.179.200";

        //private string _SPACESAPPIP;

        //public string SPACESAPPIP
        //{
        //    get { return _SPACESAPPIP; }
        //    set { _SPACESAPPIP = "52.220.165.49"; }
        //}

        //internal static string getAppName(string iPAdd)
        //{
        //    AppServerDetails.
        //}
    }
}
