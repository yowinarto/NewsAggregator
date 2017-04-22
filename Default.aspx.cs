using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MainLabel.Text = "<h1>News Aggregator</h1><br>";
    }

    protected void GreetButton_Click(object sender, EventArgs e)
    {
        List<List<string>> matchText = Main.Search(TextInput.Text);
        if (matchText != null) {
            Label[] links = new Label[matchText.Count];
            //Label[] contents = new Label[matchText.Count];
            for (int i = 0; i < links.Length; i++)
            {
                links[i] = new Label();
                links[i].Text = "<br><a href=\"" + matchText[i][1] + "\">" + matchText[i][0] + "</a><br>";
                //contents[i] = new Label();
               // contents[i].Text = matchText[i][2] + "<br>";
                form1.Controls.Add(links[i]);
               // form1.Controls.Add(contents[i]);
            }
            
        }
    }

    protected void KMP_CheckedChanged(object sender, EventArgs e)
    {
        BayerMoore.Checked = false;
        Regex.Checked = false;
        Main.SetAlgorithm(0);
    }

    protected void BayerMoore_CheckedChanged(object sender, EventArgs e)
    {
        KMP.Checked = false;
        Regex.Checked = false;
        Main.SetAlgorithm(1);
    }

    protected void Regex_CheckedChanged(object sender, EventArgs e)
    {
        KMP.Checked = false;
        BayerMoore.Checked = false;
        Main.SetAlgorithm(2);
    }
}