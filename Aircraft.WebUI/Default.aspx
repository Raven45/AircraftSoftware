<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aircraft.WebUI.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        
    <asp:ScriptManager runat="server" />
        <div>
            <asp:UpdatePanel runat="server" >
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>Model: </td>
                            <td><asp:TextBox runat="server" ID="txtModel" /></td>
                        </tr>
                        <tr>
                            <td>Serial Number: </td>
                            <td><asp:TextBox runat="server" ID="txtSerial" /></td>
                        </tr>
                        <tr>
                            <td></td>
                            <td><asp:Button runat="server" Text="Insert New Aircraft" ID="cmdInsert" OnClick="cmdInsert_Click" /></td>
                        </tr>
                    </table> 
                    <br />
                    <h2>Search Results</h2>
                    <asp:DataGrid 
                        runat="server" ID="DataGrid" AutoGenerateColumns="false" 
                        PageSize="20" DataKeyField="Id"
                        OnDeleteCommand="DataGrid_DeleteCommand"
                        OnUpdateCommand="DataGrid_UpdateCommand"
                        OnEditCommand="DataGrid_EditCommand"
                        OnCancelCommand="DataGrid_CancelCommand">
                        <Columns>
                            <asp:BoundColumn DataField="Model" HeaderText="Model" />
                            <asp:BoundColumn DataField="SerialNumber" HeaderText="Serial Number" />
                            <asp:EditCommandColumn ButtonType="PushButton"
                                 EditText="Edit"
                                 CancelText="Cancel"
                                 UpdateText="Update" 
                                 HeaderText="Edit item"></asp:EditCommandColumn>
                            <asp:ButtonColumn ButtonType="PushButton" Text="Delete" CommandName="Delete" />
                        </Columns>
                    </asp:DataGrid>
                    </ContentTemplate>
                </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
