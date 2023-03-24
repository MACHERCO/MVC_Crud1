using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Crud1.Models;
using MVC_Crud1.Models.ViewModel;


namespace MVC_Crud1.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Index()                
        {
            List<ListUsuariosViewModel> lst;

            using (PRUEBAS_CRUDEntities db = new PRUEBAS_CRUDEntities()) //Hacemos uso del contexto de la BBDD
            {
                //obtenemos el listado de los elementos de la tabla

                lst = (from d in db.usuarios
                       select new ListUsuariosViewModel
                       //llenamos la lista con los elementos de la tabla
                       {
                           Id = d.Id,
                           Nombre = d.Nombre,
                           Apellido = d.Apellido,
                           Edad = (int)d.Edad
                       }).ToList();

            }
            //retorna la lista como modelo a mi vista
            return View(lst);
        }

        //vamos a crear el metodo  y la vista para un nuevo registro
        public ActionResult Nuevo()
        {
            return View();//retornamos la vista
        }

        [HttpPost]
        public ActionResult Nuevo(UsuariosViewModel model)
        {
            try
            { //lo primero es validar que el modelo es ok y no esta vacio
                if (ModelState.IsValid)

                {
                    using (PRUEBAS_CRUDEntities db = new PRUEBAS_CRUDEntities()) //Hacemos uso del contexto de la BBDD
                    {
                        var oUsuarios = new usuarios();
                        oUsuarios.Nombre = model.Nombre;
                        oUsuarios.Apellido = model.Apellido;
                        oUsuarios.Edad = model.Edad;

                        db.usuarios.Add(oUsuarios);
                        db.SaveChanges();

                    }
                    return Redirect("/Usuarios");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        //vamos a crear el metodo  y la vista para Editar registro
        public ActionResult Editar(int Id)
        {
            UsuariosViewModel model = new UsuariosViewModel();
            using (PRUEBAS_CRUDEntities db = new PRUEBAS_CRUDEntities()) //Hacemos uso del contexto de la BBDD
            {
                //obtenemos la Id
                var oUsuarios = db.usuarios.Find(Id);
                //Llenamos el modelo
                model.Id = oUsuarios.Id;  
                model.Nombre = oUsuarios.Nombre;
                model.Apellido = oUsuarios.Apellido;
                model.Edad = (int)oUsuarios.Edad;
            }

                return View(model);//retornamos el modelo
        }
        //editar Registro
        [HttpPost]
        public ActionResult Editar(UsuariosViewModel model)
        {
            try
            { //lo primero es validar que el modelo es ok y no esta vacio
                if (ModelState.IsValid)

                {
                    using (PRUEBAS_CRUDEntities db = new PRUEBAS_CRUDEntities()) //Hacemos uso del contexto de la BBDD
                    {
                        var oUsuarios = db.usuarios.Find(model.Id);
                        oUsuarios.Nombre = model.Nombre;
                        oUsuarios.Apellido = model.Apellido;
                        oUsuarios.Edad = model.Edad;

                        db.Entry(oUsuarios).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                    return Redirect("/Usuarios/index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //vamos a crear el metodo  y la vista para eliminar registro
        public ActionResult ELiminar(int Id)
        {
            
            using (PRUEBAS_CRUDEntities db = new PRUEBAS_CRUDEntities()) //Hacemos uso del contexto de la BBDD
            {
                //obtengo elelemento de la tabla que deseo eliminar
                var oUsuarios = db.usuarios.Find(Id);
                //le envio el eliminar
                db.usuarios.Remove(oUsuarios);
                db.SaveChanges();
                
            }

              return Redirect("~/Usuarios/");
        }


    }
}