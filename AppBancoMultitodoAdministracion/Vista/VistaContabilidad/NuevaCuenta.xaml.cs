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
    /// Lógica de interacción para NuevaCuenta.xaml
    /// </summary>
    public partial class NuevaCuenta : Window
    {
        ClienteRepositorio repo_cli = new ClienteRepositorio();
        
        public NuevaCuenta(String cedula)
        {
            InitializeComponent();

            List<ClienteHijo> cliente = repo_cli.Mostrar_Lista_Cliente_Filtrado("Cedula",cedula);

            if (cliente.Count >= 0)
            {


                ClienteHijo cli = cliente[0];

                txt_ced.Text = cli.ced;
                txt_nom.Text = cli.nom;
                txt_ape.Text = cli.ape;
                txt_cor.Text = cli.cor;
                txt_fec_nac.SelectedDate = Convert.ToDateTime(cli.fec_nac);
            }
            else
            {
                MessageBox.Show("No se encontraron suficientes datos para mostrar." + cedula, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        public void Generar_Cuenta(object sender, RoutedEventArgs e)
        {




            Cuenta Nueva_cuenta = new Cuenta();

            txt_cuenta.Text =  Nueva_cuenta.Crear_Numero_de_Cuenta();
            txt_clave_cuenta.Text = Nueva_cuenta.Crear_Clave_Cuenta();
            txt_saldo.IsEnabled = true;
            btn_crear_cuenta.IsEnabled = true;


        }

        private void Crear_Cuenta(object sender, RoutedEventArgs e)
        {

            String num_cue = txt_cuenta.Text;
            String clave = txt_clave_cuenta.Text;
            Double saldo = Double.Parse(txt_saldo.Text);
            String cedula = txt_ced.Text; 

            Cuenta Nueva_Cuenta = new Cuenta(num_cue,saldo,cedula,clave);
            Nueva_Cuenta.Crear_Cuenta();


        }
    }
}
