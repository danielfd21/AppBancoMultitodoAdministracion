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

namespace AppBancoMultitodoAdministracion.Vista.VistaContabilidad
{
    /// <summary>
    /// Lógica de interacción para RegistrarCliente.xaml
    /// </summary>
    public partial class RegistrarCliente : Window
    {
        public RegistrarCliente()
        {
            InitializeComponent();
        }


        public void Registrar_Cliente(object sender, RoutedEventArgs e)
        {

            String ced = txt_ced.Text;
            String nom = txt_nom.Text;
            String ape = txt_ape.Text;
            String cor = txt_cor.Text;
            DateTime? fec_nac = txt_fec_nac.SelectedDate;
            String fe_na = fec_nac.HasValue?fec_nac.Value.ToString("yyyy-MM-dd"):null;
            


            ClienteHijo Nuevo_Cliente = new ClienteHijo(ced,nom,ape,cor,fe_na);
            Boolean nue_cli = Nuevo_Cliente.Crear_CLiente();

            if(nue_cli == true)
            {

                txt_ced.Text = "";
                txt_nom.Text = "";
                txt_ape.Text = "";
                txt_cor.Text = "";
                txt_fec_nac = null;

            }

        }



    }
}
