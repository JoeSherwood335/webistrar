<%@ Page Language="VB" Inherits="System.Web.Mvc.ViewPage(Of R2kdoiMVC.Model.Report)" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=Html.Encode(Model.ReportName)%> for <%=html.Encode(model.Referral.Info.FirstName) %> <%=Html.Encode(Model.Referral.Info.LastName)%></title>
    
    <style type="text/css">
        body
        {
            background-color:#333;
        }
        #entry-header{
        	   background-color:White;
        	   margin:0px auto;
        	   width:800px;
        	   padding:10px;
        	}
        #entry-content
        {
        	padding:10px;
        	   background-color:White;
        	   margin:0px auto;
        	   width:800px;
        	   min-height:1000px;
        }
        #entry-footer{
        	   background-color:White;
        	   margin:0px auto;
        	   width:800px;
        	   padding:10px;
        }
        #entry-footer span
        {
            width:33%;
            font-size:x-small ;
        }
        
    </style>
</head>
<body>
        <div id="entry-header">
            <span><%= Html.Encode(Model.ReportName) %></span>
        </div>
        <div id="entry-content">
            <%=Model.ReportContent%>
        </div>
        <div id="entry-footer">
            <span><%= Html.Encode(Model.ReportName) %></span>
            <span class="timestamp"><%=Html.Encode(String.Format("{0:D}", Model.TimeStamp))%></span>
            <span class="status"><%=Html.Encode(Model.ReportStatus.ReportStatus)%></span>
        </div>       
               
</body>
</html>

