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
    private static int algoType;

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
                string tempIns;
                int matchIdx = SearchAlgorithm(titles[i][j], pattern);
                if (matchIdx == -1)
                {
                    matchIdx = SearchAlgorithm(content[i][j], pattern);
                    if (matchIdx != -1)
                    {
                        tempIns = content[i][j].Insert(matchIdx + pattern.Length, "</b>");
                        tempIns = tempIns.Insert(matchIdx, "<b>");
                        temp.Add(titles[i][j]);
                        temp.Add(links[i][j]);
                        temp.Add(tempIns);
                        result.Add(temp);
                    }
                } else
                {
                    tempIns = titles[i][j].Insert(matchIdx + pattern.Length, "</b>");
                    tempIns = tempIns.Insert(matchIdx, "<b>");
                    temp.Add(tempIns);
                    temp.Add(links[i][j]);
                    temp.Add(content[i][j]);
                    result.Add(temp);
                }
            }
        }
        return result;
    }

    public static void SetAlgorithm(int type) {
        algoType = type;
    }

    private static int SearchAlgorithm(string strContent, string pattern)
    {
        switch (algoType)
        {
            case 0:
                return KMPMatcher.KMPMatch(strContent, pattern);
            case 1:
                return BayerMooreMatcher.BMMatch(strContent, pattern);
            case 2:
                return RegexMatcher.RegexMatch(strContent, pattern);
            default:
                return -1;
        }
    }
}