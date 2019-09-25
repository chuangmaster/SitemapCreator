using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SitemapCreator
{
    internal class XMLCreator
    {
        private XDocument _xml;
        private XElement rootNode;
        private XNamespace nameSpace = "http://www.sitemaps.org/schemas/sitemap/0.9";
        public XMLCreator()
        {
            _xml = new XDocument(new XDeclaration("1.0", "utf-8", null));

            rootNode = new XElement(nameSpace + "urlset");

        }
        /// <summary>
        /// Get site map xml document
        /// </summary>
        /// <param name="webSiteData"></param>
        /// <returns></returns>
        internal XDocument GetSiteMapXML(List<(string address, float score)> webSiteData)
        {
            foreach (var item in webSiteData)
            {
                rootNode.Add(new XElement(nameSpace + "url",
                    new XElement(nameSpace + "loc", item.address),
                    new XElement(nameSpace + "lastmod", DateTime.UtcNow),
                    new XElement(nameSpace + "priority", item.score)));
            }
            _xml.Add(rootNode);
            return _xml;
        }
    }
}