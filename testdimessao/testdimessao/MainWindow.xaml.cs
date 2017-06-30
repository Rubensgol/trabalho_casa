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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace testdimessao
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //cria o numeo de pergunta, o verto de resposta dos criminosos
       
        public int n_pergunta;
        public string[] nomes = new string[2];
        int[,] resposta_criminos = new int[2,5];
        string[] perguntas = new string[5];
        Pontuacao pontuacao = new Pontuacao();

        int jogador_atual = 0;
        int pergunta_atual = 0;
        int controlar_pergunta = 0;

        public MainWindow()
        {
           
            InitializeComponent();

            Add_pergunas();
            texto_pergunta.Text = perguntas[0];
           
        }

        private void Acusar_click(object sender, RoutedEventArgs e)
        {
            resposta_criminos[jogador_atual, pergunta_atual] = 1;
            controle_text();
           
        }


         private void Confessar_butao_Click(object sender, RoutedEventArgs e)
        {
            resposta_criminos[jogador_atual, pergunta_atual] = 0;
            controle_text();
           
            
        }

        //metodos


        public void Add_pergunas()
        {
            perguntas[0] = "1";
            perguntas[1] = "2?";
            perguntas[2] = "3";
            perguntas[3] = "4";
            perguntas[4] = "5";
        }

        public string calc_pena()
        {
            //cria as variaveis de pena
            int pena_1 = 0;
            int pena_2 = 0;
            string sentenca;
            //compara as repostas e soma a pontuacao
            for (int i = 0; i < n_pergunta; i++)
            {   
                
                if ((resposta_criminos[0,i]==0) && (resposta_criminos[1,i]==0))
                {
                    pena_1 = pena_1 + 3;
                    pena_2 = pena_2 + 3;


                }
                if (resposta_criminos[0,i]==1 && resposta_criminos[1,i]==0)
                {
                    pena_1++;
                    pena_2--;
                }
                if (resposta_criminos[0,i]==0 && resposta_criminos[1,i]==1)
                {
                    pena_1--;
                    pena_2++;
                }
                if (resposta_criminos[0,i]==1 && resposta_criminos[1,i]==1)
                {
                    pena_1++;
                    pena_2++;
                }
            }

            if (pena_1 <= 0)
                sentenca = nomes[0]+" esta livre  ";
            else
                sentenca =nomes[0]+ " pegou "+(pena_1 * 2).ToString()+" anos de pena e ";
            if (pena_2 <= 0)
                sentenca = sentenca + nomes[1] + ":  esta livre  ";
            else
                sentenca = sentenca + nomes[1] + " pegou " + (pena_2 * 2).ToString() + " anos de pena";
            return sentenca;
		

        }

        public void controle_text()
        {
            if (controlar_pergunta == n_pergunta-1 && jogador_atual == 0)
            {
                Quem_ta_jogando.Content = nomes[1];
                texto_pergunta.Text = perguntas[0];
                pergunta_atual = -1;
                jogador_atual++;
                controlar_pergunta = 0;
            }

            if (controlar_pergunta == n_pergunta && jogador_atual == 1)
            {
                Acusar_butao.IsEnabled = false;
                Confessar_butao.IsEnabled = false;
                calc_pena();
                MessageBox.Show(calc_pena());
                pontuacao.ShowDialog();
                pergunta_atual = 0;

            }
            controlar_pergunta++;
            pergunta_atual++;
            texto_pergunta.Text = perguntas[pergunta_atual];
        }

      
    }
}
