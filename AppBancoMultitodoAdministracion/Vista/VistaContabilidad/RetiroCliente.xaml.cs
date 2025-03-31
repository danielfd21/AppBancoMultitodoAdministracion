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
    /// Lógica de interacción para RetiroCliente.xaml
    /// </summary>
    public partial class RetiroCliente : Window
    {


        public String cue { get; set; }
        public double sal { get; set; }

        ContadorHijo_Empleado contador = new ContadorHijo_Empleado();

        CuentaRepositorio repo_cue = new CuentaRepositorio();

        public RetiroCliente(String cuenta)
        {
            InitializeComponent();

            this.cue = cuenta;
            this.sal = repo_cue.Consultar_saldo(cuenta);

            txt_cuenta.Text = cuenta;
            txt_saldo.Text = sal.ToString();


        }


        public void Retirar(object sender, RoutedEventArgs e)
        {

            double cantidad = Double.Parse(txt_cantidad.Text);

            if (cantidad > 0)
            {


                Boolean deposito = contador.Retirar(cue,cantidad,sal);

                if (deposito == true)
                {
                    txt_cantidad.Text = null;
                    txt_saldo.Text = repo_cue.Consultar_saldo(cue).ToString();

                    MessageBox.Show("Retiro realizado con exito");
                    
                
                }
               

            }
            else
            {
                MessageBox.Show("Por favor ingrese la cantidad a depositar");
            }
        }



    }
}
