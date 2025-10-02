
using System.Windows.Forms;
using Ejercicio1.Models;
using System.Collections.Generic;
using System;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Cuenta> cuentas = new List<Cuenta>();

        private void button1_Click(object sender, System.EventArgs e)
        {
            string nombre = tbNombre.Text;
            int dni = Convert.ToInt32(tbDNI.Text);
            double importe = Convert.ToDouble(tbImporte.Text);

            Cuenta c = new Cuenta(nombre, dni, importe);

            cuentas.Sort();
            int idx = cuentas.BinarySearch(c);

            if (idx >= 0)
            {
                cuentas[idx].Nombre = nombre;
                cuentas[idx].Importe = importe;
                button2.PerformClick();
            }
            else
            {

                cuentas.Add(c);

                tbDNI.Clear();
                tbNombre.Clear();
                tbImporte.Clear();
            }

            //button2.PerformClick();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            foreach (Cuenta c in cuentas)
            {
                listBox1.Items.Add(c);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cuenta c = listBox1.SelectedItem as Cuenta;

            if (c != null)
            {
                tbDNI.Text = $"{c.DNI}";
                tbNombre.Text = $"{c.Nombre}";
                tbImporte.Text = $"{c.Importe}";
            }
        }
    }
}
