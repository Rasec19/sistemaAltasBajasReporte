using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_EC2
{
    class usuarios_Query
    {
        conexDataContext bdEscuela = new conexDataContext();

        public void GuardarUsuario(string name, string pass) 
        {
            Usuarios_del_sistema usuarios = new Usuarios_del_sistema();
            usuarios.Nombre = name;
            usuarios.Contraseña = Encrypt.GetSHA256(pass);
            
            bdEscuela.Usuarios_del_sistema.InsertOnSubmit(usuarios);

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Registro de usuario exitoso");
            }
            catch (Exception e) 
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Actualizar(int id, string name, string pass) 
        {
            var registros = from valor in bdEscuela.Usuarios_del_sistema
                            where valor.ID_Usuario == id
                            select valor;
            foreach (var valor in registros)
            {
                valor.Nombre = name;
                valor.Contraseña = pass;
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Actualizacion exitosa");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Eliminar(int id) 
        {
            var registros = from valor in bdEscuela.Usuarios_del_sistema
                            where valor.ID_Usuario == id
                            select valor;

            foreach (var valor in registros)
            {
                bdEscuela.Usuarios_del_sistema.DeleteOnSubmit(valor);
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Usuario eliminado exitosamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Mostrar(DataGridView data) 
        {
            var registros = from valor in bdEscuela.Usuarios_del_sistema
                        select valor;
            data.DataSource = registros;
        }

    }
}
