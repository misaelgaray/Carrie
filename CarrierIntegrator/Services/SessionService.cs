﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarrierIntegrator.Models;

namespace CarrierIntegrator.Services
{
    public class SessionService
    {
        CarreerDataBaseEntities1 db = new CarreerDataBaseEntities1();

        

        public int LogOn(string user, string mail, string pass)
        {
            int session = 0;
            Usuarios new_user = StaticObjects.NewUsuarios(user, mail, pass);
            db.Usuarios.Add(new_user);

            try
            {
                db.SaveChanges();
                session = LogIn(mail, pass);
            }
            catch
            {
                return session;
            }

            return session;
        }

        public int LogIn(string user, string pass)
        {
            int session = 0;
            try
            {
                var sess = (from val in db.Usuarios where 
                           val.correo_usuario == user && val.pass_usuario == pass
                           select val).Single();
                if(sess != null)
                {
                    //By default session is Misaels Session
                    Tsession new_session = StaticObjects.session(sess.id_usuario, DateTime.Now);
                    db.Tsession.Add(new_session);

                    try
                    {
                        db.SaveChanges();
                        var result = (from ses in db.Tsession select ses.id_session).Max();
                        session = result;
                    }
                    catch
                    {
                        throw;
                    }

                }
            }
            catch
            {
                return session;
            }

            return session;
        }
    }
}