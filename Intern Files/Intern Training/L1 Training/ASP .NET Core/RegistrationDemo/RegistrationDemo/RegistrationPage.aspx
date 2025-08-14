<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="RegistrationDemo.RegistrationPage" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Registration</title>
    <style>
        body {
            background-color: #121212;
            color: #e0e0e0;
            font-family: 'Segoe UI', sans-serif;
            display: flex;
            justify-content: center;
            padding: 40px 20px;
        }

        .wrapper {
            background-color: #1f1f1f;
            padding: 30px;
            border-radius: 10px;
            width: 100%;
            max-width: 900px;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.5);
        }

        h2 {
            text-align: center;
            color: #ffffff;
            margin-bottom: 25px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            display: block;
            margin-bottom: 5px;
            font-weight: 500;
        }

        input, select {
            width: 100%;
            padding: 10px;
            background-color: #2c2c2c;
            color: #ffffff;
            border: none;
            border-radius: 5px;
        }

        input::placeholder {
            color: #aaaaaa;
        }

        .btn-submit {
            background-color: #4CAF50;
            color: white;
            padding: 10px;
            width: 100%;
            border: none;
            border-radius: 5px;
            font-weight: bold;
            cursor: pointer;
        }

        .btn-submit:hover {
            background-color: #45a049;
        }

        .message {
            text-align: center;
            margin-top: 10px;
        }

        table {
            width: 100%;
            margin-top: 30px;
            border-collapse: collapse;
            background-color: #2c2c2c;
            color: #e0e0e0;
        }

        th, td {
            padding: 10px;
            border: 1px solid #444;
            text-align: left;
        }

        th {
            background-color: #3a3a3a;
        }

        .btn-edit {
            background-color: #ffeb3b;
            color: #000;
            padding: 5px 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-decoration: none;
        }

        .btn-delete {
            background-color: #f44336;
            color: #fff;
            padding: 5px 10px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-decoration: none;
        }

        .action-buttons {
            display: flex;
            gap: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <h2>Employee Registration</h2>

            <asp:HiddenField ID="hfEmployeeId" runat="server" />

            <div class="form-group">
                <label for="txtName">Full Name</label>
                <asp:TextBox ID="txtName" runat="server" placeholder="Enter full name" required="true" />
            </div>

            <div class="form-group">
                <label for="txtAge">Age</label>
                <asp:TextBox ID="txtAge" runat="server" placeholder="Enter age" TextMode="Number" required="true" />
            </div>

            <div class="form-group">
                <label for="txtDOJ">Date of Joining</label>
                <asp:TextBox ID="txtDOJ" runat="server" placeholder="Select date" TextMode="Date" required="true" />
            </div>

            <div class="form-group">
                <label for="ddlDept">Department</label>
                <asp:DropDownList ID="ddlDept" runat="server" required="true">
                    <asp:ListItem Text="Select Department" Value="" />
                    <asp:ListItem Text="Human Resources" Value="HR" />
                    <asp:ListItem Text="Engineering" Value="Engineering" />
                    <asp:ListItem Text="Marketing" Value="Marketing" />
                    <asp:ListItem Text="Finance" Value="Finance" />
                    <asp:ListItem Text="IT Support" Value="IT Support" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="txtEmail">Email Address</label>
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter email" TextMode="Email" required="true" />
            </div>

            <div class="form-group">
                <label for="txtPhone">Phone Number</label>
                <asp:TextBox ID="txtPhone" runat="server" placeholder="Enter phone number" TextMode="Phone" required="true" />
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Register" CssClass="btn-submit" OnClick="btnSubmit_Click" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblMessage" runat="server" CssClass="message" />

            <asp:Repeater ID="rptEmployees" runat="server" OnItemCommand="rptEmployees_ItemCommand">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Name</th>
                                <th>Age</th>
                                <th>Date of Joining</th>
                                <th>Department</th>
                                <th>Email</th>
                                <th>Phone</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Age") %></td>
                        <td><%# Eval("DateOfJoining", "{0:yyyy-MM-dd}") %></td>
                        <td><%# Eval("Department") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Phone") %></td>
                        <td class="action-buttons">
                            <asp:LinkButton runat="server" CommandName="Edit" CommandArgument='<%# Eval("Id") %>'
                                CssClass="btn-edit" CausesValidation="false">Edit</asp:LinkButton>
                            <asp:LinkButton runat="server" CommandName="Delete" CommandArgument='<%# Eval("Id") %>'
                                CssClass="btn-delete" CausesValidation="false">Delete</asp:LinkButton>
                            <asp:HyperLink ID="lnkRegister" runat="server"
                                NavigateUrl=<%#"UsingQueryStringsRegister.aspx?Id=" + Eval("Id")%>>GO TO</asp:HyperLink>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                        </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div class="wrapper">
            
        </div>
    </form>
</body>
</html>
