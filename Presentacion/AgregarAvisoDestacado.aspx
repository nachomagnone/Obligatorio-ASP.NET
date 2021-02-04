<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarAvisoDestacado.aspx.cs" Inherits="Presentacion.AgregarAvisoDestacado" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            font-size: xx-large;
            text-decoration: underline;
        }
        .style2
        {
            width: 221px;
        }
        .style3
        {
            width: 555px;
        }
        .style4
        {
            width: 221px;
            height: 22px;
            font-size: large;
            font-weight: bold;
        }
        .style5
        {
            width: 555px;
            height: 22px;
        }
        .style6
        {
            height: 22px;
        }
        .style7
        {
            width: 221px;
            height: 24px;
        }
        .style8
        {
            width: 555px;
            height: 24px;
        }
        .style9
        {
            height: 24px;
        }
        .style10
        {
            width: 221px;
            font-size: large;
            font-weight: bold;
        }
        .style11
        {
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        <strong>Agregar Aviso Destacado</strong></div>
    <table style="width:100%;">
        <tr>
            <td class="style10">
                Categoria:</td>
            <td class="style3">
                <asp:DropDownList ID="cboCategoriaDestacado" runat="server" Width="292px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Articulo:</td>
            <td class="style3">
                <asp:DropDownList ID="cboArticulo" runat="server" Width="292px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                Fecha:</td>
            <td class="style3">
                <asp:Calendar ID="clnFecha" runat="server" Width="292px" BackColor="White" 
                    BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" 
                    DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
                    ForeColor="#003399" Height="250px">
                    <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                    <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
                    <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" 
                        Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
                    <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                    <WeekendDayStyle BackColor="#CCCCFF" />
                </asp:Calendar>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
                Telefonos:</td>
            <td class="style5">
                <asp:TextBox ID="txtTelefonos" runat="server" Width="292px"></asp:TextBox>
            </td>
            <td class="style6">
                <asp:Button ID="btnAgregarTel" runat="server" onclick="btnAgregarTel_Click" 
                    Text="+" Width="110px" CssClass="style11" />
            </td>
        </tr>
        <tr>
            <td class="style7">
                &nbsp;</td>
            <td class="style8">
                &nbsp;</td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:ListBox ID="lstTelefonos" runat="server" Height="130px" Width="292px">
                </asp:ListBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                    Text="Confirmar" Width="106px" CssClass="style11" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
