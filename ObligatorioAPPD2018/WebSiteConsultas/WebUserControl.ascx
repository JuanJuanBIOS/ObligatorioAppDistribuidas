﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>
<style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style5
    {
        width: 226px;
    }
    .style6
    {
        width: 151px;
        text-align: left;
    }
    .style7
    {
        width: 151px;
        text-align: left;
        height: 26px;
    }
    .style8
    {
        width: 226px;
        height: 26px;
    }
</style>

<p>
        <asp:Label ID="LblError" runat="server" ForeColor="Red"></asp:Label>
</p>
<h3>
    Viaje</h3>
<table class="style1">
    <tr>
        <td class="style6">
            Número de viaje:</td>
        <td class="style5">
            <asp:TextBox ID="TBNumViaje" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Companía:</td>
        <td class="style5">
            <asp:TextBox ID="TBCompania" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Destino:</td>
        <td class="style5">
            <asp:TextBox ID="TBDestino" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Fecha de partida:</td>
        <td class="style5">
            <asp:TextBox ID="TBFechPar" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Fecha de arribo:</td>
        <td class="style5">
            <asp:TextBox ID="TBFechArr" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Asientos:</td>
        <td class="style5">
            <asp:TextBox ID="TBAsientos" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Empleado:</td>
        <td class="style5">
            <asp:TextBox ID="TBEmpleado" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            <asp:Label ID="LblParadas" runat="server" Text="Paradas:"></asp:Label>
        </td>
        <td class="style5">
            <asp:TextBox ID="TBParadas" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style7">
            <asp:Label ID="LblServicio" runat="server" Text="Servicio a bordo:"></asp:Label>
        </td>
        <td class="style8">
            <asp:DropDownList ID="DDServicio" runat="server" Enabled="False" 
                Width="128px" BackColor="#EBEBE4">
                <asp:ListItem>No</asp:ListItem>
                <asp:ListItem>Si</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="style6">
            <asp:Label ID="LblDocumentacion" runat="server" Text="Documentación:"></asp:Label>
        </td>
        <td class="style5">
            <asp:TextBox ID="TBDocumentacion" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
</table>
<p>
    &nbsp;</p>
<h3>
    Companía</h3>
<table class="style1">
    <tr>
        <td class="style6">
            Nombre de Companía:</td>
        <td class="style5">
            <asp:TextBox ID="TBNomComp" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Dirección:</td>
        <td class="style5">
            <asp:TextBox ID="TBDirComp" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Teléfono:</td>
        <td class="style5">
            <asp:TextBox ID="TBTelComp" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
</table>
<p>
    &nbsp;</p>
<h3>
    Terminal de destino</h3>
<table class="style1">
    <tr>
        <td class="style6">
            Código:</td>
        <td class="style5">
            <asp:TextBox ID="TBCodigoTer" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            Ciudad:</td>
        <td class="style5">
            <asp:TextBox ID="TBCiudadTer" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6">
            País:</td>
        <td class="style5">
            <asp:TextBox ID="TBPaisTer" runat="server" Enabled="False"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style6" valign="top">
            Facilidades:</td>
        <td class="style5">
            <asp:ListBox ID="LBFacilidadesTer" runat="server" Width="221px" Enabled="False" 
                BackColor="#EBEBE4" EnableViewState="False" Height="181px">
            </asp:ListBox>
        </td>
    </tr>
</table>
