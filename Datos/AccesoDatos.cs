using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatos
    {
        //validación para el login
        public bool verificarUsuario(string usuario, string pass)
        {
            prodeoEntities prod = new prodeoEntities();
            bool userValid = false;
            MD5 md5Hash = MD5.Create();
            string passMd5 = GetMd5Hash(md5Hash, pass);
            var user = (from u in prod.Usuarios
                        where u.nombre == usuario && u.password == passMd5
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

        public int insertarProyecto(string nombre, string descrip, DateTime fechaCreacion, DateTime fechaVencimiento, string alerta, string usuario)
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

        public List<DatosModulo> obtenerListaModulos(string usuario, int proyecto)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            int idUsuario = (from u in prodeoContext.Usuarios
                             where u.nombre == usuario
                             select u.idUsuario).First();
            var query = (from p in prodeoContext.Modulos
                         where p.idUsuarioCreador == idUsuario && p.idProyecto == proyecto
                         select new DatosModulo { IdModulo = p.idModulo, IdProyecto = p.idProyecto, IdUsuario = p.idUsuarioCreador, Nombre = p.Nombre, Descripcion = p.Descripcion }).ToList();
            return query;
        }

        public List<Usuarios> obtenerListaUsuarios()
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            var query = (from u in prodeoContext.Usuarios
                         select u).ToList();
            return query;
        }

        public List<DatosTarea> obtenerListaTareas(int modulo)
        {
            prodeoEntities prodeoContext = new prodeoEntities();
            var query = (from p in prodeoContext.Tareas
                         join t in prodeoContext.ParticipantesTareas on p.idTarea equals t.idTarea
                         join u in prodeoContext.Usuarios on t.idUsuario equals u.idUsuario
                         where p.idModulo == modulo
                         select new DatosTarea { IdTarea = p.idTarea, IdModulo = p.idModulo, Nombre = p.Nombre, Descripcion = p.Descripcion, Prioridad = p.Prioridad, Asignada = u.nombre, FechaLimite = p.FechaVencimiento.ToString(), Estado = p.Estado }).ToList();
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
