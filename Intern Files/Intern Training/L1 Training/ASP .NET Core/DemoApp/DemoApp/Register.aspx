<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DemoApp.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <style>
        body {
            background-color: #f4effc;
            font-family: 'Segoe UI', sans-serif;
            margin: 0;
            padding: 0;
        }

        .register-wrapper {
            max-width: 500px;
            margin: 60px auto;
            padding: 30px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 8px 24px rgba(130, 90, 213, 0.2);
        }

        h2 {
            text-align: center;
            color: #7c4dff;
            margin-bottom: 25px;
        }

        label {
            color: #6a1b9a;
            font-weight: 500;
            margin-bottom: 6px;
            display: block;
        }

        .form-input {
            width: 100%;
            padding: 10px;
            margin-bottom: 12px;
            border: 1px solid #d1c4e9;
            border-radius: 15px;
        }

        .error-label {
            color: red;
            font-size: 13px;
            margin-bottom: 10px;
            display: block;
        }

        .register-button {
            width: 100%;
            background-color: #9575cd;
            color: white;
            border: none;
            padding: 12px;
            border-radius: 5px;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        .register-button:hover {
            background-color: #7e57c2;
        }

        .status-message {
            text-align: center;
            color: #388e3c;
            margin-top: 20px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="register-wrapper">
            <h2>Create Account</h2>

            <asp:Label ID="lblUsername" runat="server" Text="Username:" />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-input" />
            <asp:Label ID="errUsername" runat="server" CssClass="error-label" Visible="false" />

            <asp:Label ID="lblEmail" runat="server" Text="Email:" />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-input" />
            <asp:Label ID="errEmail" runat="server" CssClass="error-label" Visible="false" />

            <asp:Label ID="lblAge" runat="server" Text="Age:" />
            <asp:TextBox ID="txtAge" runat="server" CssClass="form-input" />
            <asp:Label ID="errAge" runat="server" CssClass="error-label" Visible="false" />

            <asp:Label ID="lblMobile" runat="server" Text="Mobile Number:" />
            <asp:TextBox ID="txtMobile" runat="server" CssClass="form-input" />
            <asp:Label ID="errMobile" runat="server" CssClass="error-label" Visible="false" />

            <asp:Label ID="lblPassword" runat="server" Text="Password:" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-input" />
            <asp:Label ID="errPassword" runat="server" CssClass="error-label" Visible="false" />

            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:" />
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" CssClass="form-input" />
            <asp:Label ID="errConfirmPassword" runat="server" CssClass="error-label" Visible="false" />

            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="register-button" OnClick="btnRegister_Click" />
            <asp:Label ID="lblStatus" runat="server" CssClass="status-message" Visible="false" />
        </div>
    </form>
</body>
</html>

