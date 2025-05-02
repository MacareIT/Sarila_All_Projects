<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signin.aspx.cs" Inherits="CRF_Tracker_Latest.Signin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link rel="stylesheet" href="StyleSheet2.css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-wrap">
	<div class="login-html">
		<input id="tab-1" type="radio" name="tab" class="sign-in" checked><label for="tab-1" class="tab">Sign In</label>
		<input id="tab-2" type="radio" name="tab" class="sign-up"><label for="tab-2" class="tab"></label>
		<div class="login-form">
			<div class="sign-in-htm">
				<div class="group">
					<label for="user" class="label">Username</label>
					<asp:TextBox ID="txt_username" runat="server" class="input"></asp:TextBox>
					<%--<input id="txt_username" runat="server" type="text" class="input">--%>
				</div>
				<div class="group">
					<label for="pass" class="label">Password</label>
					<asp:TextBox ID="txt_password" runat="server" class="input" TextMode="Password" ></asp:TextBox>
				<%--	<input id="txt_password" runat="server" type="password" class="input" data-type="password">--%>
				</div>
				<div class="group">
					<%--<input id="check" type="checkbox" class="check" checked>
					<label for="check"><span class="icon"></span> Keep me Signed in</label>--%>
				</div>
				<div class="group">
					<%--<button runat="server" class="button" onclick="BtnSubmit()"></button>--%>
					<asp:Button ID="Button1" runat="server" Text="SIGN IN" CssClass="button" OnClick="Button1_Click" />
				</div>
				<div class="hr"></div>
				<div class="foot-lnk">
					<%--<a href="#forgot">Forgot Password?</a>--%>
					<asp:Label ID="Label1" runat="server" Text="Invalid Username or Password" Visible="false"></asp:Label>
				</div>
			</div>
			
		</div>
	</div>
</div>
    </form>
</body>
</html>
