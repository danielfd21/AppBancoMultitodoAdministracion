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
    /// Lógica de interacción para DepositoCliente.xaml
    /// </summary>
    public partial class DepositoCliente : Window
    {

        public String cue { get; set; }
        public double sal { get; set; }

        ContadorHijo_Empleado contador = new ContadorHijo_Empleado();
        CuentaRepositorio repo_cue = new CuentaRepositorio();


        public DepositoCliente(String cuenta)
        {
            InitializeComponent();

            this.cue = cuenta;
            this.sal = repo_cue.Consultar_saldo(cuenta);

            txt_cuenta.Text = cuenta;
            txt_saldo.Text =  sal.ToString();


            
        }



        public void Depositar(object sender, RoutedEventArgs e)
        {


            double cantidad = Double.Parse(txt_cantidad.Text);

            if (cantidad > 0)
            {


               contador.Depositar(cue,cantidad,sal);

               txt_cantidad.Text = null;

               
                MessageBox.Show("Deposito realizado con exito");

                txt_saldo.Text = repo_cue.Consultar_saldo(cue).ToString();
                

            }
            else
            {
                MessageBox.Show("Por favor ingrese la cantidad a depositar");
            }


        }

    }
}
