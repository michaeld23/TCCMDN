<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="TCCMDN.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   UserName : <asp:TextBox ID="UserName" runat="server"
  placeholder=""></asp:TextBox> <br />
   Lastname : <asp:TextBox ID="Lastname" runat="server"
  placeholder=""></asp:TextBox> <br />
   Firstname : <asp:TextBox ID="FirstName" runat="server"
  placeholder=""></asp:TextBox> <br />
</asp:Content>
