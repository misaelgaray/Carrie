using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrierIntegrator.Models
{
    public class RespuestasViewModel
    {
        public IEnumerable<preguntas_en_ad> respuestas { get; set; }
    }
}