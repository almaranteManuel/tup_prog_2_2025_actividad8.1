
using System.Windows.Forms;
using Ejercicio1.Models;
using System.Collections.Generic;
using System;
using System.IO;

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);

                StreamReader sr = new StreamReader(fs);

                while (!sr.EndOfStream)
                {
                   string linea = sr.ReadLine();

                    string dni = linea.Substring(0, 9);
                    string nombre = linea.Substring(9, 10).Trim();
                    string importe = linea.Substring(19,9);

                    Cuenta c = new Cuenta(nombre, Convert.ToInt32(dni), Convert.ToDouble(importe));
                }
            }
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
