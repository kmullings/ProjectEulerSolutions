<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProjectEuler.Models.Problem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Details</h2>
    <fieldset>
        <legend>Problem</legend>
        <div class="display-label">
            ID</div>
        <div class="display-field">
            <%: Model.Id %></div>
        <div class="display-label">
            Title</div>
        <div class="display-field">
            <%: Model.Title %></div>
        <div class="display-label">
            Summary</div>
        <div class="display-field">
            <%: Model.Summary%></div>
        <div class="display-label">
            Description</div>
        <div class="display-field">
            <%: Model.Description %></div>
        <div class="display-label">
            Answer</div>
        <div class="display-field">
            <%: Model.Answer %></div>
        <div class="display-label">
            Code</div>
        <div class="display-field">
            <%: Model.Code %></div>
        <div class="display-label">
            Language</div>
        <div class="display-field">
            <%: Model.Language %></div>
    </fieldset>
    <p>
        <%: Html.ActionLink("Recalculate", "Recalculate", new { id = Model.ProblemId }, new { @class = "jquery-button" })%>
        <%: Html.ActionLink("Back to List", "Index", null, new { @class = "jquery-button" })%>
    </p>
</asp:Content>
