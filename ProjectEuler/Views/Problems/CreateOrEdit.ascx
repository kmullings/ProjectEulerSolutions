<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProjectEuler.Models.Problem>" %>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Id) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.Id) %>
    <%: Html.ValidationMessageFor(model => model.Id) %>
</div>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Title) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.Title) %>
    <%: Html.ValidationMessageFor(model => model.Title) %>
</div>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Summary) %>
</div>
<div class="editor-field">
    <%: Html.TextAreaFor(model => model.Summary, 10, 50, null)%>
    <%: Html.ValidationMessageFor(model => model.Summary)%>
</div>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Description) %>
</div>
<div class="editor-field">
    <%: Html.TextAreaFor(model => model.Description, 10, 50, null) %>
    <%: Html.ValidationMessageFor(model => model.Description) %>
</div>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Answer) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.Answer) %>
    <%: Html.ValidationMessageFor(model => model.Answer) %>
</div>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Code) %>
</div>
<div class="editor-field">
    <%: Html.TextAreaFor(model => model.Code, 10, 50, null) %>
    <%: Html.ValidationMessageFor(model => model.Code) %>
</div>
<div class="editor-label">
    <%: Html.LabelFor(model => model.Language) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.Language) %>
    <%: Html.ValidationMessageFor(model => model.Language) %>
</div>
<div class="editor-label">
    <%: Html.LabelFor(model => model.FunctionName) %>
</div>
<div class="editor-field">
    <%: Html.EditorFor(model => model.FunctionName) %>
    <%: Html.ValidationMessageFor(model => model.FunctionName) %>
</div>
