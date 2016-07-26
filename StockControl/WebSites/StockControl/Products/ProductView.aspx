<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductView.aspx.cs" Inherits="StockControl.Products.Views.ProductView"
    Title="ProductView" MasterPageFile="~/Shared/DefaultMaster.master" %>

<asp:Content ID="content" ContentPlaceHolderID="DefaultContent" runat="Server">
    <h1>
        <asp:Label ID="lblTitle" runat="server"></asp:Label>
    </h1>
    <table>
        <tr>
            <td>
              Prodcut Name
            </td>
            <td>
             <asp:Label ID="lblProductName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
            Product cost
            </td>
            <td>
            <asp:Label ID="lblProductCost" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>
