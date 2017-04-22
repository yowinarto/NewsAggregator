using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Net.Http;
using HtmlAgilityPack;

/// <summary>
/// Summary description for HTMLParser
/// </summary>
public class HTMLParser
{
    private List<List<string>> htmlContents;

    public HTMLParser(List<List<string>> urlAddress)
    {
        //string content = ParseHTML("http://news.detik.com/read/2017/04/21/193836/3481069/10/ini-alasan-andi-mallarangeng-dapat-cuti-jelang-bebas");
        htmlContents = new List<List<string>>();
        string[] a = new string[3];
        a[0] = "detail_text";
        a[1] = "text_detail";
        a[2] = "artikel";
        foreach (List<string> address in urlAddress)
        {
            List<string> content = new List<string>();
            for (int i = 0; i < address.Count; i++)
            {
                content.Add(ParseLine(ParseHTML(address[i], a)));
                //System.Diagnostics.Debug.WriteLine(htmlContents[i]);
            }
            htmlContents.Add(content);
        }
       
    }

    public List<List<string>> getHTMLContent() {
        return htmlContents;
    }

    private string ParseHTML(string urlAddress, string[] classID)
    {
        string content = "";
        String src = GetHTML(urlAddress);
        HtmlDocument res = new HtmlDocument();
        res.LoadHtml(src);
        for (int i = 0; i < classID.Length; i++)
        {
            string tmp = "//div[@class='" + classID[i] + "']";
            if (res.DocumentNode.SelectSingleNode(tmp) != null) {
                content = res.DocumentNode.SelectSingleNode(tmp).InnerText;
            }
        }
        return content;
    }

    private string GetHTML(string urlAddress) {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string content = "";

        if (response.StatusCode == HttpStatusCode.OK)
        {
            Stream receiveStream = response.GetResponseStream();
            StreamReader readStream = null;

            if (response.CharacterSet == null)
            {
                readStream = new StreamReader(receiveStream);
            }
            else
            {
                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
            }

            content = readStream.ReadToEnd();
            response.Close();
            readStream.Close();
        }
        return content;
    }
    
    private string ParseLine(string htmlString)
    {
        string htmlTagPattern = "<.*?>";
        //Regex regex = new Regex(@"\<\!\[CDATA\[(?<text>[^\]]*)\]\]\>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //htmlString = regex.Replace(htmlString, string.Empty);
        htmlString = regexCss.Replace(htmlString, string.Empty);
        htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
        htmlString = htmlString.Replace("&nbsp;", string.Empty);
        htmlString = Regex.Replace(htmlString, @"^\s+$[\t\r\n]*", "", RegexOptions.Multiline);
        return htmlString;
    }
/*
 *     private string ParseLine(string htmlString)
    {
        //string startPattern = "<div class=\"detail_text\" id=\"detikdetailtext\">";
        string htmlTagPattern = "<.*?>";
        var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        htmlString = regexCss.Replace(htmlString, string.Empty);
        //htmlString = Regex.Replace(htmlString, startPattern, "~HEAD");
        htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
        htmlString = htmlString.Replace("&nbsp;", string.Empty);
        htmlString = Regex.Replace(htmlString, @"^\s+$[\t\r\n]*", "", RegexOptions.Multiline);
        //htmlString = Regex.Replace(htmlString, "[\r\n]", " ");
        Match patternMatch = Regex.Match(htmlString, "~HEAD[\r\n](.*)");
        if (patternMatch.Success)
        {
            htmlString = patternMatch.Groups[1].Value;
        }
        return htmlString;
    }

    private string ParseMultiLine(string htmlString)
    {
        string startPattern = "<div class=\".*artikel\">";
        string endPattern = "<!-- end.*artikel -->";
        string htmlTagPattern = "<.*?>";
        htmlString = Regex.Replace(htmlString, startPattern, "~HEAD");
        htmlString = Regex.Replace(htmlString, endPattern, "~END");
        htmlString = Split(htmlString, "~HEAD", "~END");
        var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        htmlString = regexCss.Replace(htmlString, string.Empty);
        htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
        htmlString = htmlString.Replace("&nbsp;", string.Empty);
        htmlString = Regex.Replace(htmlString, @"^\s+$[\t\r\n]*", "", RegexOptions.Multiline);
        htmlString = Regex.Replace(htmlString, "[\r\n]", " ");
        return htmlString;
    }

    private string Split(string value, string start, string end)
    {
        int startPos = value.IndexOf(start);
        int endPos = value.LastIndexOf(end);
        if (startPos == -1 || endPos == -1)
        {
            return "";
        }
        int adjustedPosA = startPos + start.Length;
        if (adjustedPosA >= endPos)
        {
            return "";
        }
        return value.Substring(adjustedPosA, endPos- adjustedPosA);
    }*/
}