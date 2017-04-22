using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BayerMooreMatcher
/// </summary>
public class BayerMooreMatcher
{
    public static int BMMatch(string strContent, string pattern)
    {
        int[] last = buildLast(pattern);
        int n = strContent.Length;
        int m = pattern.Length;
        int i = m-1,j = m - 1;
        string patternLow = pattern.ToLower();
        string contentLow = strContent.ToLower();
        if (i > n - 1)
            return -1;

        do
        {
            if (patternLow[j] == contentLow[i])
            {
                if (j == 0)
                    return i;
                else
                {
                    i--;
                    j--;
                }
            }
            else
            {
                int temp = last[contentLow[i]];
                i = i + m - Math.Min(j, 1 + temp);
                j = m - 1;
            }
        } while (i <= n - 1);
        return -1;
    }

    private static int[] buildLast(String pattern)
    {
        int[] last = new int[128];
        for (int i = 0; i < 128; i++)
        {
            last[i] = -1;
        }
        for (int i = 0; i < pattern.Length; i++)
        {
            last[pattern[i]] = i;
        }
        return last;
    }
}