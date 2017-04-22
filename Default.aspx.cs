using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HelloWorldLabel.Text = "Hello, world!";
    }

    protected void GreetButton_Click(object sender, EventArgs e)
    {
        List<List<string>> matchText = Main.Search(TextInput.Text);
        if (matchText != null) {
            Label[] text = new Label[matchText.Count];
            Label[] links = new Label[matchText.Count];
            for (int i = 0; i < text.Length; i++)
            {
                text[i] = new Label();
                text[i].Text = "<br>" + matchText[i][0] + "<br>";
                links[i] = new Label();
                links[i].Text = "<a href=\"" + matchText[i][1] + "\">Link</a>";
                links[i].Height = 110 + (20 * (i + 1));
                form1.Controls.Add(text[i]);
                form1.Controls.Add(links[i]);
            }
            
        }
    }
}