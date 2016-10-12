using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace JoseChavez_Parcial1_AP2
{
    public partial class cSolicitud : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void Mostrar(Solicitud solicitud)
        {
            string filtro = "";
            if (string.IsNullOrWhiteSpace(TextBoxFiltro.Text))
            {
                filtro = "1=1";
            }
            else
            {
                if (DropDLFiltro.SelectedIndex == 0)
                {
                    filtro = "S.SolicitudId = " + TextBoxFiltro.Text;
                }
                else
                {
                    filtro = DropDLFiltro.SelectedValue + " like '%" + TextBoxFiltro.Text + "%'";
                }
            }
            GridView1.DataSource = solicitud.Listado("S.SolicitudId as Id, S.Razon, S.Fecha, SD.Material, SD.Cantidad, SD.Precio, S.Total ", filtro, "");
            GridView1.DataBind();
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e)
        {
            Solicitud solicitud = new Solicitud();
            Mostrar(solicitud);
        }
    }
}