//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CarrierIntegrator
{
    using System;
    using System.Collections.Generic;
    
    public partial class Carreras
    {
        public int id_carrera { get; set; }
        public Nullable<int> fk_area { get; set; }
        public string nombre_carrera { get; set; }
        public string descripcion_carrera { get; set; }
    
        public virtual areas_car areas_car { get; set; }
    }
}
