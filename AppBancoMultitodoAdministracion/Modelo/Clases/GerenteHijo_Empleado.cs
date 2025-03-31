using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;
using MySql.Data.MySqlClient;

namespace AppBancoMultitodoAdministracion.Modelo.Clases
{
    class GerenteHijo_Empleado : EmpleadoHijo
    {
        public GerenteHijo_Empleado()
        {
        }

        public GerenteHijo_Empleado(string cedula, string nombres, string apellidos, string correo, string fecha_nacimiento, string departamento) : base(cedula, nombres, apellidos, correo, fecha_nacimiento, departamento)
        {


        }



        public void Generar_Clave_Empleado(String cedula, TextBox txt_cla)
        {

            String minusculas = "abcdefghijklmnopqrstuwxyz";
            String mayusculas = minusculas.ToUpper();
            String numeros = "1234567890";
            String caracteres = "#@_-";

            String cadena = minusculas + mayusculas + numeros + caracteres;




            String may = "[A-Z]+";
            String min = "[a-z]+";
            String num = "[0-9]+";
            String car = "[#@_-]+";

            String clave = "";
            String clave_temp = "";

            Random aleatorio = new Random();


            Boolean permitido = false;

            while(permitido == false)
            {

                for(int i = 0; i < 16; i++)
                {

                    int posicion = aleatorio.Next(cadena.Length);
                    char digito = cadena[posicion];
                    clave_temp += digito;

                }

                if (Regex.IsMatch(clave_temp, min) && Regex.IsMatch(clave_temp, may) && Regex.IsMatch(clave_temp, num) && Regex.IsMatch(clave_temp, car) && clave_temp.Length >= 8 )
                {

                    clave = clave_temp;
                    permitido = true;

                }
                else
                {
                    clave_temp = "";
                    permitido = false;

                }
                
            }


            if (String.IsNullOrEmpty(cedula))
            {
                MessageBox.Show("Por favor ingrese su cedula");

            }
            else
            {

                Boolean ver_emp = repo_emp.Consulta_Verificar_Un_Campo_Tabla_Empleados("cedula" , cedula);

                if(ver_emp == true)
                {


                    Boolean actualizar = repo_emp.Update_Clave_Empleado( clave, "cedula", cedula);
                    if (actualizar == true)
                    {

                        MessageBox.Show("Cedula generada con exito");
                        txt_cla.Text = clave;

                    }

                }
                else
                {
                    MessageBox.Show("La cedula no se encuentra registrada");
                }


            }



        }


        public Boolean Copiar_Clave(TextBox input)
        {
            Boolean estado = false;
            try
            {
                Clipboard.SetText(input.Text);
                estado = true;
            }
            catch(Exception e)
            {
                estado = false;

            }

             

            return estado;
        }


        public void Mostrar_Tabla_Empleados_Filtro(String ced, String ape, DataGrid tb_empleados)
        {
            if (String.IsNullOrEmpty(ced) && String.IsNullOrEmpty(ape))
            {
                MessageBox.Show("Por favor ingrese por lo menos un campo");

            }
            else if (!String.IsNullOrEmpty(ced))
            {
                List<EmpleadoHijo> lista_empleados = repo_emp.Get_Datos_Empleados_Campos("cedula", ced);

                tb_empleados.ItemsSource = lista_empleados;

            }
            else if (!String.IsNullOrEmpty(ape))
            {
                List<EmpleadoHijo> lista_empleados = repo_emp.Get_Datos_Empleados_Campos("apellidos", ape);

                tb_empleados.ItemsSource = lista_empleados;
            }



        }

     

        public List<Tuple<String, Double>>  Generar_Lista_FULL_Departamentos()
        {

            List<Tuple<String, Double>> Lista_Empleados_X_departamentos = new List<Tuple<String, Double>>();

            int total_departamentos = repo_emp.Get_Total_Departamentos_Empleados();


            int i = 0;
            int id = 0;


            while(i < total_departamentos)
            {

                int total_empleados_departamento = repo_emp.Get_Total_Emplados_X_Departamento(id);

                if(total_empleados_departamento > 0 )
                {

                    String nombre_dep = repo_emp.Get_Nombre_Departamento_Empleado(id);

                    Tuple<String, Double> Tupla_Departamento = new Tuple<String, Double>(nombre_dep,total_empleados_departamento);


                    Lista_Empleados_X_departamentos.Add(Tupla_Departamento);

                    i++;
                }

                id++;
            }

           





            return Lista_Empleados_X_departamentos;
        }
    }
}
