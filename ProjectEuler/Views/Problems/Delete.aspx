<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProjectEuler.Models.Problem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Delete</h2>
    <h3>
        Are you sure you want to delete this?</h3>
    <fieldset>
        <legend>Problem</legend>
        <div class="display-label">
            ProblemId</div>
        <div class="display-field">
            <%: Model.ProblemId %></div>
        <div class="display-label">
            Id</div>
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
        <div class="display-label">
            FunctionName</div>
        <div class="display-field">
            <%: Model.FunctionName %></div>
    </fieldset>
    <% using (Html.BeginForm())
       { %>
    <p>
        <input type="submit" value="Delete" class="jquery-button" />
        <%: Html.ActionLink("Back to List", "Index", null, new { @class = "jquery-button" })%>
    </p>
    <% } %>
</asp:Content>
