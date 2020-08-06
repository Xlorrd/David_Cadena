using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Capa_Datos;
using Capa_Negocio;

namespace Capa_View_Surtex
{
    public partial class Registrar_empleado : System.Web.UI.Page
    {
        private Empleado info = new Empleado();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_aceptar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            Empleado data = new Empleado();


            data.Nombre_empleado = txt_nombre.Text;
            data.Apellido_empleado = txt_apellido.Text;
            data.Cedula_empleado = txt_cedula.Text;
            data.id_car = Convert.ToInt32(cargo.Text);
            data.id_dep = Convert.ToInt32(departamento.Text);
         




            Crud_Empleados.Insert_empleado(data);

        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            Obtener_Datos_Persona_Usuario();
        }
        private void Obtener_Datos_Persona_Usuario()
        {
            string cedula = txt_buscar.Text;
            var rs = Crud_Empleados.Buscar_empleado(cedula);
            foreach (var item in rs)
            {
                txt_nombre.Text = rs[0].Nombre;
                txt_apellido.Text = rs[0].Apellido;                
                txt_cedula.Text = Convert.ToString(rs[0].Cedula_empleado);
                //departamento.DataSource = rs[0].Departamento;
                //cargo.DataSource = rs[0].Cargo;
            
            }

        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {
            Eliminar_empleado();
        }
        private void Eliminar_empleado()
        {
            string cedula = txt_buscar.Text;
            Crud_Empleados.delete(cedula);

        }
    }
}