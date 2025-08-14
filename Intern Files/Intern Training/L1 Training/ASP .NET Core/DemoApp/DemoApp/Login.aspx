<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoApp.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            background-color: #f4effc;
            font-family: 'Segoe UI', sans-serif;
            margin: 0;
            padding: 0;
        }

        .login-wrapper {
            max-width: 400px;
            margin: 80px auto;
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
            margin-bottom: 8px;
            display: block;
        }

        .form-input {
            width: 100%;
            padding: 10px;
            margin-bottom: 18px;
            border: 1px solid #d1c4e9;
            border-radius: 15px;
        }

        .login-button {
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

        .login-button:hover {
            background-color: #7e57c2;
        }

        .status-message {
            text-align: center;
            color: #d500f9;
            margin-top: 20px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-wrapper">
            <h2>Welcome Back</h2>

            <asp:Label ID="lblUsername" runat="server" Text="Username:" />
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-input" />

            <asp:Label ID="lblPassword" runat="server" Text="Password:" />
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-input" />

            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="login-button" OnClick="btnLogin_Click" />

            <br />
            <br />
            <br />

            <asp:Label ID="lblStatus" runat="server" CssClass="status-message" Visible="false" />
        </div>
    </form>
</body>
</html>

