<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarArticulo.aspx.cs" Inherits="Presentacion.AgregarArticulo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 143px;
        }
        .style2
        {
            width: 353px;
        }
        .style3
        {
            text-align: center;
        }
        .style4
        {
            font-size: xx-large;
            text-decoration: underline;
        }
        .style5
        {
            width: 143px;
            font-size: large;
            font-weight: bold;
        }
        .style6
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style3">
    
        <span class="style4"><strong>ARTICULO</strong></span><br />
    
    </div>
    <table style="width:100%;">
        <tr>
            <td class="style5">
                Codigo:</td>
            <td class="style2">
                <asp:TextBox ID="txtCodigo" runat="server" ontextchanged="TextBox1_TextChanged" 
                    Width="356px" MaxLength="6" style="background-color: #FFFFFF"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                    Text="Buscar" Width="106px" CssClass="style6" Height="29px" />
            </td>
        </tr>
        <tr>
            <td class="style5">
                Precio:</td>
            <td class="style2">
                <asp:TextBox ID="txtPrecio" runat="server" Width="356px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style5">
                Descripcion:</td>
            <td class="style2">
                <asp:TextBox ID="txtDescripcion" runat="server" Height="112px" Width="356px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Agregar" Width="106px" CssClass="style6" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" Width="106px" CssClass="style6" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
