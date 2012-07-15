<%@ Control Language="C#" CodeBehind="ForeignKey.ascx.cs" Inherits="Placesv1.Data.ForeignKeyField" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />

