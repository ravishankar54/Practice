<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UserControlDemo._Default" %>

<%@ Register Src="~/UserControls/UserInformation.ascx" TagPrefix="uc1" TagName="UserInformation" %>
<%@ Register Src="~/UserControls/UserInformationGrid.ascx" TagPrefix="uc2" TagName="UserInformationGrid" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:UserInformation runat="server" ID="UserInformation" />
</asp:Content>

