<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<ProjectEuler.Models.Problem>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Problems
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Content/dataTables/css/demo_table.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.dataTables.min.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.validate.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#problemsTable').dataTable({
                "bServerSide": false,
                bJQueryUI: true,
                "bFilter": false,
                "bSort": false,
                "asStripClasses": null, //To remove "odd"/"event" zebra classes
                "oLanguage": {
                    "sZeroRecords": "You haven't added any problems as yet."
                },
                bStateSave: true
            })
        }); 
    </script>
    <h2>
        Problems</h2>
    <table id="problemsTable" class="display">
        <thead>
            <tr>
                <th>
                </th>
                <th>
                    ID
                </th>
                <th>
                    Summary
                </th>
                <th>
                    Answer
                </th>
            </tr>
        </thead>
        <tbody>
            <% foreach (var item in Model.OrderBy(row => row.Id))
               { %>
            <tr id="<%: item.ProblemId %>">
                <td>
                    <%: Html.ActionLink("Details", "Details", new { id = item.ProblemId }, new { @class = "jquery-button" })%>
                </td>
                <td>
                    <%: item.Id %>
                </td>
                <td>
                    <%: item.Summary %>
                </td>
                <td>
                    <%: item.Answer %>
                </td>
            </tr>
            <% } %>
        </tbody>
    </table>
</asp:Content>
