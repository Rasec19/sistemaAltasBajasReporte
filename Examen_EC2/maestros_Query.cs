using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_EC2
{
    class maestros_Query
    {
        conexDataContext bdEscuela = new conexDataContext();
        public void GuardarMaestro(string name, string dir)
        {
            Maestros ma = new Maestros();
            ma.Nombre = name;
            ma.Direccion = dir;

            bdEscuela.Maestros.InsertOnSubmit(ma);

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Registro de Materia exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Mostrar(DataGridView data)
        {
            var registros = from valor in bdEscuela.Maestros
                            select valor;
            data.DataSource = registros;
        }

        public void Actualizar(int id, string name, string dir)
        {
            var registros = from valor in bdEscuela.Maestros
                            where valor.ID_Maestros == id
                            select valor;
            foreach (var valor in registros)
            {
                valor.Nombre = name;
                valor.Direccion = dir;
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Cambio exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Eliminar(int id)
        {
            var registros = from valor in bdEscuela.Maestros
                            where valor.ID_Maestros == id
                            select valor;

            foreach (var valor in registros)
            {
                bdEscuela.Maestros.DeleteOnSubmit(valor);
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Maestro eliminado exitosamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
