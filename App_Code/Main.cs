using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Main
/// </summary>
public static class Main
{
    private static List<List<string>> titles;
    private static List<List<string>> links;
    private static List<List<string>> content;

    public static void Initialize()
    {
        XMLParser xmlparse = new XMLParser();
        HTMLParser htmparse = new HTMLParser(xmlparse.getLinks());
        titles = xmlparse.getTitles();
        links = xmlparse.getLinks();
        content = htmparse.getHTMLContent();
    }

    public static List<List<string>> Search(string pattern)
    {
        List<List<string>> result = new List<List<string>>();
        for (int i = 0; i < titles.Count; i++)
        {
            for (int j = 0; j < titles[i].Count; j++)
            {
                List<string> temp = new List<string>();
                int matchIdx = KMPMatcher.KMPMatch(titles[i][j], pattern);
                if(matchIdx == -1)
                    matchIdx = KMPMatcher.KMPMatch(content[i][j], pattern);
                if (matchIdx != -1)
                {
                    temp.Add(titles[i][j]);
                    temp.Add(links[i][j]);
                    temp.Add(content[i][j]);
                    result.Add(temp);
                }
            }
        }
        return result;
    }
}