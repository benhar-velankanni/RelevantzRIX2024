<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Translator-Inator.aspx.cs" Inherits="TranslatorPL.Translator_Inator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            font-family: 'Segoe UI', sans-serif;
            display: flex;
            justify-content: center;
            margin: 0 auto;
            padding: 40px 20px;
        }       

        .form-content, .search-content {
          margin-bottom: 40px;
        }

        .wrapper {
            padding: 30px;
            border-radius: 10px;
            width: 100%;
            max-width: 900px;
            display:flex;
            align-items:center;
            flex-direction:column;
            box-shadow: 0 0 15px rgba(0, 0, 0, 0.5);
        }

        input, select {
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <div class="wrapper">
        <form class="form-group" id="form1" runat="server">
            <div class="form-content">
                <asp:Label for="txtTranslationString" runat="server">Translation String:</asp:Label>
                <br />
                <asp:TextBox ID="txtTranslationString" runat="server" Height="30px" Width="250px" ValidationGroup="AddGroup"></asp:TextBox>
                <br />
                <asp:Label for="ddlFromLang" runat="server">From Language:</asp:Label><br />
                <asp:DropDownList ID="ddlFromLang" runat="server" Height="30px" Width="250px" ValidationGroup="AddGroup">
                    <asp:ListItem Text="Select From Language" Value="" />
                    <asp:ListItem Text="Tamil" Value="Tamil" />
                    <asp:ListItem Text="English" Value="English" />
                    <asp:ListItem Text="Hindi" Value="Hindi" />
                    <asp:ListItem Text="Japanese" Value="Japanese" />
                    <asp:ListItem Text="Spanish" Value="Spanish" />
                </asp:DropDownList>
                <br />
                <asp:Label for="ddlToLang" runat="server">To Language:</asp:Label><br />
                <asp:DropDownList ID="ddlToLang" runat="server" Height="30px" Width="250px" ValidationGroup="AddGroup">
                    <asp:ListItem Text="Select From Language" Value="" />
                    <asp:ListItem Text="Tamil" Value="Tamil" />
                    <asp:ListItem Text="English" Value="English" />
                    <asp:ListItem Text="Hindi" Value="Hindi" />
                    <asp:ListItem Text="Japanese" Value="Japanese" />
                    <asp:ListItem Text="Spanish" Value="Spanish" />
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblError" runat="server" ForeColor="Red" />
                <br />
                <asp:Button id="btnAdd" runat="server" Text="Add Translation" OnClick="btnAdd_Click" Height="30px" Width="250px" /><br />
            </div> 
        

            <div class="search-content">
                <asp:Label for="txtSearchBox" runat="server">Enter ID for searching:</asp:Label>
                <asp:TextBox ID="txtSearchBox" runat="server" TextMode="Number" Height="30px" Width="250px"></asp:TextBox>
                <asp:Button id="btnSearch" runat="server" Text="Search Translation" OnClick="btnSearch_Click" CausesValidation="false" Height="30px" Width="250px" />
                <br />
                <br />
                <asp:Label ID="lblSearchResult" runat="server" ForeColor="Green" />
            </div>

            <asp:GridView ID="grdTranslationData" runat="server" AutoGenerateColumns="False" DataKeyNames="TranslationId"
                OnRowEditing="grdTranslationData_RowEditing"
                OnRowUpdating="grdTranslationData_RowUpdating"
                OnRowCancelingEdit="grdTranslationData_RowCancelingEdit"
                OnRowDeleting="grdTranslationData_RowDeleting"
                OnRowDataBound="grdTranslationData_RowDataBound"
                Width="760px">
                <Columns>
                    <asp:BoundField DataField="TranslationId" HeaderText="ID" ReadOnly="True" />
                    <asp:BoundField DataField="TranslationString" HeaderText="Translation String" />
                    <asp:TemplateField HeaderText="From Language">
                        <ItemTemplate>
                            <%# Eval("FromLang") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditFromLang" runat="server" Width="150px">
                                <asp:ListItem Text="Select From Language" Value="" />
                                <asp:ListItem Text="Tamil" Value="Tamil" />
                                <asp:ListItem Text="English" Value="English" />
                                <asp:ListItem Text="Hindi" Value="Hindi" />
                                <asp:ListItem Text="Japanese" Value="Japanese" />
                                <asp:ListItem Text="Spanish" Value="Spanish" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="To Language">
                        <ItemTemplate>
                            <%# Eval("ToLang") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlEditToLang" runat="server" Width="150px">
                                <asp:ListItem Text="Select To Language" Value="" />
                                <asp:ListItem Text="Tamil" Value="Tamil" />
                                <asp:ListItem Text="English" Value="English" />
                                <asp:ListItem Text="Hindi" Value="Hindi" />
                                <asp:ListItem Text="Japanese" Value="Japanese" />
                                <asp:ListItem Text="Spanish" Value="Spanish" />
                            </asp:DropDownList>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Actions" ShowEditButton="True" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </form>
    </div>
</body>
</html>

