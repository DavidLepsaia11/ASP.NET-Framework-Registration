using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Registration
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnregister_Click(object sender, EventArgs e)
        {
            var connectToDatabase = new ConnectToDatabase();
            var res = connectToDatabase.Insert(UserName.Text, Email.Text, Password.Text);

            if (res == -1) Response.Redirect("~/Error.aspx");
            else Response.Redirect("~/Success.aspx");
        }
    }
}