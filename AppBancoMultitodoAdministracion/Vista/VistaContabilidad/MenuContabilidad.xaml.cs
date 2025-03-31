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

namespace AppBancoMultitodoAdministracion.Vista.VistaContabilidad
{
    /// <summary>
    /// Lógica de interacción para MenuContabilidad.xaml
    /// </summary>
    public partial class MenuContabilidad : Window
    {
        public MenuContabilidad()
        {
            InitializeComponent();
        }

        public void Ventana_Nuevo_Cliente(object sender, RoutedEventArgs e)
        {

            RegistrarCliente reg_cli = new RegistrarCliente();
            reg_cli.ShowDialog();


        }

        public void Ventana_Nueva_Clave_Cliente(object sender, RoutedEventArgs e)
        {

            NuevaClaveCuenta nue_cue = new NuevaClaveCuenta();
            nue_cue.ShowDialog();
        }

        public void Ventana_Nueva_Cuenta(object sender, RoutedEventArgs e)
        {
            VentanaCLienteCuenta ven = new VentanaCLienteCuenta();

            ven.ShowDialog();
            



        }

        public void Ventana_Editar_Cliente(object sender, RoutedEventArgs e)
        {
            VentanaEditarCliente ven = new VentanaEditarCliente();

            ven.ShowDialog();




        }


        public void Ventana_Deposito(object sender, RoutedEventArgs e)
        {
            VentanaDeposito ven_dep = new VentanaDeposito();
            ven_dep.ShowDialog();
        }

        public void Ventana_Retiro(object sender, RoutedEventArgs e)
        {
            VentanaRetiroCliente ven_ret = new VentanaRetiroCliente();
            ven_ret.ShowDialog();
        
        }


        public void Ventana_Transferencia(object sender, RoutedEventArgs e)
        {
            VentanaTransaccion ven_tra = new VentanaTransaccion();
            ven_tra.ShowDialog();

        }


    }
}
