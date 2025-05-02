<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Compliance_Register.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<link rel="stylesheet" href="StyleSheet1.css" />
</head>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous" />
<body>
	<section class="login">
		<div class="login_box">
			<div class="left">
				<div class="contact">
					<form runat="server">
						<h3>SIGN IN</h3>
                        <asp:TextBox ID="txt_username" runat="server" placeholder="USERNAME"></asp:TextBox>
                        <asp:TextBox ID="txt_password" runat="server" placeholder="PASSWORD" TextMode="Password"></asp:TextBox>
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <asp:Button ID="Button1" runat="server" Text="LOGIN" class="submit"  BackColor="#4c5db0" OnClick="Button1_Click"  />
					</form>
				</div>
			</div>
			<div class="right">
				<div class="right-text">
				</div>				
			</div>
		</div>
	</section>
</body>
</html>
