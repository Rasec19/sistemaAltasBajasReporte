using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen_EC2
{
    class cargasAlumnos_Querys
    {
        conexDataContext bdEscuela = new conexDataContext();
        public void GuardarCargaAlumno(int name, int car, int mat, int prof)
        {
            Cargas_Alumnos ca = new Cargas_Alumnos();
            ca.Nombre = name;
            ca.Carrera = car;
            ca.Materia = mat;
            ca.Profesor = prof;

            bdEscuela.Cargas_Alumnos.InsertOnSubmit(ca);

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Registro de Carga exitosa");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


        public void Actualizar(int id, int name, int car, int mat, int prof)
        {
            var registros = from valor in bdEscuela.Cargas_Alumnos
                            where valor.ID_Alumno == id
                            select valor;
            foreach (var valor in registros)
            {
                valor.Nombre = name;
                valor.Carrera = car;
                valor.Materia = mat;
                valor.Profesor = prof;
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
            var registros = from valor in bdEscuela.Cargas_Alumnos
                            where valor.ID_Alumno == id
                            select valor;

            foreach (var valor in registros)
            {
                bdEscuela.Cargas_Alumnos.DeleteOnSubmit(valor);
            }

            try
            {
                bdEscuela.SubmitChanges();
                MessageBox.Show("Carga eliminada exitosamente");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
