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

namespace testdimessao
{
    /// <summary>
    /// Interaction logic for Entrada.xaml
    /// </summary>
    public partial class Entrada : Window
    {
        public Entrada()
        {
            InitializeComponent();
        }

        private void Ir_Para_Perguntas_Click(object sender, RoutedEventArgs e)
        {
            MainWindow entrada = new MainWindow();
            entrada.nomes[0] = Nome_jogar_1.Text;
            entrada.nomes[1] = Nome_jogar_2.Text;
            entrada.n_pergunta = int.Parse(Text_Numero_Perguntas.Text);
            entrada.Quem_ta_jogando.Content = Nome_jogar_1.Text;
            //entrada.texto_pergunta.Text = obs: arrumar perguntas na tela
            entrada.ShowDialog();

        }
    }
}
