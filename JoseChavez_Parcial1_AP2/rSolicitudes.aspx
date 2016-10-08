﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Jefa.Master" AutoEventWireup="true" CodeBehind="rSolicitudes.aspx.cs" Inherits="JoseChavez_Parcial1_AP2.rSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 215px;
        }
        .auto-style2 {
            width: 323px;
        }
        .auto-style3 {
            height: 18px;
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
            <td class="auto-style2"><asp:Label ID="RazonLabel" runat="server" Text="Razon:"></asp:Label>
                <asp:TextBox ID="RazonTextBox" runat="server" Width="258px"></asp:TextBox></td>
            <td><asp:Label ID="FechaLabel" runat="server" Text="Fecha:"></asp:Label>
                <asp:TextBox ID="FechaTextBox" runat="server"></asp:TextBox>
               </td>
            
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="MateriaLabel" runat="server" Text="Materia"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="CantidadLabel" runat="server" Text="Cantidad"></asp:Label>
            </td>
            <td><asp:Label ID="Label1" runat="server" Text="Precio"></asp:Label></td>
            
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:DropDownList ID="MaterialesDropDownList" runat="server" Height="16px" Width="156px"></asp:DropDownList></td>
            <td class="auto-style2">
                <asp:TextBox ID="CantidadTextBox" runat="server"></asp:TextBox>
                &nbsp;</td>
            <td>
                <asp:TextBox ID="PrecioTextBox" runat="server"></asp:TextBox>
                <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click"  />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">
                <asp:GridView ID="MaterialesGridView" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Material" HeaderText="Material" ReadOnly="True" SortExpression="Material" />
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" ReadOnly="True" SortExpression="Cantidad" />
                        <asp:BoundField DataField="Precio" HeaderText="Precio" ReadOnly="True" SortExpression="Precio" />
                    </Columns>

                </asp:GridView>
            </td>
            
            
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style2">
                <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" OnClick="NuevoButton_Click"  />
                <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" OnClick="EliminarButton_Click"  />


            </td>
            <td>
                <asp:TextBox ID="TotalTextBox" runat="server"></asp:TextBox>
            </td>
        </tr>
    </table>
</asp:Content>
