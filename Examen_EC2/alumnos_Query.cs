using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_EC2
{
    class alumnos_Query
    {
        conexDataContext bdEscuela = new conexDataContext();
        public void GuardarAlumno(string name, int car)
        {
            Alumnos a = new Alumnos();
            a.Nombre = name;
            a.Carrera = car;

            bdEscuela.Alumnos.InsertOnSubmit(a);

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Registro de Alumno exitoso");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

  
        public void Actualizar(int id, string name, int car)
        {
            var registros = from valor in bdEscuela.Alumnos
                            where valor.ID_Alumno == id
                            select valor;
            foreach (var valor in registros)
            {
                valor.Nombre = name;
                valor.Carrera = car;
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
            var registros = from valor in bdEscuela.Alumnos
                            where valor.ID_Alumno == id
                            select valor;

            foreach (var valor in registros)
            {
                bdEscuela.Alumnos.DeleteOnSubmit(valor);
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Alumno eliminado exitosamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
