using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using MadDogObjects;

namespace XDT.Maddog
{
    public class XDTCore
    {
        public enum MaddogDataBase
        {
            OrcasTS,
            Whidbey
        }

        public XDTCore()
        { 
        
        }

        public static Owner GetCurrentOwner()
        {
            Owner owner = new Owner(Environment.UserName);
            return owner;
        }

        public static bool ConnectDatabase(MaddogDataBase dataBaseType = MaddogDataBase.OrcasTS)
        {
            bool isConnect = false;
            string mdsql = "mdsql3";
            string dataBaseName = "OrcasTS";

            switch (dataBaseType)
            { 
                case MaddogDataBase.OrcasTS:
                    break;
                case MaddogDataBase.Whidbey:
                    mdsql = "mdsql2";
                    dataBaseName = "Whidbey";
                    break;
                default:
                    break;
            }
            try
            {
                MadDogObjects.Utilities.Security.AppName = "Reporter XDT";
                MadDogObjects.Utilities.Security.AppOwner = Environment.UserName;

                MadDogObjects.Utilities.Security.SetDB(mdsql, dataBaseName, "MDReadWrite", "Cujo");

                isConnect = true;
            }
            catch (Exception ex)
            {
                string msg = "Unable to connect Maddog database: " + dataBaseType.ToString() + "\n" + ex.Message + "\n" + ex.StackTrace;
            }

            return isConnect;
        }

        public static bool IsValidRunID(int runID)
        {
            bool isValidRunID = false;

            return isValidRunID;
        }
    }
}
