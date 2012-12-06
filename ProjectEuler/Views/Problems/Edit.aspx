<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProjectEuler.Models.Problem>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Edit</h2>
    <% using (Html.BeginForm())
       { %>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <legend>Problem</legend>
        <%: Html.HiddenFor(model => model.ProblemId) %>
        <%: Html.Partial("CreateOrEdit", Model) %>
        <p>
            <input type="submit" value="Save" class = "jquery-button"  />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("Back to List", "Index", null, new { @class = "jquery-button" })%>
    </div>
</asp:Content>
