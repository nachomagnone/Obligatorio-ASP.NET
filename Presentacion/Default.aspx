<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Presentacion.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style6
        {
            font-size: medium;
            color: #000000;
        }
        .style11
        {
            height: 86px;
            font-size: xx-large;
            text-decoration: underline;
            text-align: center;
            color: #000000;
        }
        .style13
        {
            text-align: center;
            color: #000000;
            font-size: medium;
        }
        .style15
        {
            text-align: center;
            color: #000000;
            height: 117px;
        }
    </style>
</head>
<body style="height: 72px; width: 1428px;">
    <form id="form1" runat="server">
    <table style="width:100%;">
        <tr>
            <td class="style11">
                <p>
                    <strong>PERIODICO </strong>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style15">
                <p>
                    <asp:Image ID="Image1" runat="server" Height="132px" 
                        ImageUrl="~/Imagen/periodico-1-e1560064213147.jpg" Width="350px" />
                </p>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <p>
                    <asp:LinkButton ID="LinkButton1" runat="server" 
                    PostBackUrl="~/MantenimientoCategorias.aspx" CssClass="style6">Mantenimiento de Categorias</asp:LinkButton>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <p>
                    <asp:LinkButton ID="LinkButton2" runat="server" 
                    PostBackUrl="~/AgregarArticulo.aspx" CssClass="style6">Agregar Articulo</asp:LinkButton>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <p>
                    <asp:LinkButton ID="LinkButton3" runat="server" 
                    PostBackUrl="~/AgregarAvisoComun.aspx" CssClass="style6">Agregar Aviso Comun</asp:LinkButton>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <p>
                    <asp:LinkButton ID="LinkButton4" runat="server" 
                    PostBackUrl="~/AgregarAvisoDestacado.aspx" CssClass="style6">Agregar Aviso Destacado</asp:LinkButton>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <p>
                    <asp:LinkButton ID="LinkButton5" runat="server" 
                    PostBackUrl="~/ListadoCategorias.aspx" CssClass="style6">Listado Categorias</asp:LinkButton>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <p>
                    <asp:LinkButton ID="LinkButton6" runat="server" 
                    PostBackUrl="~/ListadoDeAvisosXArticulo.aspx" CssClass="style6">Listado Avisos por Articulo</asp:LinkButton>
                </p>
            </td>
        </tr>
        <tr>
            <td class="style13">
                <p>
                    <asp:LinkButton ID="LinkButton7" runat="server" 
                    PostBackUrl="~/ListadoAvisos.aspx" CssClass="style6">Listado Avisos</asp:LinkButton>
                </p>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
