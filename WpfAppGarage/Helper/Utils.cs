using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppGarage.Helper
{
    public class Utils
    {
        public static string[] GetListCar()
        {
            string _rep = ConfigurationManager.AppSettings["repFileExterne"];

            var _listFic = Directory.GetFiles(_rep, "*.jpg", SearchOption.TopDirectoryOnly);

            return _listFic;

        }
    }
}
