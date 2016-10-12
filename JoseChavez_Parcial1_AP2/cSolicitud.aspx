<%@ Page Title="" Language="C#" MasterPageFile="~/Jefa.Master" AutoEventWireup="true" CodeBehind="cSolicitud.aspx.cs" Inherits="JoseChavez_Parcial1_AP2.cSolicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
        <div class="panel panel-success">
            <div class="panel-heading">
                <h3>Consulta de Personas</h3>
            </div>
            <div class="panel-body">

                <div class="form-horizontal col-md-12" role="form">
                    <div class="form-group">
                        <label class="col-md-2 col-sm-4 col-xs-12 control-label input-sm" for="DropDLFiltro">Filtrar por:</label>
                        <div class="col-md-4 col-md-4 col-xs-12">
                            <asp:DropDownList ID="DropDLFiltro" CssClass="form-control input-sm" readOnly="true" runat="server">
                                <asp:ListItem Value="S.SolicitudId">Id</asp:ListItem>
                                <asp:ListItem Value="S.Razon">Razon</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-4 col-xs-12">
                            <asp:TextBox ID="TextBoxFiltro" CssClass="form-control input-sm" runat="server"></asp:TextBox>
                           
                        </div>
                        <div class="col-md-2  col-md-2 col-xs-8">
                            <asp:LinkButton CssClass="btn btn-primary btn-sm" ID="ButtonBuscar" runat="server"  Width="36px" OnClick="ButtonBuscar_Click"><span class="glyphicon glyphicon-search"></span> </asp:LinkButton>
                        </div>
                    </div>

                </div>
                <asp:GridView cssClass=" table table-responsive table-bordered table-hover" ID="GridView1" runat="server">
                    <Columns>
                        <asp:HyperLinkField
                                        DataNavigateUrlFields="ID"
                                        DataNavigateUrlFormatString="rSolicitudes.aspx?ID={0}"
                                        Text="Ver"
                                         ControlStyle-CssClass="label  label-info" />
                       

                    </Columns>
                </asp:GridView>
               
            </div>

            <hr />
            <div class="panel-footer">
            </div>
        </div>
    </div>
</asp:Content>
