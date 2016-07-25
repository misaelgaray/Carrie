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

        
        public IEnumerable<Carreras> EncadenamientoAdelante(int token)
        {
            var respuestas = from resp in db.preguntas_en_ad where resp.id_session == token select resp;
            int area1=0, area2 = 0, area3 = 0, area4 = 0, area5 = 0;


            foreach (var respuesta in respuestas)
            {
                //Buscamos a que area pertenece el area pertenece la pregunta respondida
                var seatch_area = (from busc in db.pregunta_area where busc.fk_pregunta == respuesta.fk_pregunta select busc.fk_area).Single();
                //Checamos a que area pertenece la respuesta y si la respuesta fue si la agregamos al contado
                if (seatch_area ==1 && respuesta.respuesta == "si")
                {
                    area1++;
                }else if(seatch_area == 2 && respuesta.respuesta == "si")
                {
                    area2++;
                }
                else if (seatch_area == 3 && respuesta.respuesta == "si")
                {
                    area2++;
                }
                else if (seatch_area == 4 && respuesta.respuesta == "si")
                {
                    area2++;
                }
                else if (seatch_area == 5 && respuesta.respuesta == "si")
                {
                    area2++;
                }
            }

            int area_mayor = 0;

            if (area1 > area2 && area1 > area3 && area1 > area4 && area1 > area5)
            {
                area_mayor = 1;
            }
            else if (area2 > area1 && area2 > area3 && area2 > area4 && area2 > area5)
            {
                area_mayor = 2;
            }
            else if (area3 > area1 && area3 > area2 && area3 > area4 && area3 > area5)
            {
                area_mayor = 3;
            }
            else if (area4 > area1 && area4 > area2 && area4 > area3 && area4 > area5)
            {
                area_mayor = 4;
            }
            else
            {
                area_mayor = 5;
            }


            return db.Carreras.Where(a => a.fk_area == area_mayor);
        }
    }
}