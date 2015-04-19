using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
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
                    
                    foreach(string user in usuariosAsignados)
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
        public List<DatosProyecto> obtenerListaProyectos(string usuario)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            int idUsuario = (from u in prodeoContext.Usuarios
                             where u.nombre == usuario
                             select u.idUsuario).First();
            var query = (from p in prodeoContext.Proyectos
                         join usr in prodeoContext.ParticipantesProyectos on p.idProyecto equals usr.idProyecto
                         where usr.idUsuario == idUsuario
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

#endregion

#region "Modulos"
        public List<DatosModulo> obtenerListaModulos(string usuario, int proyecto, string permiso)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            int idUsuario = (from u in prodeoContext.Usuarios
                             where u.nombre == usuario
                             select u.idUsuario).First();
            int creador = (from m in prodeoContext.Modulos
                           where m.idUsuarioCreador == idUsuario && m.idProyecto == proyecto
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
            catch(Exception e)
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
            catch(Exception ex)
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
                         where p.idModulo == modulo && t.idUsuario == idUsuario && p.FechaFinalizacion == null
                         select new DatosTarea { IdTarea = p.idTarea, IdModulo = p.idModulo, Nombre = p.Nombre, Descripcion = p.Descripcion, Comentario = p.Comentario, Prioridad = p.Prioridad, Avisos = p.AlertaPrevia, Asignada = u.nombre, FechaLimite = p.FechaVencimiento, Estado = p.Estado }).OrderBy(o=>o.FechaLimite).ToList();
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
            prodeoContext.SaveChanges();
            return 1;
            }
            catch(Exception ex)
            {
                return 0;
            }

        }

#endregion

#region "Reportes"
        public DataTable simularDatosTareasPorUsuario()
        {
            DataTable tabla = new DataTable();
            DataColumn columna = new DataColumn();
            DataRow fila;
            columna.ColumnName = "usuario";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "estado";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "condicionvencimiento";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "cantidad";
            tabla.Columns.Add(columna);

            fila = tabla.NewRow();
            fila["usuario"] = "Rodolfo";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "NoVencida";
            fila["cantidad"] = 30;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Rodolfo";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "Vencida";
            fila["cantidad"] = 20;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Rodolfo";
            fila["estado"] = "Finalizado";
            fila["condicionvencimiento"] = "";
            fila["cantidad"] = 10;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Jose";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "NoVencida";
            fila["cantidad"] = 35;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Jose";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "Vencida";
            fila["cantidad"] = 25;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["usuario"] = "Jose";
            fila["estado"] = "Finalizado";
            fila["condicionvencimiento"] = "";
            fila["cantidad"] = 15;
            tabla.Rows.Add(fila);

            return tabla;
        }
        public DataTable simularDatosTareasPorModulo()
        {
            DataTable tabla = new DataTable();
            DataColumn columna = new DataColumn();
            DataRow fila;
            columna.ColumnName = "modulo";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "estado";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "condicionvencimiento";
            tabla.Columns.Add(columna);
            columna = new DataColumn();
            columna.ColumnName = "cantidad";
            tabla.Columns.Add(columna);

            fila = tabla.NewRow();
            fila["modulo"] = "Comprar Elementos";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "NoVencida";
            fila["cantidad"] = 30;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Comprar Elementos";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "Vencida";
            fila["cantidad"] = 20;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Comprar Elementos";
            fila["estado"] = "Finalizado";
            fila["condicionvencimiento"] = "";
            fila["cantidad"] = 10;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Pintado";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "NoVencida";
            fila["cantidad"] = 35;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Pintado";
            fila["estado"] = "Pendiente";
            fila["condicionvencimiento"] = "Vencida";
            fila["cantidad"] = 25;
            tabla.Rows.Add(fila);

            fila = tabla.NewRow();
            fila["modulo"] = "Pintado";
            fila["estado"] = "Finalizado";
            fila["condicionvencimiento"] = "";
            fila["cantidad"] = 15;
            tabla.Rows.Add(fila);

            return tabla;
        }
        
#endregion






   //public List<TareasPorUsuarios> obtenerDatosDeTareaPorUsuario(string usuario)
        //{
        //    prodeoEntities prodeoContext = new prodeoEntities();
        //    var query = (from u in prodeoContext.Usuarios
        //                 join pt in prodeoContext.ParticipantesTareas on u.idUsuario equals pt.idUsuario
        //                 join t in prodeoContext.Tareas on pt.idTarea equals t.idTarea
        //                 where u.nombre == usuario
        //                 select new DatosTarea { IdTarea = p.idTarea, IdModulo = p.idModulo, Nombre = p.Nombre, Descripcion = p.Descripcion, Prioridad = p.Prioridad, Asignada = u.nombre, FechaLimite = p.FechaVencimiento.ToString(), Estado = p.Estado }).ToList();
        //    return query;
        //}


    }
}
