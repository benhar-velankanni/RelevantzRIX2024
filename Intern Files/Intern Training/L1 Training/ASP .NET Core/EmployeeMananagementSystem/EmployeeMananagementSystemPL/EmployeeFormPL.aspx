<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeFormPL.aspx.cs" Inherits="EmployeeMananagementSystemPL.EmployeeFormPL" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employee Management</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="txtName" runat="server" Placeholder="Name" /><br />
            <asp:TextBox ID="txtDept" runat="server" Placeholder="Department" /><br />
            <asp:TextBox ID="txtEmail" runat="server" Placeholder="Email" /><br />
            <asp:TextBox ID="txtHireDate" runat="server" Placeholder="Hire Date (yyyy-MM-dd)" /><br />
            <asp:Button ID="btnAdd" runat="server" Text="Add Employee" OnClick="btnAdd_Click" /><br /><br />

            <asp:GridView ID="grdEmployeeData" runat="server" AutoGenerateColumns="False" DataKeyNames="EmployeeId"
                OnRowEditing="grdEmployeeData_RowEditing"
                OnRowUpdating="grdEmployeeData_RowUpdating"
                OnRowCancelingEdit="grdEmployeeData_RowCancelingEdit"
                OnRowDeleting="grdEmployeeData_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="EmployeeId" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                    <asp:BoundField DataField="Department" HeaderText="Department" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="HireDate" HeaderText="Hire Date" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
