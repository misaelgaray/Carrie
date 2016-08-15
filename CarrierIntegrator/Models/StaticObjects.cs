using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarrierIntegrator.Models
{
    public class StaticObjects
    {
        public static Tsession session(int id_usuario, DateTime fecha_session)
        {
            Tsession sess = new Tsession();
            sess.id_usuario = id_usuario;
            sess.fecha_sesion = fecha_session;
            return sess;
        }

        public static preguntas_en_ad Preguntas_En_Ad(int id_pregunta, int id_usuario, string respuesta, int token)
        {
            preguntas_en_ad ad = new preguntas_en_ad();
            ad.fk_pregunta = id_pregunta;
            ad.fk_usuario = id_usuario;
            ad.respuesta = respuesta;
            ad.id_session = token;

            return ad;
        }

        public static preguntas_en_at Preguntas_En_At(int id_pregunta, int id_usuario, string respuesta, int token)
        {
            preguntas_en_at ad = new preguntas_en_at();
            ad.fk_pregunta = id_pregunta;
            ad.fk_usuario = id_usuario;
            ad.respuesta = respuesta;
            ad.id_session = token;

            return ad;
        }

        public static Usuarios NewUsuarios(string nombre, string correo,string pass)
        {
            Usuarios user = new Usuarios();
            user.nombre_usuario = nombre;
            user.correo_usuario = correo;
            user.pass_usuario = pass;

            return user;
        }
    }
}