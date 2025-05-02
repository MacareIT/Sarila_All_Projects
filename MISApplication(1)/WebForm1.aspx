<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="MISApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblproduct" runat="server" Text="Upload Products"></asp:Label>  
<asp:FileUpload ID="FileUploadProduct" runat="server" />  
<asp:Button ID="btnupload" runat="server" Text="Upload"/>  
<asp:Label ID="MsgAlert" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
