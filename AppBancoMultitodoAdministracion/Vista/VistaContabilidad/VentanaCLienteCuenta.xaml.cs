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

namespace AppBancoMultitodoAdministracion.Vista.VistaContabilidad
{
    /// <summary>
    /// Lógica de interacción para VentanaCLienteCuenta.xaml
    /// </summary>
    public partial class VentanaCLienteCuenta : Window
    {
        public VentanaCLienteCuenta()
        {
            InitializeComponent();
        }

        ClienteRepositorio repo_cli = new ClienteRepositorio();

        public void Mostrar_Todo(object sender, RoutedEventArgs e) 
        {



                List<ClienteHijo> Lista_Cliente = repo_cli.Mostrar_Lista_Cliente();
            tb_cliente.ItemsSource = Lista_Cliente;


        }


        public void Mostrar_Filtrado(object sender, RoutedEventArgs e)
        {

            String ced = txt_ced.Text;
            String ape = txt_ape.Text;

            if(String.IsNullOrEmpty(ced) && String.IsNullOrEmpty(ape))
            {
                MessageBox.Show("Por favor llene por lo menos un campo");
            }
            else if(!String.IsNullOrEmpty(ced))
            {
                List<ClienteHijo> Lista_Cliente_Filtrado = repo_cli.Mostrar_Lista_Cliente_Filtrado("Cedula",ced);
                tb_cliente.ItemsSource = Lista_Cliente_Filtrado;


            }
            else if(!String.IsNullOrEmpty(ape))
            {
                List<ClienteHijo> Lista_Cliente_Filtrado = repo_cli.Mostrar_Lista_Cliente_Filtrado("Apellidos", ape);
                tb_cliente.ItemsSource = Lista_Cliente_Filtrado;
            }


             



        



           


        }

        private void Continuar_Cuenta(object sender, RoutedEventArgs e)
        {

            if(tb_cliente.SelectedItem != null)
            {
                ClienteHijo cliente = (ClienteHijo) tb_cliente.SelectedItem;
                String cedula = cliente.ced;
                NuevaCuenta nueva_cuenta = new NuevaCuenta(cedula);
                nueva_cuenta.ShowDialog();


            }
            else
            {
                MessageBox.Show("Por favor escoja una fila antes de continuar");
            }



        }
    }
}
