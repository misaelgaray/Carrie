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
    
    public partial class resultado_en_ad
    {
        public int id_resultado { get; set; }
        public Nullable<int> fk_area_pregunta { get; set; }
        public Nullable<int> cantidad_si { get; set; }
        public Nullable<int> cantidad_no { get; set; }
        public Nullable<int> id_session { get; set; }
    
        public virtual areas_car areas_car { get; set; }
        public virtual Tsession Tsession { get; set; }
    }
}