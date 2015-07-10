using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;
namespace Datos
{
    public class AccesoDatos
    {
        #region "Usuarios"
        //validación para el login
        public bool verificarUsuario(string usuario, string pass)
        {
            prodeoEntities prod = new prodeoEntities();
            bool userValid = false;
            MD5 md5Hash = MD5.Create();
            string passMd5 = GetMd5Hash(md5Hash, pass);
            var user = (from u in prod.Usuarios
                        where u.nombre == usuario && u.password == passMd5 && u.usuarioActivo == true
                        select u).Count();
            if (user != 0)
            {
                userValid = true;
            }
            else
            {
                userValid = false;
            }
            return userValid;
        }
        public Usuarios obtenerUsuarioPorMail(string mail)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            var usuarioCompleto = (from u in prodeoContext.Usuarios
                                   where u.mail == mail
                                   select u).First();
            return usuarioCompleto;
        }

        public string obtenerMailUsuario(string usuario)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            string mailUsuario = (from u in prodeoContext.Usuarios
                                  where u.nombre == usuario
                                  select u.mail).First();
            return mailUsuario;
        }

        public bool activarUsuario(string email)
        {
            bool resultModif;
            prodeoEntities prodeoContext = new prodeoEntities();

            try
            {
                var usuarioaActivar = (from u in prodeoContext.Usuarios
                                       where u.mail == email
                                       select u).First();
                usuarioaActivar.usuarioActivo = true;
                //prodeoContext.Entry(userSinActiv).State = System.Data.Entity.EntityState.Modified;                
                prodeoContext.SaveChanges();
                resultModif = true;
            }

            catch (Exception ex)
            {
                resultModif = false;
            }

            return resultModif;
        }
        //validación para que no se registre con un usuario que ya existe
        public bool verUsuarioRep(string usuario)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            bool usuarioVal = false;
            var user = (from u in prodeoContext.Usuarios
                        where u.nombre == usuario
                        select u).Count();
            if (user == 0)
            {
                return usuarioVal = true;
            }
            else
            {
                return usuarioVal = false;
            }
        }
        //validación para que no se registre con un mail que ya existe	
        //sirve tambien para comprobar el registro definitivo con el link de activacion
        public bool verEmailRep(string email)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            bool emailVal = false;
            var emailReg = (from e in prodeoContext.Usuarios
                            where e.mail == email
                            select e).Count();
            if (emailReg == 0)
            {
                return emailVal = true;
            }
            else
            {
                return emailVal = false;
            }
        }
        //guarda los datos de registro en la BD
        public int insertarUsuario(string usuario, string pass, string email, string emailCodificado)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            Usuarios nuevoUsuario = new Usuarios();
            MD5 md5Hash = MD5.Create();
            string passMd5 = GetMd5Hash(md5Hash, pass);
            nuevoUsuario.nombre = usuario;
            nuevoUsuario.password = passMd5;
            nuevoUsuario.mail = email;
            nuevoUsuario.usuarioActivo = false;
            nuevoUsuario.codigoVerificacion = emailCodificado;
            prodeoContext.Usuarios.Add(nuevoUsuario);
            return prodeoContext.SaveChanges(); //SaveChanges devuelve el N° de objetos escritos en la BD            
        }

        //Actualizacion de usuario
        public int actualizarUsuario(string userLogueado, string pass)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                Usuarios userAModificar = (from u in prodeoContext.Usuarios
                                           where u.nombre == userLogueado
                                           select u).First();
                MD5 md5Hash = MD5.Create();
                string passMd5 = GetMd5Hash(md5Hash, pass);
                userAModificar.password = passMd5;
                return prodeoContext.SaveChanges();

            }
            catch (Exception e)
            {
                return 0;
            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
        public bool verificarUsusarioRegistrado(string email)
        {
            bool existe = false;
            prodeoEntities prodeoContext = new prodeoEntities();
            var query = (from u in prodeoContext.Usuarios
                         where u.mail == email
                         select u).Count();

            if (query > 0)
            {
                existe = true;
            }
            return existe;
        }
        public string obtenerPermisoUsuario(string usuario, int idProyecto)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            int idUsuario = (from u in prodeoContext.Usuarios
                             where u.nombre == usuario
                             select u.idUsuario).First();
            string permiso = (from pp in prodeoContext.ParticipantesProyectos
                              where pp.idProyecto == idProyecto && pp.idUsuario == idUsuario
                              select pp.permisosAdministrador).First();

            return permiso;
        }
        public List<Usuarios> obtenerListaUsuarios(int idProyecto)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            var query = (from u in prodeoContext.Usuarios
                         join pp in prodeoContext.ParticipantesProyectos on u.idUsuario equals pp.idUsuario
                         where pp.idProyecto == idProyecto
                         select u).ToList();
            return query;
        }

        public bool eliminarCuenta(string usuario)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            bool exito = false;
            int idUsuario = (from u in prodeoContext.Usuarios
                             where u.nombre == usuario
                             select u.idUsuario).First();

            int cantTareas = (from tu in prodeoContext.ParticipantesTareas
                              where tu.idUsuario == idUsuario
                              select tu).Count();
            if (cantTareas == 0)
            {
                List<ParticipantesProyectos> pp = (from paP in prodeoContext.ParticipantesProyectos
                                                   where paP.idUsuario == idUsuario
                                                   select paP).ToList();
                foreach (ParticipantesProyectos part in pp)
                {
                    prodeoContext.ParticipantesProyectos.Remove(part);
                    prodeoContext.SaveChanges();

                    int cant = (from ppro in prodeoContext.ParticipantesProyectos
                                where ppro.idProyecto == part.idProyecto && ppro.idUsuario != idUsuario && ppro.permisosAdministrador == "A"
                                select pp).Count();
                    if(cant == 0)
                    {
                        List<Modulos> listaModulos = (from m in prodeoContext.Modulos
                                                      where m.idProyecto == part.idProyecto
                                                      select m).ToList();
                        foreach (Modulos mo in listaModulos)
                        {
                            mo.Baja = 1;
                            prodeoContext.SaveChanges();
                        }

                        Proyectos encuentraProyectos = (from p in prodeoContext.Proyectos
                                                        where p.idProyecto == part.idProyecto
                                                        select p).First();

                        encuentraProyectos.Baja = 1;
                        prodeoContext.SaveChanges();

                    }
                }
                

                Usuarios user = (from u in prodeoContext.Usuarios
                                 where u.idUsuario == idUsuario
                                 select u).First();
                user.usuarioActivo = false;
                prodeoContext.SaveChanges();
                exito = true;
                return exito;
            }
            else
            {
                List<DatosEliminarCuenta> datosCuentas = (from t in prodeoContext.Tareas
                                                          join pt in prodeoContext.ParticipantesTareas on t.idTarea equals pt.idTarea
                                                          join m in prodeoContext.Modulos on t.idModulo equals m.idModulo
                                                          where pt.idUsuario == idUsuario && t.Baja == 0 && m.Baja == 0
                                                          select new DatosEliminarCuenta { idTarea = t.idTarea, idModulo = t.idModulo, idUsuario = pt.idUsuario, idProyecto = m.idProyecto, idUsuarioCreador = m.idUsuarioCreador }).ToList();

                foreach(DatosEliminarCuenta dc in datosCuentas)
                {
                    if(dc.idUsuarioCreador != idUsuario)
                    {
                        ParticipantesTareas part = (from pt in prodeoContext.ParticipantesTareas
                                                    where pt.idUsuario == idUsuario && pt.idTarea == dc.idTarea
                                                    select pt).First();
                        part.idUsuario = dc.idUsuarioCreador;
                        prodeoContext.SaveChanges();
                    }
                    else
                    {
                        int cant = (from pp in prodeoContext.ParticipantesProyectos
                                    where pp.idProyecto == dc.idProyecto && pp.idUsuario != idUsuario && pp.permisosAdministrador == "A"
                                    select pp).Count();
                        if(cant > 0)
                        {
                            ParticipantesProyectos partP = (from pp in prodeoContext.ParticipantesProyectos
                                                            where pp.idProyecto == dc.idProyecto && pp.idUsuario != idUsuario && pp.permisosAdministrador == "A"
                                                            select pp).First();

                            ParticipantesTareas part = (from pt in prodeoContext.ParticipantesTareas
                                                        where pt.idUsuario == idUsuario && pt.idTarea == dc.idTarea
                                                        select pt).First();
                            part.idUsuario = partP.idUsuario;
                            prodeoContext.SaveChanges();
                        }
                        else
                        {
                            List<Tareas> listaTareas = (from t in prodeoContext.Tareas
                                                  where t.idModulo == dc.idModulo
                                                  select t).ToList();
                            foreach(Tareas ta in listaTareas)
                            {
                                ta.Baja = 1;
                                prodeoContext.SaveChanges();
                            }
                            List<Modulos> listaModulos = (from m in prodeoContext.Modulos
                                                          where m.idProyecto == dc.idProyecto
                                                          select m).ToList();
                            foreach(Modulos mo in listaModulos)
                            {
                                mo.Baja = 1;
                                prodeoContext.SaveChanges();
                            }

                            Proyectos encuentraProyectos = (from p in prodeoContext.Proyectos
                                                              where p.idProyecto == dc.idProyecto
                                                              select p).First();

                            encuentraProyectos.Baja = 1;
                            prodeoContext.SaveChanges();

                        }
                    }
                }

                Usuarios user = (from u in prodeoContext.Usuarios
                                 where u.idUsuario == idUsuario
                                 select u).First();
                user.usuarioActivo = false;
                prodeoContext.SaveChanges();
                exito = true;
                return exito;

            }

            return exito;
        }

        #endregion

        #region "Proyectos"
        public int insertarProyecto(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, string alerta, string usuario, List<string> usuariosAsignados)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            using (var dbContextTransaction = prodeoContext.Database.BeginTransaction())
            {
                try
                {
                    int idUsuario = (from u in prodeoContext.Usuarios
                                     where u.nombre == usuario
                                     select u.idUsuario).First();
                    Proyectos proy = new Proyectos();
                    proy.Nombre = nombre;
                    proy.Descripcion = descrip;
                    proy.FechaCreacion = fechaCreacion;
                    proy.FechaVencimiento = fechaVencimiento;
                    proy.AlertaPrevia = alerta;
                    prodeoContext.Proyectos.Add(proy);
                    prodeoContext.SaveChanges();
                    //Participantes part = new Participantes();
                    //part.idUsuario = idUsuario;
                    //part.PermisosAdministrador = "1";
                    //prodeoContext.Participantes.Add(part);
                    //prodeoContext.SaveChanges();
                    ParticipantesProyectos partProy = new ParticipantesProyectos();
                    partProy.idProyecto = proy.idProyecto;
                    partProy.idUsuario = idUsuario;
                    partProy.permisosAdministrador = "A";
                    prodeoContext.ParticipantesProyectos.Add(partProy);
                    prodeoContext.SaveChanges();

                    foreach (string user in usuariosAsignados)
                    {
                        string mail = user.Split('-')[0];
                        string permiso = user.Split('-')[1];
                        idUsuario = (from u in prodeoContext.Usuarios
                                     where u.mail == mail
                                     select u.idUsuario).First();
                        partProy.idProyecto = proy.idProyecto;
                        partProy.idUsuario = idUsuario;
                        partProy.permisosAdministrador = permiso;
                        prodeoContext.ParticipantesProyectos.Add(partProy);
                        prodeoContext.SaveChanges();
                    }
                    dbContextTransaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
                return 0;
            }
        }
        public int actualizarProyecto(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, string alerta, string usuario, List<string> usuariosAsignados, string idProyecto)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            using (var dbContextTransaction = prodeoContext.Database.BeginTransaction())
            {
                try
                {
                    int idProy = Convert.ToInt32(idProyecto);
                    Proyectos pro = (from p in prodeoContext.Proyectos
                                     where p.idProyecto == idProy
                                     select p).First();
                    pro.Nombre = nombre;
                    pro.Descripcion = descrip;
                    pro.FechaVencimiento = fechaVencimiento;
                    pro.AlertaPrevia = alerta;
                    prodeoContext.SaveChanges();

                    int idUsuario = (from u in prodeoContext.Usuarios
                                     where u.nombre == usuario
                                     select u.idUsuario).First();

                    List<ParticipantesProyectos> partProy = (from pp in prodeoContext.ParticipantesProyectos
                                                             where pp.idProyecto == idProy //&& pp.idUsuario != idUsuario
                                                             select pp).ToList();
                    foreach (ParticipantesProyectos pp in partProy)
                    {
                        prodeoContext.ParticipantesProyectos.Remove(pp);
                    }
                    prodeoContext.SaveChanges();
                    ParticipantesProyectos partProyAdd = new ParticipantesProyectos();
                    foreach (string user in usuariosAsignados)
                    {
                        string mail = user.Split('-')[0];
                        string permiso = user.Split('-')[1];
                        idUsuario = (from u in prodeoContext.Usuarios
                                     where u.mail == mail
                                     select u.idUsuario).First();
                        partProyAdd.idProyecto = idProy;
                        partProyAdd.idUsuario = idUsuario;
                        partProyAdd.permisosAdministrador = permiso;
                        prodeoContext.ParticipantesProyectos.Add(partProyAdd);
                        prodeoContext.SaveChanges();
                    }
                    dbContextTransaction.Commit();
                    return 1;

                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }

            return 0;
        }
        public List<DatosProyecto> obtenerListaProyectos(string usuario)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            int idUsuario = (from u in prodeoContext.Usuarios
                             where u.nombre == usuario
                             select u.idUsuario).First();
            var query = (from p in prodeoContext.Proyectos
                         join usr in prodeoContext.ParticipantesProyectos on p.idProyecto equals usr.idProyecto
                         where usr.idUsuario == idUsuario && p.Baja == 0
                         select new DatosProyecto { Id = p.idProyecto, Nombre = p.Nombre, Permisos = usr.permisosAdministrador, Descripcion = p.Descripcion }).ToList();
            return query;
        }
        public string obtenerNombreProyecto(int idProyecto)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            string nombre = (from p in prodeoContext.Proyectos
                             where p.idProyecto == idProyecto
                             select p.Nombre).First();
            return nombre;
        }
        public Proyectos obtenerDatosProyecto(int idProyecto)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            Proyectos pro = (from p in prodeoContext.Proyectos
                             where p.idProyecto == idProyecto
                             select p).First();

            return pro;
        }
        public List<DatosParticipantesProyecto> obtenerParticipantes(int idProyecto)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            List<DatosParticipantesProyecto> pp = (from p in prodeoContext.ParticipantesProyectos
                                                   join u in prodeoContext.Usuarios on p.idUsuario equals u.idUsuario
                                                   where p.idProyecto == idProyecto
                                                   select new DatosParticipantesProyecto { nombreUsuario = u.mail, permiso = p.permisosAdministrador }).ToList();
            return pp;
        }
 public int eliminarProyecto(int idProyecto)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                Proyectos pro = (from p in prodeoContext.Proyectos
                               where p.idProyecto == idProyecto
                               select p).First();
                pro.Baja = 1;
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }


        #endregion

        #region "Modulos"
        public List<DatosModulo> obtenerListaModulos(string usuario, int proyecto, string permiso)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            int idUsuario = (from u in prodeoContext.Usuarios
                             where u.nombre == usuario
                             select u.idUsuario).First();
            int creador = (from m in prodeoContext.Modulos
                           where m.idUsuarioCreador == idUsuario && m.idProyecto == proyecto && m.Baja == 0
                           select m).Count();
            List<DatosModulo> listaM = new List<DatosModulo>();
            if (creador > 0)
            {
                listaM = (from p in prodeoContext.Modulos
                          where p.idUsuarioCreador == idUsuario && p.idProyecto == proyecto && p.Baja == 0
                          select new DatosModulo { IdModulo = p.idModulo, IdProyecto = p.idProyecto, IdUsuario = p.idUsuarioCreador, Nombre = p.Nombre, Descripcion = p.Descripcion }).ToList();
            }
            else
            {
                switch (permiso)
                {
                    case "A":
                        {
                            listaM = (from p in prodeoContext.Modulos
                                      where p.idProyecto == proyecto && p.Baja == 0
                                      select new DatosModulo { IdModulo = p.idModulo, IdProyecto = p.idProyecto, IdUsuario = p.idUsuarioCreador, Nombre = p.Nombre, Descripcion = p.Descripcion }).ToList();
                            break;
                        }
                    case "C":
                        {
                            listaM = (from t in prodeoContext.ParticipantesTareas
                                      join ta in prodeoContext.Tareas on t.idTarea equals ta.idTarea
                                      join m in prodeoContext.Modulos on ta.idModulo equals m.idModulo
                                      where t.idUsuario == idUsuario && m.idProyecto == proyecto && m.Baja == 0
                                      select new DatosModulo { IdModulo = m.idModulo, IdProyecto = m.idProyecto, IdUsuario = t.idUsuario, Nombre = m.Nombre, Descripcion = m.Descripcion }).Distinct().ToList();

                            break;
                        }
                }
            }

            return listaM;
        }
        public Modulos obtenerDatosModulo(int idModulo)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            Modulos mod = (from m in prodeoContext.Modulos
                           where m.idModulo == idModulo
                           select m).First();
            return mod;
        }
        public int insertarModulo(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, int proyecto, string usuario)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                int idUsuario = (from u in prodeoContext.Usuarios
                                 where u.nombre == usuario
                                 select u.idUsuario).First();
                Modulos modulos = new Modulos();
                modulos.idProyecto = proyecto;
                modulos.Nombre = nombre;
                modulos.Descripcion = descrip;
                modulos.FechaCreacion = fechaCreacion;
                modulos.FechaVencimiento = fechaVencimiento;
                modulos.idUsuarioCreador = idUsuario;
                prodeoContext.Modulos.Add(modulos);
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public int actualizarModulo(int idModulo, string nombre, string descrip, DateTime fechaVencimiento)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                Modulos mod = (from m in prodeoContext.Modulos
                               where m.idModulo == idModulo
                               select m).First();
                mod.Nombre = nombre;
                mod.Descripcion = descrip;
                mod.FechaVencimiento = fechaVencimiento;
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int eliminarModulo(int idModulo)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                Modulos mod = (from m in prodeoContext.Modulos
                               where m.idModulo == idModulo
                               select m).First();
                mod.Baja = 1;
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public int obtenerCantidadModulos(int proyecto)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            int cantidad = (from m in prodeoContext.Modulos
                            where m.idProyecto == proyecto && m.Baja == 0
                            select m).Count();

            return cantidad;

        }

