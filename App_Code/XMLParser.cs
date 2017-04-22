using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Diagnostics;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
public class XMLParser
{
    private List<List<string>> titles;
    private List<List<string>> links;

    public XMLParser()
    {
        titles = new List<List<string>>();
        links = new List<List<string>>();
        Parse("http://rss.detik.com/index.php/detikcom");
        //Parse("http://tempo.co/rss/terkini");
        //Parse("http://rss.vivanews.com/get/all");
        //Parse("http://www.antaranews.com/rss/terkini");
    }

    public List<List<string>> getTitles() {
        return titles;
    }

    public List<List<string>> getLinks() {
        return links;
    }

    private void Parse(String feedLink)
    {
        XmlDocument feedXmlDoc = new XmlDocument();
        feedXmlDoc.Load(feedLink);
        XmlNodeList feedNodes = feedXmlDoc.SelectNodes("rss/channel/item");
        StringBuilder feedContent = new StringBuilder();
        List<string> title = new List<string>();
        List<string> link = new List<string>();

        foreach (XmlNode feedNode in feedNodes) {
            XmlNode subNode = feedNode.SelectSingleNode("title");
            title.Add(subNode.InnerText);
            subNode = feedNode.SelectSingleNode("link");
            link.Add(subNode.InnerText);     
        }
        titles.Add(title);
        links.Add(link);
    }
}