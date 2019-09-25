using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SitemapCreator
{
    internal class XMLCreator
    {
        private XElement _xml;

        public XMLCreator()
        {
            _xml = new XElement("urlset");
        }
        internal XElement GetSiteMapXML(Dictionary<string, float> webSiteData)
        {
            foreach (var item in webSiteData)
            {
                _xml.Add(new XElement("url", 
                    new XElement("loc", item.Key), 
                    new XElement("lastmod", DateTime.UtcNow), 
                    new XElement("priority", item.Value)));
            }
            return _xml;
        }
    }
}