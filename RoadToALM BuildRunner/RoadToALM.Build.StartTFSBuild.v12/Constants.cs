using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadToALM.Build.StartTFSBuild.v12
{
    public class Constants
    {
        public static string PARAMETER_DROP_LOCATION = ConfigurationSettings.AppSettings["PARAMETER_DROP_LOCATION"].ToString();
        public static string PARAMETER_BUILD_NAME = ConfigurationSettings.AppSettings["PARAMETER_BUILD_NAME"].ToString();

    }
}
