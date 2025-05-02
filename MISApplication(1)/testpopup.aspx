<%@ Page Title="" Language="C#" MasterPageFile="~/MIS.Master" AutoEventWireup="true" CodeBehind="testpopup.aspx.cs" Inherits="MISApplication.testpopup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.jquery.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/chosen/1.8.7/chosen.min.css" rel="stylesheet" />
      <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <style style="font-size: medium">
         .one {
            margin: 20px;
            padding: 20px;
            
        }
       #overlay {
position: fixed;
top: 0;
left: 0;
width: 100%;
height: 100%;
background-color: #000;
filter:alpha(opacity=70);
-moz-opacity:0.7;
-khtml-opacity: 0.7;
opacity: 0.7;
z-index: 100;
display: none;
}
.content a{
text-decoration: none;
}
.popup{
width: 100%;
margin: 0 auto;
display: none;
position: fixed;
z-index: 101;
}
.content{
min-width: 600px;
width: 600px;
min-height: 150px;
margin: 100px auto;
background: #f3f3f3;
position: relative;
z-index: 103;
padding: 10px;
border-radius: 5px;
box-shadow: 0 2px 5px #000;
}
.content p{
clear: both;
color: #555555;
text-align: justify;
}
.content p a{
color: #d91900;
font-weight: bold;
}
.content .x{
float: right;
height: 35px;
left: 22px;
position: relative;
top: -25px;
width: 34px;
}
.content .x:hover{
cursor: pointer;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager runat="server"></asp:ScriptManager> 
       <div class='popup'>
<div class='content'>
<img src='http://www.developertips.net/demos/popup-dialog/img/x.png' alt='quit' class='x' id='x' />
<p>
Welcome to Aspdotnet-Suresh.com. Please use above search option which was there in top right side to get help with many of articles.
<br/>
<br/>
<a href="close" class='close'>Close</a>
</p>
</div>
</div>         
<div id='container'>
<a href="click" class='click'><h2><b>Click Here to See Popup! </b></h2></a> <br/>

    <%--<asp:FileUpload ID="FileUploadProduct" runat="server" />--%>  
  <input type="button" class="btn btn-primary" id="Button1" onserverclick="viewexcel" name="add" value="View Excel" runat="server" />
</div>
     <script type='text/javascript'>
        $(function () {
            var overlay = $('<div id="overlay"></div>');
            $('.close').click(function () {
                $('.popup').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });
            $('.x').click(function () {
                $('.popup').hide();
                overlay.appendTo(document.body).remove();
                return false;
            });

            $('.click').click(function () {
                overlay.show();
                overlay.appendTo(document.body);
                $('.popup').show();
                return false;
            });
        });
     </script>
</asp:Content>
