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
    
    public partial class preguntas_en_at
    {
        public int id_respuesta { get; set; }
        public Nullable<int> fk_pregunta { get; set; }
        public Nullable<int> fk_usuario { get; set; }
        public string respuesta { get; set; }
        public Nullable<int> id_session { get; set; }
    
        public virtual Preguntas Preguntas { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        public virtual Tsession Tsession { get; set; }
    }
}
