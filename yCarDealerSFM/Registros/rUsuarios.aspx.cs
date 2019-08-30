using BLL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using yCarDealerSFM.Utilitarios;

namespace yCarDealerSFM.Registros
{
    public partial class rUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            {
                if (!Page.IsPostBack)
                {
                    int id = Utils.ToInt(Request.QueryString["id"]);
                    if (id > 0)
                    {
                        RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                        var registro = repositorio.Buscar(id);

                        if (registro == null)
                        {
                            Utils.ShowToastr(this.Page, "Registro no existe", "Error", "error");
                        }
                        else
                        {
                            LlenaCampos(registro);
                        }
                    }
                }
            }
        }



        protected void Limpiar()
        {
            UsuarioIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ContraseñaTextBox.Text = string.Empty;
            ConfirmarContraseñaTextBox.Text = string.Empty;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected Usuarios LlenaClase(Usuarios usuarios)
        {
            usuarios.UsuarioId = Utils.ToInt(UsuarioIdTextBox.Text);
            usuarios.Nombres = NombresTextBox.Text;
            usuarios.NombreUsuario = NombreUsuarioTextBox.Text;
            usuarios.Contraseña = ContraseñaTextBox.Text;
            usuarios.ConfirmarContraseña = ConfirmarContraseñaTextBox.Text;
            usuarios.TipoUsuario = TipoUsuarioDropDownList.Text;
            bool resultado = DateTime.TryParse(FechaTextBox.Text, out DateTime fecha);
            if (resultado)
                usuarios.Fecha = fecha;
            return usuarios;
        }

        private void LlenaCampos(Usuarios usuarios)
        {
            UsuarioIdTextBox.Text = Convert.ToString(usuarios.UsuarioId);
            NombresTextBox.Text = usuarios.Nombres;
            NombreUsuarioTextBox.Text = usuarios.NombreUsuario;
            ContraseñaTextBox.Text = usuarios.Contraseña;
            ConfirmarContraseñaTextBox.Text = usuarios.ConfirmarContraseña;
            TipoUsuarioDropDownList.Text = usuarios.TipoUsuario;
            FechaTextBox.Text = usuarios.Fecha.ToString();
        }

        protected bool ValidarNombres(Usuarios usuarios)
        {
            bool validar = false;
            Expression<Func<Usuarios, bool>> filtro = p => true;
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            var lista = repositorio.GetList(c => true);
            foreach (var item in lista)
            {
                if (usuarios.NombreUsuario == item.NombreUsuario)
                {
                    Utils.ShowToastr(this.Page, "Este usuario ya ha sido creado", "Error", "error");
                    return validar = true;
                }
            }

            return validar;
        }



        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuarios = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));
            return (usuarios != null);
        }

        protected void GuardarButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            Usuarios usuario = new Usuarios();
            bool paso = false;

            if (IsValid == false)
            {
                Utils.ShowToastr(this.Page, "Revisar todos los campo", "Error", "error");
                return;
            }
            usuario = LlenaClase(usuario);
            if (ValidarNombres(usuario))
            {
                return;
            }
            else
            {

                if (usuario.UsuarioId == 0)
                {

                    if (Utils.ToInt(UsuarioIdTextBox.Text) > 0)
                    {
                        Utils.ShowToastr(this.Page, "UsuarioId debe estar en 0", "Revisar", "error");
                        return
                            ;
                    }
                    else
                    {
                        paso = repositorio.Guardar(usuario);
                        Utils.ShowToastr(this.Page, "Guardado con exito!!", "Guardado", "success");
                        Limpiar();
                    }
                }
                else
                {
                    if (ExisteEnLaBaseDeDatos())
                    {
                        paso = repositorio.Modificar(usuario);
                        Utils.ShowToastr(this.Page, "Modificado con exito!!", "Modificado", "success");
                        Limpiar();
                    }
                    else
                        Utils.ShowToastr(this.Page, "Este usuario no existe", "Error", "error");
                }
            }
        }


        protected void BuscarButton_Click1(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
            var usuario = repositorio.Buscar(Utils.ToInt(UsuarioIdTextBox.Text));

            if (usuario != null)
            {
                Limpiar();
                LlenaCampos(usuario);
                Utils.ShowToastr(this, "Busqueda exitosa", "Exito", "success");
            }
            else
            {
                Utils.ShowToastr(this.Page, "El usuario que intenta buscar no existe", "Error", "error");
                Limpiar();
            }
        }

        protected void EliminarButton_Click1(object sender, EventArgs e)
        {
            if (Utils.ToInt(UsuarioIdTextBox.Text) > 0)
            {
                int id = Convert.ToInt32(UsuarioIdTextBox.Text);
                RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>();
                if (repositorio.Eliminar(id))
                {

                    Utils.ShowToastr(this.Page, "Eliminado con exito!!", "Eliminado", "info");
                }
                else
                    Utils.ShowToastr(this.Page, "Fallo al Eliminar :(", "Error", "error");
                Limpiar();
            }
            else
            {
                Utils.ShowToastr(this.Page, "No se pudo eliminar, usuario no existe", "error", "error");
            }
        }

    }
}
