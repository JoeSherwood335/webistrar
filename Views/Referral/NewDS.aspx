<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.ProgramOutcomes.dsOutcome)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Development Services
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Development Services</h2>
    <div id="filelist">
        
            <%=ViewData("filelist")%>
       
    </div>
    
    <%  Html.RenderPartial("dsOutcome")%>

    
    <form id="ajaxUploadForm" action="<%=Url.Action("AjaxUpload", "Referral", New With {.rid = cint(ViewContext.RouteData.Values("id"))})%>" method="post" enctype="multipart/form-data">   
        <fieldset>   
            <legend>Upload a file</legend>   
            <label>File to Upload: <input type="file" name="file" />(100MB max size)</label>   
            <input id="ajaxUploadButton" type="submit" value="Attach" />   
        </fieldset>   
    </form>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeaderContent" runat="server">

 <script type="text/javascript" src="http://<%=HttpContext.Current.Request.Url.Host%>:<%=HttpContext.Current.Request.Url.Port%><%=HttpContext.Current.Request.ApplicationPath%>Scripts/jquery.form.js"></script>
 <script type="text/javascript" src="http://<%=HttpContext.Current.Request.Url.Host%>:<%=HttpContext.Current.Request.Url.Port%><%=HttpContext.Current.Request.ApplicationPath%>Scripts/jquery.blockUI.js"></script>

 <script type="text/javascript">
     $(function() {

         $("#ajaxUploadForm").ajaxForm({
             iframe: true,
             dataType: "json",
             beforeSubmit: function() {
             $("#ajaxUploadForm").block({ message: '<h1><img src="http://<%=HttpContext.Current.Request.Url.Host%>:<%=HttpContext.Current.Request.Url.Port%><%=HttpContext.Current.Request.ApplicationPath%>Content/busy.gif" /> Uploading file...</h1>' });
             },
             success: function(result) {
                 $("#ajaxUploadForm").unblock();
                 $("#ajaxUploadForm").resetForm();
                 // $.growlUI(null, result.message);
                 $("#filelist").append(result.filename);
                 $("#Month").val(result.month);
                 $("#Year").val(result.year);
                 $("#AvgSuccessRate").val(result.success);
                 alert(result.message);
             },
             error: function(xhr, textStatus, errorThrown) {
                 $("#ajaxUploadForm").unblock();
                 $("#ajaxUploadForm").resetForm();
                 alert('Error uploading file');
                 //$.growlUI(null, 'Error uploading file');

             }
         });
     });
</script>


 <style type="text/css">
    #filelist ul li
    {
        display: inline;
        list-style-type: none;
        margin:0px;
    }
    #filelist ul
    {
        margin:0px;
    }
 
 </style>
</asp:Content>

