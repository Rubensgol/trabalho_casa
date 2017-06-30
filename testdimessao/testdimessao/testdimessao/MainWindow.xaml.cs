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

        int jogador_atual = 0;
        int pergunta_atual = 0;


        public MainWindow()
        {
           
            InitializeComponent();
            Add_pergunas();
            Quem_ta_jogando.Content = nomes[jogador_atual];

        }

        private void Acusar_click(object sender, RoutedEventArgs e)
        {
           
            pergunta_atual++;

            if (pergunta_atual == 4 && jogador_atual==0)
            {
                pergunta_atual = 0;
                jogador_atual++;
                Quem_ta_jogando.Content = nomes[jogador_atual];
            }
            else if (pergunta_atual == 4 && jogador_atual == 1)
            {
                Acusar_butao.IsEnabled = false;
                Confessar_butao.IsEnabled = false;
            }
            texto_pergunta.Text = perguntas[pergunta_atual];
        }

        public void Add_pergunas()
        {
            perguntas[0] = "matou?";
            perguntas[1] = "ajudou?";
            perguntas[2] = "foi voce?";
            perguntas[3] = "foi ele?";
            perguntas[4] = "entao quem";
        }

        public void calc_pena()
        {
            //cria as variaveis de pena
            int pena_1 = 0;
            int pena_2 = 0;

            //compara as repostas e soma a pontuacao
            for (int i = 0; i < n_pergunta; i++)
            {   
                
                if (resposta_criminos[1,i]==0 && resposta_criminos[2,i]==0)
                {
                    pena_1 = pena_1 + 3;
                    pena_2 = pena_2 + 3;

                }
                if (resposta_criminos[1,i]==1 && resposta_criminos[2,i]==0)
                {
                    pena_1++;
                    pena_2--;
                }
                if (resposta_criminos[1,i]==0 && resposta_criminos[2,i]==1)
                {
                    pena_1--;
                    pena_2++;
                }
                if (resposta_criminos[1,i]==1 && resposta_criminos[2,i]==1)
                {
                    pena_1++;
                    pena_2++;
                }
            }
          

		

        }

        private void Confessar_butao_Click(object sender, RoutedEventArgs e)
        {
            
            pergunta_atual++;
            if (pergunta_atual == 4 && jogador_atual == 0)
            {
                pergunta_atual = 0;
                jogador_atual++;
                Quem_ta_jogando.Content = nomes[jogador_atual];
            }
            else if (pergunta_atual == 4 && jogador_atual == 1)
            {
                Acusar_butao.IsEnabled = false;
                Confessar_butao.IsEnabled = false;
            }
            texto_pergunta.Text = perguntas[pergunta_atual];
        }
    }
}
