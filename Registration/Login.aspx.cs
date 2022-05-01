using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registration
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var session = Session["AuthorizedMember"];
            if (session != null)
            {
                Response.Write(session);
            }
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            var random = new Random();
            var connectToDatabase = new ConnectToDatabase();
            if (!connectToDatabase.IsValidateUser(Email.Text, Password.Text)) Response.Redirect("~/Error.aspx");
            else
                Session["AuthorizedMember"] = random.Next(0, 10000).ToString();
                Session.Timeout = 1;
                Session.Add("AuthorizedMember", Session["AuthorizedMember"]);
                Response.Redirect("~/MasterPages/Default.aspx");
        }
    }
}