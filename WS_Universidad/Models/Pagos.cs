//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WS_Universidad.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pagos
    {
        public int PagoID { get; set; }
        public int AlquilerID { get; set; }
        public decimal Monto { get; set; }
        public string TipoPago { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaPago { get; set; }
    
        public virtual Alquileres Alquileres { get; set; }
    }
}
