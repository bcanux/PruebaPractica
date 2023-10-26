<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PracticaNetBrandonCanux.Practica.Login1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio de Sesión</title>

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />


    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .login-container {
            text-align: center;
            background-color: #f0f0f0;
            border: 1px solid #ddd;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0px 0px 10px rgba(0, 0, 0, 0.2);
        }

        .divControles{
            margin: 10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Inicio de Sesión</h2>
            <div class="divControles">
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" required="required"></asp:TextBox>
            </div>
            <div class="divControles">
                <asp:TextBox runat="server" ID="txtContrasenia" TextMode="Password" CssClass="form-control" required="required" ></asp:TextBox>
            </div>
            <div class="divControles">
                 <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass=" btn btn-primary" OnClick="btnLogin_Click" />
            </div>
             
        
        </div>
    </form>
</body>
</html>
