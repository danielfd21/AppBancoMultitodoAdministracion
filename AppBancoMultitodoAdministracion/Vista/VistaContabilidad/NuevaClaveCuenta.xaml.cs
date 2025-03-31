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
    /// Lógica de interacción para NuevaClaveCuenta.xaml
    /// </summary>
    public partial class NuevaClaveCuenta : Window
    {


        CuentaRepositorio repo_cue = new CuentaRepositorio();
        Cuenta cue = new Cuenta();

        public NuevaClaveCuenta()
        {
            InitializeComponent();





        }




        public void Generar_Clave(object sender, RoutedEventArgs e)
        {
            String cuenta = txt_cuenta.Text;
            String clave = cue.Crear_Clave_Cuenta();

            Boolean actualizar = cue.Actualizar_Clave_Cuenta(cuenta,clave);

            if(actualizar == true)
            {
                txt_clave_cuenta.Text = clave;
            }




        }
    }
}
