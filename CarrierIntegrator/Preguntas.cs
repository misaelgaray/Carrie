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
    
    public partial class Preguntas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Preguntas()
        {
            this.pregunta_area = new HashSet<pregunta_area>();
            this.preguntas_en_ad = new HashSet<preguntas_en_ad>();
            this.preguntas_en_at = new HashSet<preguntas_en_at>();
        }
    
        public int id_pregunta { get; set; }
        public string pregunta { get; set; }
        public Nullable<int> id_carrera { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<pregunta_area> pregunta_area { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<preguntas_en_ad> preguntas_en_ad { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<preguntas_en_at> preguntas_en_at { get; set; }
        public virtual Carreras Carreras { get; set; }
    }
}
