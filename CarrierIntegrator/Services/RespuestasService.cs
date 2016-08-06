using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarrierIntegrator.Models;

namespace CarrierIntegrator.Services
{
    public class RespuestasService
    {
        CarreerDataBaseEntities1 db;

        public RespuestasService()
        {
            db = new CarreerDataBaseEntities1();
        }

        public RespuestasService(CarreerDataBaseEntities1 db)
        {
            this.db = db;
        }

        public void AddRespuesta(int id_pegunta, string respuesta, int token)
        {
            Tsession user = db.Tsession.Find(token);
            preguntas_en_ad ead = StaticObjects.Preguntas_En_Ad(id_pegunta, Convert.ToInt32(user.id_usuario), respuesta, token);
            db.preguntas_en_ad.Add(ead);

            try
            {
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        
        public int ConteoArea(int? id_usuario, string respuesta)
        {
            var conteo_area = db.spConteoArea(id_usuario, respuesta);

            return Convert.ToInt32(conteo_area);
        }

        public List<spMostrarCarreras_Result> MostrarCarrera(int? area)
        {
            var carreras = db.spMostrarCarreras(area);
            List<spMostrarCarreras_Result> list = carreras.ToList();
            return list;
        }


        public List<spForward_tracking_Result>  FowardTracking(int? id_usuario, string respuesta)
        {
            var  carrea = db.spForward_tracking(id_usuario, respuesta);
            List<spForward_tracking_Result> list = carrea.ToList();
            return list;  
        }

       
    }
}