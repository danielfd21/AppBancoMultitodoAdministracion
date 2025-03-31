using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
    /// Lógica de interacción para VentanaEditarCliente.xaml
    /// </summary>
    public partial class VentanaEditarCliente : Window
    {

        String busqueda_tipo = "";
        String busqueda_variable = "";

        ClienteHijo cli = new ClienteHijo();
        ClienteRepositorio repo_cli = new ClienteRepositorio();

        public VentanaEditarCliente()
        {
            InitializeComponent();
        }


        public void Continuar(object sender, RoutedEventArgs e)
        {
            

            if(tb_cliente.SelectedItem != null)
            {

                ClienteHijo cli = (ClienteHijo) tb_cliente.SelectedItem;
                String cedula = cli.ced;
                String correo = cli.cor;

                EditarCliente edi_cli = new EditarCliente(cedula,correo);

                edi_cli.ShowDialog();


            }
            else
            {

                MessageBox.Show("Por favor seleccione una fila antes de continuar");

            }





        }

        public void Buscar(object sender, RoutedEventArgs e)
        {


            String ced = txt_ced.Text;
            String ape = txt_ape.Text;

            if (String.IsNullOrEmpty(ced) && String.IsNullOrEmpty(ape))
            {
                MessageBox.Show("Por favor llene por lo menos un campo");
            }
            else if (!String.IsNullOrEmpty(ced))
            {
                List<ClienteHijo> Lista_Cliente_Filtrado = repo_cli.Mostrar_Lista_Cliente_Filtrado("Cedula", ced);
                tb_cliente.ItemsSource = Lista_Cliente_Filtrado;
                busqueda_tipo = "Cedula";
                busqueda_variable = ced;


            }
            else if (!String.IsNullOrEmpty(ape))
            {
                List<ClienteHijo> Lista_Cliente_Filtrado = repo_cli.Mostrar_Lista_Cliente_Filtrado("Apellidos", ape);
                tb_cliente.ItemsSource = Lista_Cliente_Filtrado;
                busqueda_tipo = "Apellido";
                busqueda_variable = ape;
            }







        }
        public void Mostrar_Todo(object sender, RoutedEventArgs e)
        {


            List<ClienteHijo> Lista_Cliente = repo_cli.Mostrar_Lista_Cliente();
            tb_cliente.ItemsSource = Lista_Cliente;
            busqueda_tipo = "Todo";



        }

        public void Eliminar(object sender, RoutedEventArgs e)
        {

            if (tb_cliente.SelectedItem != null)
            {

                ClienteHijo index = (ClienteHijo) tb_cliente.SelectedItem;

                String cedu = index.ced;

                cli.Eliminar_Cliente(cedu);

                if(busqueda_tipo == "Cedula")
                {
                    List<ClienteHijo> Lista_Cliente_Filtrado = repo_cli.Mostrar_Lista_Cliente_Filtrado("Cedula", busqueda_variable);
                    tb_cliente.ItemsSource = Lista_Cliente_Filtrado;
                }
                else if(busqueda_tipo == "Apellido")
                {
                    List<ClienteHijo> Lista_Cliente_Filtrado = repo_cli.Mostrar_Lista_Cliente_Filtrado("Cedula", busqueda_variable);
                    tb_cliente.ItemsSource = Lista_Cliente_Filtrado;
                }
                else
                {
                    List<ClienteHijo> Lista_Cliente = repo_cli.Mostrar_Lista_Cliente();
                    tb_cliente.ItemsSource = Lista_Cliente;
                }


               


            }
            else
            {
                MessageBox.Show("Por favor elija una fila antes de eliminar");
            }

           
        }
    }
}
