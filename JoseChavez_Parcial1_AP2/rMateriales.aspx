<%@ Page Title="" Language="C#" MasterPageFile="~/Jefa.Master" AutoEventWireup="true" CodeBehind="rMateriales.aspx.cs" Inherits="JoseChavez_Parcial1_AP2.rMateriales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <style type="text/css">
        .auto-style1 {
            width: 215px;
        }
        .auto-style2 {
            width: 323px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width: 100%;">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="IdLabel" runat="server" Text="Id:"></asp:Label>
                <asp:TextBox ID="IdTextBox" runat="server" Width="112px"></asp:TextBox>
                <asp:Button ID="BuscarButton" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
            </td>
            <td class="auto-style2"><asp:Label ID="RazonLabel" runat="server" Text="Descripcion:"></asp:Label>
                <asp:TextBox ID="RazonTextBox" runat="server" Width="229px"></asp:TextBox></td>
            <td><asp:Label ID="FechaLabel" runat="server" Text="Precio:"></asp:Label>
                <asp:TextBox ID="FechaTextBox" runat="server"></asp:TextBox>
               </td>
            
        </tr>
        
        
       
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">
                <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click"  />
                <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click"  />


            </td>
            
        </tr>
    </table>
</asp:Content>
    
