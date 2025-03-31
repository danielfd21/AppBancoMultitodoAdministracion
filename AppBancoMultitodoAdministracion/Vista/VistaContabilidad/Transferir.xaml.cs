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
    /// Lógica de interacción para Transferir.xaml
    /// </summary>
    public partial class Transferir : Window
    {


        public String cue { get; set; }
        public double sal { get; set; }

        ContadorHijo_Empleado contador = new ContadorHijo_Empleado();
        CuentaRepositorio repo_cue = new CuentaRepositorio();

        public Transferir(String cuenta)
        {
            InitializeComponent();


            this.cue = cuenta;
            this.sal = repo_cue.Consultar_saldo(cuenta);

            txt_cuenta.Text = cuenta;
            txt_saldo.Text = sal.ToString();
        }


        public void Transaccionar(object sender, RoutedEventArgs e)
        {
            double cantidad = Double.Parse(txt_cantidad.Text);
            String cue_ben =  txt_beneficiario.Text;



            if (cantidad > 0)
            {


                contador.Transferir(cue, cue_ben, cantidad,sal);

                txt_cantidad.Text = null;
                txt_beneficiario.Text = null;





               

                txt_saldo.Text = repo_cue.Consultar_saldo(cue).ToString();


            }
            else
            {
                MessageBox.Show("Por favor ingrese la cantidad a transferir");
            }



        }

       
    }
}
