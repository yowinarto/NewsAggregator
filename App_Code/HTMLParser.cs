using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for HTMLParser
/// </summary>
public class HTMLParser
{
    public HTMLParser()
    {
        //string urlAddress = "http://finance.detik.com/wawancara/3480201/bu-sri-mulyani-jokowi-gencar-bangun-infrastruktur-uangnya-dari-mana";
        string urlAddress = "https://sport.detik.com/sepakbola/bola-dunia/3480342/tianjin-quanjian-masih-incar-diego-costa-siap-bersaing-dengan-tim-tim-top-eropa";
        //multiple line article masih blum bnr
        string content;
        content = GetPlainTextFromHtml(GetHTML(urlAddress));
        System.Diagnostics.Debug.WriteLine(content);
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

    private string GetPlainTextFromHtml(string htmlString)
    {
        string startPattern = "<div class=\"detail_text\" id=\"detikdetailtext\">|<div class=\"artikel\">";
        string endPattern = "<!-- end artikel -->";
        string htmlTagPattern = "<.*?>";
        //var regexCss = new Regex("(\\<script(.+?)\\</script\\>)|(\\<style(.+?)\\</style\\>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        //htmlString = regexCss.Replace(htmlString, string.Empty);
        htmlString = Regex.Replace(htmlString, startPattern, "~HEAD");
        htmlString = Regex.Replace(htmlString, endPattern, "~END");
        htmlString = Regex.Replace(htmlString, htmlTagPattern, string.Empty);
        htmlString = htmlString.Replace("&nbsp;", string.Empty);
        htmlString = Regex.Replace(htmlString, @"^\s+$[\t\r\n]*", "", RegexOptions.Multiline);
        Match patternMatch = Regex.Match(htmlString, "~HEAD[\r\n](.*)");//|~HEAD\\s+[\r\n](.+\\s+[\r\n])*~END");
        if (patternMatch.Success)
        {
            htmlString = patternMatch.Groups[1].Value;
        }

        return htmlString;
    }
}