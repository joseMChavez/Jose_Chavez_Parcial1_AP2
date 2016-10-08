using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace JoseChavez_Parcial1_AP2
{
    public partial class rMateriales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Limpiar()
        {
            RazonTextBox.Text = string.Empty;
            FechaTextBox.Text = string.Empty;
            IdTextBox.Text = string.Empty;
        }
        private void CargarDatos(Materiales material)
        {
            int Id=0;
            float precio = 0;
            float.TryParse(FechaTextBox.Text, out precio);
            int.TryParse(IdTextBox.Text, out Id);
            material.MaterialesId = Id;
            material.Descripcion = RazonTextBox.Text;
            material.Precio = precio;

        }
        private void DevolverDatos(Materiales material) {
            IdTextBox.Text = material.MaterialesId.ToString();
            RazonTextBox.Text = material.Descripcion;
            FechaTextBox.Text = material.Precio.ToString();
        }


        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            RazonTextBox.Focus();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            Materiales material = new Materiales();

            try
            {
                if (string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (!string.IsNullOrWhiteSpace(RazonTextBox.Text)&& !string.IsNullOrWhiteSpace(FechaTextBox.Text))
                    {
                        CargarDatos(material);
                        if (material.Insertar())
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
                        CargarDatos(material);
                        if (material.Editar())
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
            Materiales material = new Materiales();
            try
            {
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (!string.IsNullOrWhiteSpace(RazonTextBox.Text) && !string.IsNullOrWhiteSpace(FechaTextBox.Text))
                    {
                        CargarDatos(material);
                        if (material.Eliminar())
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
            Materiales material = new Materiales();
            int id = 0;
            int.TryParse(IdTextBox.Text, out id);
            try
            {
                if (!string.IsNullOrWhiteSpace(IdTextBox.Text))
                {
                    if (material.Buscar(id))
                    {
                        DevolverDatos(material);
                        RazonTextBox.Focus();
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}