<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Registration.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration Form</title>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link href="~/Styles/RegistrationStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h1>Register</h1>
             <p>Please fill in this form to create an account.</p>
             <hr/>

            <label for="UserName"><b>Username :</b></label>
            <asp:Textbox type="text" placeholder="Enter Username" name="UserName" id="UserName" required="required" runat="server" />
             
            <asp:Label for="Email" runat="server"><b>E-mail :</b> </asp:Label>
            <asp:Textbox type="email" placeholder="Enter  Email" name="Email" id="Email" required="required" runat="server" />
         
            <asp:Label for="Password" runat="server"><b>Password :</b></asp:Label>
            <asp:Textbox type="password" placeholder="Enter Password" name="Password" id="Password" required="required" runat="server" />
            <hr/>
            <p>By creating an account you agree to our <a href="#">Terms & Privacy</a>.</p>

            <asp:HyperLink NavigateUrl="Success.aspx" runat="server" Text="Success" />

            <asp:Button ID="btnregister" CssClass="registerbtn" runat="server" Text="Register" OnClick="btnregister_Click" />
        </div>
    </form>
</body>
</html>
