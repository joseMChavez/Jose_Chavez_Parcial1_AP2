using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace JoseChavez_Parcial1_AP2
{
    public partial class rSolicitudes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();
            DataTable dt = new DataTable();
            int id = 0;
            if (!IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                FechaTextBox.ReadOnly = true;
                CargarDDList();
                
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Material"), new DataColumn("Cantidad"), new DataColumn("Precio") });
                Session["Materiales"] = dt;

                if (Request.QueryString["ID"]!=null)
                {
                    int.TryParse(Request.QueryString["ID"].ToString(), out id);
                   
                        if (solicitud.Buscar(id))
                        {
                            if (MaterialesGridView.Rows.Count == 0)
                            {
                                DevolverDatos(solicitud);
                            }
                            
                            RazonTextBox.Focus();
                            // IdTextBox.Text = string.Empty;
                        }
                    
                }
            }
            
        }

        public void Limpiar()
        {
            IdTextBox.Text = string.Empty;
            RazonTextBox.Text = string.Empty;
            FechaTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            MaterialesDropDownList.SelectedIndex = 0;
            DataTable dt = new DataTable();
            MaterialesGridView.DataSource = null;
            MaterialesGridView.DataBind();
            PrecioTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
          
        }
        private void CargarDDList()
        {
            Materiales material = new Materiales();
            MaterialesDropDownList.DataSource = material.Listado("Descripcion", "1=1", "");
            MaterialesDropDownList.DataTextField = "Descripcion";
            MaterialesDropDownList.DataValueField = "Descripcion";
            MaterialesDropDownList.DataBind();
            CargarPrecio();
            
        }
     
        private void CargarPrecio()
        {
            Materiales material = new Materiales();
            PrecioDropDownList.DataSource = material.Listado("Precio", "Descripcion= '" + MaterialesDropDownList.Text + "'", "");
            PrecioDropDownList.DataTextField = "Precio";
            PrecioDropDownList.DataValueField = "Precio";
            PrecioDropDownList.DataBind();
            PrecioTextBox.Text = PrecioDropDownList.Text;
        }
        public void LLenarDatos(Solicitud solicitud) {
            int Id = 0;
            float total=0;
            float.TryParse(TotalTextBox.Text, out total);
            int.TryParse(IdTextBox.Text, out Id);
            solicitud.SolicitudId = Id;
            solicitud.Razon = RazonTextBox.Text;
            solicitud.Fecha = FechaTextBox.Text;
            solicitud.Total = total;

            foreach (GridViewRow row in MaterialesGridView.Rows)
            {
                solicitud.AgregarMateriales(row.Cells[0].Text, int.Parse(row.Cells[1].Text), (float)Convert.ToDecimal(row.Cells[2].Text));
            }

        }
        public void DevolverDatos(Solicitud solicitud)
        {
            IdTextBox.Text = solicitud.SolicitudId.ToString();
            RazonTextBox.Text = solicitud.Razon;
            FechaTextBox.Text = solicitud.Fecha;
            TotalTextBox.Text = solicitud.Total.ToString();
            
            foreach (var item in solicitud.Detalle)
            {
                DataTable dt = (DataTable)Session["Materiales"];
                dt.Rows.Add(item.Material, item.Cantidad, item.Precio);
                Session["Materiales"] = dt;
                MaterialesGridView.DataSource = Session["Materiales"];
                MaterialesGridView.DataBind();
            }

        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            RazonTextBox.Focus();
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            float total = 0, suma = 0, resultado=0;

            try
            {
                if (!string.IsNullOrWhiteSpace(CantidadTextBox.Text) && !string.IsNullOrWhiteSpace(PrecioTextBox.Text))
                {
                    DataTable dt = (DataTable)Session["Materiales"];
                    dt.Rows.Add(MaterialesDropDownList.SelectedValue, CantidadTextBox.Text, PrecioTextBox.Text);
                    Session["Materiales"] = dt;
                    MaterialesGridView.DataSource = dt;
                    MaterialesGridView.DataBind();

                    foreach (GridViewRow row in MaterialesGridView.Rows)
                    {
                        suma = suma + (float)Convert.ToDecimal(row.Cells[1].Text);
                        total = total + (float)Convert.ToDecimal(row.Cells[2].Text);
                    }
                    resultado = suma * total;
                    PrecioTextBox.Text = string.Empty;
                    CantidadTextBox.Text = string.Empty;
                    TotalTextBox.Text = resultado.ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();
            try
            {

                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (!string.IsNullOrWhiteSpace(RazonTextBox.Text) && !string.IsNullOrWhiteSpace(FechaTextBox.Text))
                    {
                        LLenarDatos(solicitud);
                        if (solicitud.Insertar())
                        {
                            Limpiar();
                            RazonTextBox.Focus();
                        }
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(RazonTextBox.Text) && !string.IsNullOrWhiteSpace(FechaTextBox.Text))
                    {
                        LLenarDatos(solicitud);
                        if (solicitud.Editar())
                        {
                            Limpiar();
                            RazonTextBox.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();
            try
            {
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (!string.IsNullOrWhiteSpace(RazonTextBox.Text) && !string.IsNullOrWhiteSpace(FechaTextBox.Text))
                    {
                        LLenarDatos(solicitud);
                        if (solicitud.Eliminar())
                        {
                            Limpiar();
                            RazonTextBox.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            //Solicitud solicitud = new Solicitud();
            //int id = 0;
            //int.TryParse(IdTextBox.Text, out id);
            //try
            //{
            //    if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
            //    {
            //        if (solicitud.Buscar(id))
            //        {
            //            if (MaterialesGridView.Rows.Count==0)
            //            {
            //                DevolverDatos(solicitud);
            //            }
            //            else
            //            {
            //                NuevoButton_Click(sender, e);
            //            }


            //            RazonTextBox.Focus();
            //           // IdTextBox.Text = string.Empty;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            Response.Redirect("cSolicitud.aspx");
        }

        protected void MaterialesDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarPrecio();
        }
    }

}