using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StringMatcher
/// </summary>
public class KMPMatcher
{
    public static int KMPMatch(string strContent,string pattern)
    {
        int n = strContent.Length, m = pattern.Length;
        int[] fail = computeFail(pattern);
        int i = 0, j = 0;
        string patternLow = pattern.ToLower();
        string contentLow = strContent.ToLower();
        while (i < n) {
            if (patternLow[j] == contentLow[i])
            {
                if (j == m - 1)
                    return i - m + 1;
                i++;
                j++;
            }
            else if (j > 0)
                j = fail[j - 1];
            else
                i++;
        }
        return -1;
    }

    private static int[] computeFail(string pattern) {
        int[] fail = new int[pattern.Length];
        fail[0] = 0;
        int m = pattern.Length;
        int j = 0;
        int i = 1;
        string tmp = pattern.ToLower();
        while(i < m)
        {
            if (tmp[j] == tmp[i])
            {
                fail[i] = j + 1;
                i++;
                j++;
            }
            else if (j > 0)
                j = fail[j - 1];
            else
            {
                fail[i] = 0;
                i++;
            }
        }
        return fail;
    }
}