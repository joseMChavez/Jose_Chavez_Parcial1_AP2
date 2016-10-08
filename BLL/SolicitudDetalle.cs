using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SolicitudDetalle
    {
        public int MaterialesDetalleId { get; set; }
        public string Material { get; set; }
        public int Cantidad { get; set; }
        public float Precio { get; set; }

        public SolicitudDetalle()
        {
            this.MaterialesDetalleId = 0;
            this.Material = "";
            this.Cantidad = 0;
            this.Precio = 0;
        }
        public SolicitudDetalle(string material, int cantidad, float precio)
        {
            
            this.Material = material;
            this.Cantidad = cantidad;
            this.Precio = precio;
        }
    }
}
