﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;

namespace BLL
{
    public class Materiales : ClaseMaestra
    {

        public int MaterialesId { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }

       

        public Materiales()
        {
            this.MaterialesId = 0;
            this.Descripcion = "";
            this.Precio = 0;
        }
        public override bool Insertar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {
                retorno = conexion.Ejecutar(string.Format("Insert Into Materiales(Descripcion,Precio) values('{0}',{1})", this.Descripcion, this.Precio));
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return retorno;

        }

        public override bool Editar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {

                retorno = conexion.Ejecutar(String.Format(" Update Materiales set Descripcion = '{0}', Precio={1} where MaterialesId = {2} ", this.Descripcion, this.Precio,this.MaterialesId));

            }
            catch (Exception exc)
            {
                throw exc;
            }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDb conexion = new ConexionDb();
            bool retorno = false;
            try
            {

                retorno = conexion.Ejecutar(String.Format(" delete from Materiales where MaterialesId = {0}  ", this.MaterialesId));

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
            DataTable datatable = new DataTable();
            try
            {
                datatable = conexion.ObtenerDatos(string.Format("select * from Materiales where MaterialesId= {0}", IdBuscado));
                if (datatable.Rows.Count > 0)
                {
                    this.MaterialesId = (int)datatable.Rows[0]["MaterialesId"];
                    this.Descripcion = datatable.Rows[0]["Descripcion"].ToString();
                    this.Precio = (float)Convert.ToDecimal(datatable.Rows[0]["Precio"].ToString());
                }

            }
            catch (Exception exc)
            {

                throw exc;
            }
            return datatable.Rows.Count > 0;

        }
        public bool BuscarDescripcion(string DescripcionBuscada)
        {
            ConexionDb conexion = new ConexionDb();
            DataTable datatable = new DataTable();
            try
            {
                datatable = conexion.ObtenerDatos(string.Format("select * from Materiales where Descripcion= '" + DescripcionBuscada + "'"));
            }
            catch (Exception exc)
            {

                throw exc;
            }
            return datatable.Rows.Count > 0;

        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDb conexion = new ConexionDb();
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Order by  " + Orden;

            return conexion.ObtenerDatos("Select " + Campos + " From Materiales Where " + Condicion + Orden);
        }
    }
}
