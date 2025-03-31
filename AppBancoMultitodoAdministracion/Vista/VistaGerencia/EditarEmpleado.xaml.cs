using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AppBancoMultitodoAdministracion.Modelo.Clases;
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;

namespace AppBancoMultitodoAdministracion.Vista.VistaGerencia
{
    /// <summary>
    /// Lógica de interacción para EditarEmpleado.xaml
    /// </summary>
    public partial class EditarEmpleado : Window
    {
        EmpleadosRepositorio repo_emp = new EmpleadosRepositorio();
        EmpleadoHijo emp = new EmpleadoHijo();
        GerenteHijo_Empleado ger = new GerenteHijo_Empleado();

        String busqueda_tipo = "";
        String busqueda_variable = "";

        public EditarEmpleado()
        {
            InitializeComponent();

           

           
        }

        public void Mostrar_Full_Empleados(object sender, RoutedEventArgs e)
        {
            List<EmpleadoHijo> lista_empleados = repo_emp.Get_Datos_Empleados();

            tb_empleados.ItemsSource = lista_empleados;
        }


        public void Filtrar_Empleados(object sender, RoutedEventArgs e)
        {

            String ced = txt_ced.Text;
            String ape = txt_ape.Text;
    
            
            if (!String.IsNullOrEmpty(ced))
            {
                
                busqueda_tipo = "Cedula";
                busqueda_variable = ced;


            }
            else if (!String.IsNullOrEmpty(ape))
            {
               
                busqueda_tipo = "Apellido";
                busqueda_variable = ape;
            }


            ger.Mostrar_Tabla_Empleados_Filtro(ced,ape,tb_empleados);
           

        }

        public void Eliminar_Empleados(object sender, RoutedEventArgs e)
        {

            

            if(tb_empleados.SelectedItem != null)
            {
                EmpleadoHijo index = (EmpleadoHijo)tb_empleados.SelectedItem;
                String cedula = index.ced;

                var Mensaje_confirmacion = MessageBox.Show($"¿Esta seguro de eliminar el empleado con cedula? \n {cedula}  ","Mensaje de eliminacion", MessageBoxButton.YesNo,MessageBoxImage.Warning );

                if(Mensaje_confirmacion == MessageBoxResult.Yes)
                {

                    emp.Eliminar_Empleado(cedula);


                    if (busqueda_tipo == "Cedula")
                    {
                        List<EmpleadoHijo> lista_empleados_filtro= repo_emp.Get_Datos_Empleados_Campos("cedula",busqueda_variable);

                        tb_empleados.ItemsSource = lista_empleados_filtro;
                    }
                    else if (busqueda_tipo == "Apellido")
                    {
                        List<EmpleadoHijo> lista_empleados_filtro = repo_emp.Get_Datos_Empleados_Campos("apellidos", busqueda_variable);

                        tb_empleados.ItemsSource = lista_empleados_filtro;
                    }
                    else
                    {
                        List<EmpleadoHijo> lista_empleados = repo_emp.Get_Datos_Empleados();

                        tb_empleados.ItemsSource = lista_empleados;
                    }



                    

                }






            }
            else
            {
                MessageBox.Show("Por favor seleccione una fila antes de eliminar");
            }

           
            

        }

        private void Actualizar_Empleado(object sender, RoutedEventArgs e)
        {
            if(tb_empleados.SelectedItem != null)
            {

                EmpleadoHijo index = (EmpleadoHijo) tb_empleados.SelectedItem;

                String cedula = index.ced;
                String correo = index.cor;

                ActualizarEmpleados act_emp = new ActualizarEmpleados(cedula,correo);

                act_emp.ShowDialog();




            }


        }
    }
}
