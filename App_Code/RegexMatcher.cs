using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for RegexMatcher
/// </summary>
public class RegexMatcher
{
    public static int RegexMatch(string strContent, string pattern)
    {
        Match rgxMatch = Regex.Match(strContent.ToLower(), pattern.ToLower());
        if (rgxMatch.Success)
        {
            return rgxMatch.Index;
        }
        else
        {
            return -1;
        }
    }
}