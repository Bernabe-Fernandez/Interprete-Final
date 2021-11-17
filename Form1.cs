using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using com.calitha.goldparser;
using System.Diagnostics;

namespace Interprete_v1
{
    public partial class Form1 : Form
    {
        MyParser Parser;
        public Form1()
        {
            Parser = new MyParser(Application.StartupPath + "\\gramaticaInterprete.cgt");
            InitializeComponent();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            MyParser.TablaSimbolo.Clear();
            MyParser.salida = string.Empty;
            MyParser.errores = string.Empty;
            ClearType();
            LstVTabla.Items.Clear();
            Parser.Parse(TxtSoftware.Text);
            for (int i = 0; i < MyParser.TablaSimbolo.Count; i++)
            {
                ListViewItem item = new ListViewItem(Convert.ToString(MyParser.TablaSimbolo[i].id), 0);
                item.SubItems.Add(Convert.ToString(MyParser.TablaSimbolo[i].tipo));
                if (MyParser.TablaSimbolo[i].tipo == "entero")
                {
                    item.SubItems.Add(Convert.ToString(MyParser.entero[MyParser.TablaSimbolo[i].indice]));
                }
                else if (MyParser.TablaSimbolo[i].tipo == "real")
                {
                    item.SubItems.Add(Convert.ToString(MyParser.real[MyParser.TablaSimbolo[i].indice]));
                }
                else if (MyParser.TablaSimbolo[i].tipo == "cadena")
                {
                    item.SubItems.Add(Convert.ToString(MyParser.cadena[MyParser.TablaSimbolo[i].indice]));
                }
                else if (MyParser.TablaSimbolo[i].tipo == "caracter")
                {
                    item.SubItems.Add(Convert.ToString(MyParser.caracter[MyParser.TablaSimbolo[i].indice]));
                }
                LstVTabla.Items.Add(item);
            }
            TxtSalida.Text = MyParser.salida;
            TxtError.Text = MyParser.errores;

        }

        public void ClearType()
        {
            for (int i = 0; i < MyParser.entero.Length; i++) MyParser.entero[i] = 0;
            for (int i = 0; i < MyParser.real.Length; i++) MyParser.real[i] = 0.0;
            for (int i = 0; i < MyParser.cadena.Length; i++) MyParser.cadena[i] = "";
            for (int i = 0; i < MyParser.caracter.Length; i++) MyParser.caracter[i] = ' ';
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            TxtSoftware.Text = string.Empty;
            TxtSalida.Text = string.Empty;
            TxtError.Text = string.Empty;
            LstVTabla.Items.Clear();
        }

        private void BtnAbrir_Click(object sender, EventArgs e)
        {
            //creamos un objeto de tipo OpenFileDialog el cual usaremos para obtener la direccion del archivo
            OpenFileDialog abrir = new OpenFileDialog();

            //ejecutamos el metodo showdialog para abrir nuestro administrador
            //de archivos y verificamos que sea exitoso
            if(abrir.ShowDialog() == DialogResult.OK)
            {
                //declaramos una variable de tipo string donde guardaremos
                //la direccion del archivo
                string direccion = abrir.FileName;

                //creamos un objeto de tipo StreamReader el cual nos servira para
                //leer el archivo que tenemos en la direccion que le pasamos.
                StreamReader leer = new StreamReader(direccion);
                String linea; //declaramos un string para leer el contenido linea por linea

                try
                {
                    linea = leer.ReadLine(); //dentro de la variable linea, leemos cada linea del archivo
                    while (linea != null)//comparamos que aun hayan linea por imprimir
                    {
                        TxtSoftware.AppendText(linea + "\r\n");//imprimos dentro de nuestro textbox
                        linea = leer.ReadLine();//y leemos la siguiente linea
                    }

                }
                catch
                {
                    MessageBox.Show("Error al leer el archivo");//mensaje de error al abrir el archivo
                }

            }
            else
            {
                MessageBox.Show("Error al abrir");
            }



        }
    }
}
