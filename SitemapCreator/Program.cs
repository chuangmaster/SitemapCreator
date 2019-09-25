using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SitemapCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            //取得網站資料
            var webSiteData = GetWebSiteData();

            //產生 site map xml
            XMLCreator ctr = new XMLCreator();
            var xmlData = ctr.GetSiteMapXML(webSiteData);
            //產生 xml
            string path = Path.Combine(Environment.CurrentDirectory, "sitemap.xml");
            xmlData.Save(path);
        }

        /// <summary>
        /// Get web site data
        /// </summary>
        /// <returns></returns>
        private static Dictionary<string, float> GetWebSiteData()
        {
            var result = new Dictionary<string, float>();
            result.Add("https://homepage.com.tw", 1.0f);
            result.Add("https://homepage.com.tw/news", 0.8f);
            return result;
        }
    }
}
