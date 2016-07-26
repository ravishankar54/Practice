
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="StockControl.Products.Views.Product"
    Title="Product" MasterPageFile="~/Shared/DefaultMaster.master" %>
<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" Runat="Server">
        <h1>
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </h1>
<p>

<table>
<tr>
    <td>
    Product Name
    </td>

    <td>
    <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
    </td>
</tr>

<tr>
    <td>
    Cost
    </td>

    <td>
    <asp:TextBox ID="txtCost" runat="server"></asp:TextBox>
    </td>

</tr>

<tr>
    <td>
    
    </td>

    <td>
     <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />
    </td>
</tr>

</table>

    

</asp:Content>
