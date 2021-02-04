<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoAvisos.aspx.cs" Inherits="Presentacion.ListadoAvisos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #form1
        {
            text-align: center;
        }
        .style1
        {
            text-decoration: underline;
            font-size: xx-large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center; margin-left: 40px;" class="style1">
    
        <strong>Listado Avisos<br />
        <br />
        <asp:DropDownList ID="cboListado" runat="server" 
            onselectedindexchanged="cboListado_SelectedIndexChanged" 
            style="margin-left: 0px" Width="321px">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Button ID="btnDesplegar" runat="server" Height="47px" 
            onclick="btnDesplegar_Click" style="font-weight: 700" Text="Desplegar" 
            Width="106px" />
        <br />
        <br />
        </strong></div>
    <asp:ListBox ID="lstAvisos" runat="server" Height="272px" 
        onselectedindexchanged="lstAvisos_SelectedIndexChanged" Width="1245px">
    </asp:ListBox>
    <br />
    <br />
    <asp:Label ID="lblError" runat="server"></asp:Label>
    <br />
    <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
    </form>
</body>
</html>
