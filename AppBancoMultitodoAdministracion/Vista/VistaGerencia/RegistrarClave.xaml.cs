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

namespace AppBancoMultitodoAdministracion.Vista.VistaGerencia
{
    /// <summary>
    /// Lógica de interacción para RegistrarClave.xaml
    /// </summary>
    public partial class RegistrarClave : Window
    {
        public RegistrarClave()
        {
            InitializeComponent();
        }

        GerenteHijo_Empleado ger = new GerenteHijo_Empleado();

        private void Generar_Clave(object sender, RoutedEventArgs e)
        {



            String ced = txt_ced.Text;


            ger.Generar_Clave_Empleado(ced,txt_cla);







        }

        private void Copiar_Clave(object sender , RoutedEventArgs e)
        {

           Boolean copiar = ger.Copiar_Clave(txt_cla);

            if(copiar == true)
            {
                MessageBox.Show("Clave copiada con exito");
            }
        }
    }
}
