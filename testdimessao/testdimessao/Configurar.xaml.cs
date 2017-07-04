using System;
using System.Collections.Generic;
using System.Collections;
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
using System.IO;

namespace testdimessao
{
    /// <summary>
    /// Interaction logic for Configurar.xaml
    /// </summary>
    public partial class Configurar : Window
    {

        StreamReader ler;
        StreamWriter salvar;
        List<string> perguntas = new List<string>();
        List<string> pek = new List<string>();
        public Configurar()
        {
            InitializeComponent();
            leraqrv();
            
        }

        public void leraqrv()
        {
            mostra_pergunta.Clear();
          ler  = new StreamReader("C:\\Users\\Rubens\\Documents\\GitHub\\trabalho_casa\\testdimessao\\testdimessao\\perguntas\\cenario1.txt");
        
          string[]str=  ler.ReadToEnd().Split('\r');
          ler.Close();
          for (int i = 0; i < str.Length; i++)
          {
              perguntas.Add(str[i]);
          }
          for (int i = 0; i < perguntas.Count; i++)
          {
              mostra_pergunta.Text += perguntas[i];
          }

        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            leraqrv();

        }

        public void add_no_txt()
        {

            if (!string.IsNullOrWhiteSpace(texto_perguntas.Text))
            {

                string[] str = texto_perguntas.Text.Split('\n');
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = str[i].Replace("\n", "");
                    perguntas.Add(str[i]);
                }
            }
            
           

        }

        private void mostra_perguntas_Click(object sender, RoutedEventArgs e)
        {
            mostra_pergunta.Clear();
            add_no_txt();
            salvar = new StreamWriter("C:\\Users\\Rubens\\Documents\\GitHub\\trabalho_casa\\testdimessao\\testdimessao\\perguntas\\cenario1.txt");

            foreach (var pergunta in perguntas)
            {
                salvar.WriteLine(pergunta);

            }

            salvar.Close();
               
        }

        }
    }