#endregion

        #region "Tareas"
        public int insertarTarea(int idModulo, string nombre, string descrip, string comentario, DateTime fechaCreacion, DateTime fechaVencimiento, int proyecto, string usuario, string avisos, string prioridad, int idUserAsignado)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                int idUsuario = (from u in prodeoContext.Usuarios
                                 where u.nombre == usuario
                                 select u.idUsuario).First();
                Tareas tareas = new Tareas();
                tareas.idModulo = idModulo;
                tareas.Nombre = nombre;
                tareas.Descripcion = descrip;
                tareas.Comentario = comentario;
                tareas.FechaCreacion = fechaCreacion;
                tareas.DireccionGPS = "0.0.0.0";
                tareas.FechaVencimiento = fechaVencimiento;
                tareas.AlertaPrevia = avisos;
                tareas.Prioridad = prioridad;
                tareas.Estado = "Pendiente";
                prodeoContext.Tareas.Add(tareas);
                ParticipantesTareas partTareas = new ParticipantesTareas();
                partTareas.idUsuario = idUserAsignado;
                partTareas.idTarea = tareas.idTarea;
                prodeoContext.ParticipantesTareas.Add(partTareas);
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }
        public int ActualizarTarea(int idTarea, int idModulo, string nombre, string descrip, string comentario, DateTime fechaCreacion, DateTime fechaVencimiento, int proyecto, string usuario, string avisos, string prioridad, int idUserAsignado)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                int idUsuario = (from u in prodeoContext.Usuarios
                                 where u.nombre == usuario
                                 select u.idUsuario).First();
                var tareas = (from t in prodeoContext.Tareas
                              where t.idTarea == idTarea
                              select t).First();
                tareas.idModulo = idModulo;
                tareas.Nombre = nombre;
                tareas.Descripcion = descrip;
                tareas.Comentario = comentario;
                tareas.DireccionGPS = "0.0.0.0";
                tareas.FechaVencimiento = fechaVencimiento;
                tareas.AlertaPrevia = avisos;
                tareas.Prioridad = prioridad;
                var partTareas = (from pt in prodeoContext.ParticipantesTareas
                                  where pt.idTarea == idTarea
                                  select pt).First();
                partTareas.idUsuario = idUserAsignado;
                partTareas.idTarea = tareas.idTarea;
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public int eliminarTarea(int idTarea, string usuario)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                int idUsuario = (from u in prodeoContext.Usuarios
                                 where u.nombre == usuario
                                 select u.idUsuario).First();
                var tareas = (from t in prodeoContext.Tareas
                              where t.idTarea == idTarea
                              select t).First();

                tareas.Baja = 1;
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public List<DatosTarea> obtenerListaTareas(int modulo)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            var query = (from p in prodeoContext.Tareas
                         join t in prodeoContext.ParticipantesTareas on p.idTarea equals t.idTarea
                         join u in prodeoContext.Usuarios on t.idUsuario equals u.idUsuario
                         where p.idModulo == modulo && p.FechaFinalizacion == null && p.Baja == 0
                         select new DatosTarea { IdTarea = p.idTarea, IdModulo = p.idModulo, Nombre = p.Nombre, Descripcion = p.Descripcion, Comentario = p.Comentario, Prioridad = p.Prioridad, Avisos = p.AlertaPrevia, Asignada = u.nombre, FechaLimite = p.FechaVencimiento, Estado = p.Estado }).OrderBy(o => o.FechaLimite).ToList();
            return query;
        }
        public List<DatosTarea> obtenerListaTareasUsuario(int modulo, string usuario)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            int idUsuario = (from u in prodeoContext.Usuarios
                             where u.nombre == usuario
                             select u.idUsuario).First();
            var query = (from p in prodeoContext.Tareas
                         join t in prodeoContext.ParticipantesTareas on p.idTarea equals t.idTarea
                         join u in prodeoContext.Usuarios on t.idUsuario equals u.idUsuario
                         where p.idModulo == modulo && t.idUsuario == idUsuario && p.FechaFinalizacion == null && p.Baja == 0
                         select new DatosTarea { IdTarea = p.idTarea, IdModulo = p.idModulo, Nombre = p.Nombre, Descripcion = p.Descripcion, Comentario = p.Comentario, Prioridad = p.Prioridad, Avisos = p.AlertaPrevia, Asignada = u.nombre, FechaLimite = p.FechaVencimiento, Estado = p.Estado }).OrderBy(o => o.FechaLimite).ToList();
            return query;
        }

        public int finalizarTarea(string horas, string usuario, int idTarea, string comentario)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();
                int idUsuario = (from u in prodeoContext.Usuarios
                                 where u.nombre == usuario
                                 select u.idUsuario).First();
                var tareas = (from t in prodeoContext.Tareas
                              where t.idTarea == idTarea
                              select t).First();

                tareas.Comentario = comentario;
                tareas.FechaFinalizacion = DateTime.Now;
                tareas.Tiempo = Convert.ToInt32(horas);
                tareas.Estado = "Finalizada";
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }

        public Tareas obtenerTareas(int idTarea)
        {
            prodeoEntities context = new prodeoEntities();
            Tareas tarea = (from t in context.Tareas
                            where t.idTarea == idTarea
                            select t).First();
            return tarea;

        }

        #endregion

        #region "Reportes"
        public Reportes.DatosReportes obtenerDatosTareasPorUsuario(int idProyecto)
        {
            //Categorias/nombres en eje x/usuarios
            ArrayList usuarios = new ArrayList();
            ArrayList tareasPendientesVencidas = new ArrayList();
            ArrayList tareasPendientesNoVencidas = new ArrayList();
            ArrayList tareasFinalizadas = new ArrayList();
            ArrayList estados = new ArrayList();
            Reportes.DatosReportes reporteSource = new Reportes.DatosReportes();
            Reportes.Series reporteSerie = new Reportes.Series();
            prodeoEntities prodeoContext = new prodeoEntities();
            var query = (from t in prodeoContext.Tareas
                         join pt in prodeoContext.ParticipantesTareas on t.idTarea equals pt.idTarea
                         join u in prodeoContext.Usuarios on pt.idUsuario equals u.idUsuario
                         join m in prodeoContext.Modulos on t.idModulo equals m.idModulo
                         where m.idProyecto == idProyecto
                         select new TareasPorUsuarios { estado = t.Estado, fechaVemcimiento = t.FechaVencimiento, usuario = u.nombre });
            //, fechaFinalizacion = (t.FechaFinalizacion.GetType() == System.Type.GetType("System.DateTime") ? System.Convert.ToDateTime(t.FechaFinalizacion):Convert.ToDateTime("1900-01-01"))
            estados.Add("Pendientes Vencidas");
            estados.Add("Pendientes No Vencidas");
            estados.Add("Finalizadas");
            foreach (TareasPorUsuarios item in query)
            {
                int indiceUsuario = usuarios.IndexOf(item.usuario);
                if (indiceUsuario < 0)
                {
                    //Todavia no se procesaron tareas del usuario, asi que agregamos al usuario e inicializamos sus tareas
                    usuarios.Add(item.usuario);
                    if (item.estado == "FINALIZADA")
                    {
                        //Tarea Finalizada
                        tareasFinalizadas.Add(1);
                        tareasPendientesNoVencidas.Add(0);
                        tareasPendientesVencidas.Add(0);
                    }
                    else
                    {
                        //Tarea Pendiente
                        //Pendientes debemos analizar si esta vencida o no. Por ahora no aplica.
                        if (DateTime.Compare(DateTime.Now, item.fechaVemcimiento) >= 0)
                        {
                            //Now es posterior al vencimiento. Esta vencida
                            tareasFinalizadas.Add(0);
                            tareasPendientesNoVencidas.Add(0);
                            tareasPendientesVencidas.Add(1);
                        }
                        else
                        {
                            //No esta vencida
                            tareasFinalizadas.Add(0);
                            tareasPendientesNoVencidas.Add(1);
                            tareasPendientesVencidas.Add(0);
                        }
                    }
                }
                else
                {
                    //El usuario ya existe
                    if (item.estado == "FINALIZADA")
                    {
                        //le agregamos una tarea finalizada
                        int cantFinalizadas = Convert.ToInt32(tareasFinalizadas[indiceUsuario]);
                        tareasFinalizadas[indiceUsuario] = cantFinalizadas + 1;
                    }
                    else
                    {
                        //le agregamos una tarea Pendiente
                        if (DateTime.Compare(DateTime.Now, item.fechaVemcimiento) >= 0)
                        {
                            //Now es posterior al vencimiento. Esta vencida
                            int cantPendientesVencidas = Convert.ToInt32(tareasPendientesVencidas[indiceUsuario]);
                            tareasPendientesVencidas[indiceUsuario] = cantPendientesVencidas + 1;
                        }
                        else
                        {
                            //No esta vencida
                            int cantPendientesNoVencidas = Convert.ToInt32(tareasPendientesNoVencidas[indiceUsuario]);
                            tareasPendientesNoVencidas[indiceUsuario] = cantPendientesNoVencidas + 1;
                        }
                        //pendiente analizamos si esta vencida o no
                    }
                }
            }

            reporteSource.Categorias = usuarios;
            reporteSerie = new Reportes.Series();
            reporteSerie.Nombre = "PendientesNoVencidas";
            reporteSerie.Stack = "Pend";
            reporteSerie.Datos = tareasPendientesNoVencidas;
            reporteSource.Series.Add(reporteSerie);

            reporteSerie = new Reportes.Series();
            reporteSerie.Nombre = "PendientesVencidas";
            reporteSerie.Stack = "Pend";
            reporteSerie.Datos = tareasPendientesVencidas;
            reporteSource.Series.Add(reporteSerie);

            reporteSerie = new Reportes.Series();
            reporteSerie.Nombre = "Finalizadas";
            reporteSerie.Stack = "Fin";
            reporteSerie.Datos = tareasFinalizadas;
            reporteSource.Series.Add(reporteSerie);

            return reporteSource;
        }
        public Reportes.DatosReportes obtenerDatosTareasPorModulos(int idProyecto)
        {
            //Categorias/nombres en eje x/usuarios
            ArrayList modulos = new ArrayList();
            ArrayList tareasPendientesVencidas = new ArrayList();
            ArrayList tareasPendientesNoVencidas = new ArrayList();
            ArrayList tareasFinalizadas = new ArrayList();
            ArrayList estados = new ArrayList();
            Reportes.DatosReportes reporteSource = new Reportes.DatosReportes();
            Reportes.Series reporteSerie = new Reportes.Series();
            prodeoEntities prodeoContext = new prodeoEntities();
            var query = (from t in prodeoContext.Tareas
                         join pt in prodeoContext.ParticipantesTareas on t.idTarea equals pt.idTarea
                         join m in prodeoContext.Modulos on t.idModulo equals m.idModulo
                         where m.idProyecto == idProyecto
                         select new TareasPorModulos { estado = t.Estado, fechaVemcimiento = t.FechaVencimiento, modulo = m.Nombre });
            //, fechaFinalizacion = (t.FechaFinalizacion.GetType() == System.Type.GetType("System.DateTime") ? System.Convert.ToDateTime(t.FechaFinalizacion):Convert.ToDateTime("1900-01-01"))
            estados.Add("Pendientes Vencidas");
            estados.Add("Pendientes No Vencidas");
            estados.Add("Finalizadas");
            foreach (TareasPorModulos item in query)
            {
                int indiceUsuario = modulos.IndexOf(item.modulo);
                if (indiceUsuario < 0)
                {
                    //Todavia no se procesaron tareas del usuario, asi que agregamos al usuario e inicializamos sus tareas
                    modulos.Add(item.modulo);
                    if (item.estado == "FINALIZADA")
                    {
                        //Tarea Finalizada
                        tareasFinalizadas.Add(1);
                        tareasPendientesNoVencidas.Add(0);
                        tareasPendientesVencidas.Add(0);
                    }
                    else
                    {
                        //Tarea Pendiente
                        if (DateTime.Compare(DateTime.Now, item.fechaVemcimiento) >= 0)
                        {
                            //Now es posterior al vencimiento. Esta vencida
                            tareasFinalizadas.Add(0);
                            tareasPendientesNoVencidas.Add(0);
                            tareasPendientesVencidas.Add(1);
                        }
                        else
                        {
                            //No esta vencida
                            tareasFinalizadas.Add(0);
                            tareasPendientesNoVencidas.Add(1);
                            tareasPendientesVencidas.Add(0);
                        }
                    }
                }
                else
                {
                    //El usuario ya existe
                    if (item.estado == "FINALIZADA")
                    {
                        //le agregamos una tarea finalizada
                        int cantFinalizadas = Convert.ToInt32(tareasFinalizadas[indiceUsuario]);
                        tareasFinalizadas[indiceUsuario] = cantFinalizadas + 1;
                    }
                    else
                    {
                        //le agregamos una tarea Pendiente


                        //Tarea Pendiente
                        if (DateTime.Compare(DateTime.Now, item.fechaVemcimiento) >= 0)
                        {
                            //Now es posterior al vencimiento. Esta vencida
                            int cantPendientesVencidas = Convert.ToInt32(tareasPendientesVencidas[indiceUsuario]);
                            tareasPendientesVencidas[indiceUsuario] = cantPendientesVencidas + 1;
                        }
                        else
                        {
                            //No esta vencida
                            int cantPendientesNoVencidas = Convert.ToInt32(tareasPendientesNoVencidas[indiceUsuario]);
                            tareasPendientesNoVencidas[indiceUsuario] = cantPendientesNoVencidas + 1;
                        }
                        //pendiente analizamos si esta vencida o no
                    }
                }
            }

            reporteSource.Categorias = modulos;
            reporteSerie = new Reportes.Series();
            reporteSerie.Nombre = "PendientesNoVencidas";
            reporteSerie.Stack = "Pend";
            reporteSerie.Datos = tareasPendientesNoVencidas;
            reporteSource.Series.Add(reporteSerie);

            reporteSerie = new Reportes.Series();
            reporteSerie.Nombre = "PendientesVencidas";
            reporteSerie.Stack = "Pend";
            reporteSerie.Datos = tareasPendientesVencidas;
            reporteSource.Series.Add(reporteSerie);

            reporteSerie = new Reportes.Series();
            reporteSerie.Nombre = "Finalizadas";
            reporteSerie.Stack = "Fin";
            reporteSerie.Datos = tareasFinalizadas;
            reporteSource.Series.Add(reporteSerie);

            return reporteSource;
        }

        public ArrayList obtenerDatosAvanceDelProyecto(int idProyecto)
        {
            //Categorias/nombres en eje x/usuarios
            ArrayList tareasPendientesVencidas = new ArrayList();
            ArrayList tareasPendientesNoVencidas = new ArrayList();
            ArrayList tareasFinalizadas = new ArrayList();
            ArrayList datosReporte = new ArrayList();
            prodeoEntities prodeoContext = new prodeoEntities();
            var query = (from t in prodeoContext.Tareas
                         join pt in prodeoContext.ParticipantesTareas on t.idTarea equals pt.idTarea
                         join u in prodeoContext.Usuarios on pt.idUsuario equals u.idUsuario
                         join m in prodeoContext.Modulos on t.idModulo equals m.idModulo
                         where m.idProyecto == idProyecto
                         select new DatosTarea { IdTarea = t.idTarea, IdModulo = t.idModulo, Nombre = t.Nombre, Descripcion = t.Descripcion, Comentario = t.Comentario, Prioridad = t.Prioridad, Avisos = t.AlertaPrevia, Asignada = u.nombre, FechaLimite = t.FechaVencimiento, Estado = t.Estado }).OrderBy(o => o.FechaLimite).ToList();


            //, fechaFinalizacion = (t.FechaFinalizacion.GetType() == System.Type.GetType("System.DateTime") ? System.Convert.ToDateTime(t.FechaFinalizacion):Convert.ToDateTime("1900-01-01"))
            tareasPendientesVencidas.Add("Pendientes Vencidas");
            tareasPendientesVencidas.Add(0);
            tareasPendientesNoVencidas.Add("Pendientes No Vencidas");
            tareasPendientesNoVencidas.Add(0);
            tareasFinalizadas.Add("Finalizadas");
            tareasFinalizadas.Add(0);

            foreach (DatosTarea item in query)
            {
                //El usuario ya existe
                if (item.Estado == "FINALIZADA")
                {
                    //le agregamos una tarea finalizada
                    int cantFinalizadas = Convert.ToInt32(tareasFinalizadas[1]);
                    tareasFinalizadas[1] = cantFinalizadas + 1;
                }
                else
                {
                    //le agregamos una tarea Pendiente
                    if (DateTime.Compare(DateTime.Now, item.FechaLimite) >= 0)
                    {
                        //Now es posterior al vencimiento. Esta vencida
                        int cantPendientesVencidas = Convert.ToInt32(tareasPendientesVencidas[1]);
                        tareasPendientesVencidas[1] = cantPendientesVencidas + 1;
                    }
                    else
                    {
                        //No esta vencida
                        int cantPendientesNoVencidas = Convert.ToInt32(tareasPendientesNoVencidas[1]);
                        tareasPendientesNoVencidas[1] = cantPendientesNoVencidas + 1;
                    }
                    //pendiente analizamos si esta vencida o no
                }
            }

            datosReporte.Add(tareasPendientesNoVencidas);
            datosReporte.Add(tareasPendientesVencidas);
            datosReporte.Add(tareasFinalizadas);

            return datosReporte;
        }

        #endregion

        #region "Mails"
        public int insertarMail(int idModulo, int idProyecto, int idTarea, string asunto, string detalle, string destinatarios)
        {
            try
            {
                prodeoEntities prodeoContext = new prodeoEntities();

                Mails mail = new Mails();
                mail.idModulo = idModulo;
                mail.idProyecto = idProyecto;
                mail.idTarea = idTarea;
                mail.asunto = asunto;
                mail.destinatarios = destinatarios;
                mail.detalle = detalle;
                mail.enviado = "N";


                prodeoContext.Mails.Add(mail);
                prodeoContext.SaveChanges();
                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        #endregion


    }
}
