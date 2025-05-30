﻿using System;
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
using AppBancoMultitodoAdministracion.Recursos.Base_de_datos.Repositorio;

namespace AppBancoMultitodoAdministracion.Vista.VistaContabilidad
{
    /// <summary>
    /// Lógica de interacción para VentanaRetiroCliente.xaml
    /// </summary>
    public partial class VentanaRetiroCliente : Window
    {
        CuentaRepositorio repo_cue = new CuentaRepositorio();
        public VentanaRetiroCliente()
        {
            InitializeComponent();
        }

        public void Mostrar_Datos_Cuenta(object sender, RoutedEventArgs e)
        {

            List<object> lista_Cliente_Cuenta = repo_cue.Mostrar_Datos_Cuenta();
            tb_cliente.ItemsSource = lista_Cliente_Cuenta;
        }

        public void Buscar_Datos_Cuenta(object sender, RoutedEventArgs e)
        {

            String ced = txt_ced.Text;
            String ape = txt_ape.Text;
            String cue = txt_cue.Text;

            if (String.IsNullOrEmpty(ced) && String.IsNullOrEmpty(ape) && String.IsNullOrEmpty(cue))
            {
                MessageBox.Show("Por favor llene todos los campos");
            }
            else if (!String.IsNullOrEmpty(ced))
            {
                List<object> lista_Cliente_Cuenta = repo_cue.Mostrar_Datos_Cuenta_Filtro("cliente.Cedula", ced);
                tb_cliente.ItemsSource = lista_Cliente_Cuenta;

            }
            else if (!String.IsNullOrEmpty(ape))
            {
                List<object> lista_Cliente_Cuenta = repo_cue.Mostrar_Datos_Cuenta_Filtro("cliente.Apellidos", ape);
                tb_cliente.ItemsSource = lista_Cliente_Cuenta;
            }
            else if (!String.IsNullOrEmpty(cue))
            {
                List<object> lista_Cliente_Cuenta = repo_cue.Mostrar_Datos_Cuenta_Filtro("cuenta.Numero_Cuenta", cue);
                tb_cliente.ItemsSource = lista_Cliente_Cuenta;
            }



        }

        public void Continuar(Object sender, RoutedEventArgs e)
        {
            if (tb_cliente.SelectedItem != null)
            {

                var index = (dynamic)tb_cliente.SelectedItem;
                String cuenta = index.cue;
                double saldo = Convert.ToDouble(index.sal);


                RetiroCliente ret_cli = new RetiroCliente(cuenta);
                ret_cli.ShowDialog();

            }
            else
            {
                MessageBox.Show("Por favor escoja una fila antes de continuar");
            }


        }
    }
}
