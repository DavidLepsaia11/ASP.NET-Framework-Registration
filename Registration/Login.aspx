<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Registration.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="~/Styles/LoginStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Login</h1>
            <hr/>

             <asp:Label for="Email" runat="server"><b>E-mail :</b> </asp:Label>
            <asp:Textbox type="email" placeholder="Enter  Email" name="Email" id="Email" required="required"  runat="server"  />
         
            <asp:Label for="Password" runat="server"><b>Password :</b></asp:Label>
            <asp:Textbox type="password" placeholder="Enter Password" name="Password" id="Password" required="required" runat="server" />
            <hr/>

            <asp:Button ID="btnlogin" CssClass="loginbtn" runat="server" Text="Login" OnClick="btnlogin_Click" />

            <hr/>
            <p class="forOneParagraph">Don't have an account?<a href="Registration.aspx">Sign up</a>.</p>
        </div>
    </form>
</body>
</html>
