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

namespace AppBancoMultitodoAdministracion.Vista.VistaGerencia
{
    /// <summary>
    /// Lógica de interacción para MenuGerencia.xaml
    /// </summary>
    public partial class MenuGerencia : Window
    {
        public MenuGerencia()
        {
            InitializeComponent();
        }

        public void Ventana_Nuevo_Empleado(object sender, RoutedEventArgs e)
        {
            RegistrarEmpleado ven_reg_emp = new RegistrarEmpleado();
            ven_reg_emp.ShowDialog();

        
        }

        public void Ventana_Nueva_Clave(object sender, RoutedEventArgs e)
        {
            RegistrarClave ven_reg_cla = new RegistrarClave();
            ven_reg_cla.ShowDialog();


        }

        public void Ventana_Editar_Empleado(object sender, RoutedEventArgs e)
        {
            EditarEmpleado edit = new EditarEmpleado();

            edit.ShowDialog();


        }

        public void Mostrar_Estadisticas(object sender, RoutedEventArgs e)
        {

            Estadisticas est = new Estadisticas();
            est.ShowDialog();

        }



    }
}
