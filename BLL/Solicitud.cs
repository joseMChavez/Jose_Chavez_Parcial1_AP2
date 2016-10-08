using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class Solicitud : ClaseMaestra
    {
        public int SolicitudId { get; set; }
        public string Razon { get; set; }
        public string Fecha { get; set; }
        public float Total { get; set; }
        public List<SolicitudDetalle> Detalle { get; set; }
        public Solicitud()
        {
            this.SolicitudId = 0;
            this.Razon = "";
            this.Fecha = "";
            this.Total = 0;
            this.Detalle = new List<SolicitudDetalle>();
        }
        public void AgregarMateriales(string material, int cantidad, float precio)
        {
            Detalle.Add(new SolicitudDetalle(material, cantidad,precio));
        }

        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            int retorno = 0;
            try
            {
                int.TryParse(conexion.ObtenerValor(string.Format("insert into Solicitud(Razon,Fecha,Total) values('{0}','{1}',{2}); SELECT SCOPE_IDENTITY()", this.Razon,this.Fecha,this.Total)).ToString(), out retorno);
                
                if (retorno>0)
                {
                    foreach (SolicitudDetalle material in Detalle)
                    {
                        conexion.Ejecutar(string.Format("insert into SolicitudDetalle(SolicitudId,Material,Cantidad,Precio) values({0},'{1}',{2},{3})", retorno,material.Material,material.Cantidad, material.Precio));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno > 0;
        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("update Solicitud set Razon='{0}',Fecha='{1}',Total={2} where SolicitudId={3}", this.Razon,this.Fecha,this.Total,this.SolicitudId));
                if (retorno)
                {
                    conexion.Ejecutar(string.Format("delete from SolicitudDetalle where SolicitudId={0}", this.SolicitudId));
                    foreach (SolicitudDetalle material in Detalle)
                    {
                        conexion.Ejecutar(string.Format("insert into SolicitudDetalle(SolicitudId,Material,Cantidad,Precio) values({0},'{1}',{2},{3})", this.SolicitudId, material.Material, material.Cantidad,material.Precio));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                
                    retorno = conexion.Ejecutar(string.Format("delete from SolicitudDetalle where SolicitudId={0};" + "delete from Solicitud where SolicitudId={0}", this.SolicitudId));
                   
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return retorno;
        }
        public override bool Buscar(int IdBuscado)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();
            DataTable detalle = new DataTable();
            try
            {
                dt = conexion.ObtenerDatos(string.Format("select * from Solicitud where SolicitudId={0}", IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.SolicitudId = (int)dt.Rows[0]["SolicitudId"];
                    this.Razon = dt.Rows[0]["Razon"].ToString();
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.Total = (float)Convert.ToDecimal(dt.Rows[0]["Total"].ToString());

                    detalle = conexion.ObtenerDatos(string.Format("select * from SolicitudDetalle where SolicitudId={0}", this.SolicitudId));
                    foreach (DataRow row in detalle.Rows)
                    {
                        AgregarMateriales(row["Material"].ToString(), (int)row["Cantidad"],(float)Convert.ToDecimal(row["Precio"].ToString()));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return dt.Rows.Count > 0;
        }
        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable dt = new DataTable();

            return dt = conexion.ObtenerDatos(string.Format("select " + Campos + " from Solicitud where" + Condicion + Orden));
        }
    }
}
