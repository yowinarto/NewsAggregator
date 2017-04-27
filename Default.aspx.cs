using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void GreetButton_Click(object sender, EventArgs e)
    {
        List<List<string>> matchText = Main.Search(TextInput.Text);
        if (matchText != null) {
            Label[] links = new Label[matchText.Count];
            Label[] contents = new Label[matchText.Count];
            for (int i = 0; i < links.Length; i++)
            {
                int idx = matchText[i][2].IndexOf(TextInput.Text, StringComparison.CurrentCultureIgnoreCase);
                links[i] = new Label();
                links[i].Text = "<br><a href=\"" + matchText[i][1] + "\">" + matchText[i][0] + "</a><br>";
                contents[i] = new Label();
                contents[i].Width = 750;
                if (idx >= 0)
                {
                    int header = 50;
                    int length = 100;
                    if (idx + length >= matchText[i][2].Length)
                    {
                        length = length - (idx + length - matchText[i][2].Length);
                    }
                    if (idx < header) {
                        contents[i].Text = matchText[i][2].Substring(0, length) + " ... " + "<br><br>";
                    } else
                    {
                        contents[i].Text = matchText[i][2].Substring(0, header) + " ... " + matchText[i][2].Substring(idx, length) + " ... " + "<br><br>";
                    } 
                } else
                {
                    contents[i].Text = matchText[i][2].Substring(0, 50) + " ... " + "<br><br>";
                }
                form1.Controls.Add(links[i]);
                form1.Controls.Add(contents[i]);
            }
            
        }
    }

    protected void KMP_CheckedChanged(object sender, EventArgs e)
    {
        BoyerMoore.Checked = false;
        Regex.Checked = false;
        Main.SetAlgorithm(0);
    }

    protected void BoyerMoore_CheckedChanged(object sender, EventArgs e)
    {
        KMP.Checked = false;
        Regex.Checked = false;
        Main.SetAlgorithm(1);
    }

    protected void Regex_CheckedChanged(object sender, EventArgs e)
    {
        KMP.Checked = false;
        BoyerMoore.Checked = false;
        Main.SetAlgorithm(2);
    }
}