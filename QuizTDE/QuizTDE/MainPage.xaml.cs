using Windows.Media.AppBroadcasting;

namespace QuizTDE
{
    public partial class MainPage : ContentPage
    {
        private string respostaQ1, respostaQ2, respostaQ3, respostaQ4, respostaQ5;
        private float pontuacao=0;
        private string mensagemResposta;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked_Verificar_Respostas(object sender, EventArgs e)
        {
            pontuacao = 0;
            mensagemResposta = "";

            pontuacao = pontuacao + (respostaQ1 == "B" ? 20 : 0);
            pontuacao = pontuacao + (respostaQ2 == "B" ? 20 : 0);
            pontuacao = pontuacao + (respostaQ3 == "B" ? 20 : 0);
            pontuacao = pontuacao + (respostaQ4 == "C" ? 20 : 0);
            pontuacao = pontuacao + (respostaQ5 == "B" ? 20 : 0);


            if (pontuacao >= 90)
            {
                mensagemResposta = "Excelente!! Você domina .NET MAUI!";
            } else if (pontuacao > 70)
            {
                mensagemResposta = " Muito bom! Continue estudando!";
            } else if (pontuacao > 50)
            {
                mensagemResposta = " Bom trabalho! Há espaço para melhorar.";
            } else
            {
                mensagemResposta = " Continue estudando e pratique mais!";
            }

            int qtdAcertos = (int)(pontuacao / 20);

            txPontuacao.Text = "Pontuação: " + qtdAcertos + "/5 (" + pontuacao + "%)";
            txMensagemResposta.Text = mensagemResposta;

        }

        private void Button_Clicked_Reiniciar_Quiz(object sender, EventArgs e)
        {
            
        }

        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var radioButton = sender as RadioButton;

            if (radioButton == null || !e.Value)
            {
                return;
            }

            string valorSelecionado = radioButton.Value.ToString();

            switch (radioButton.GroupName)
            {
                case "questao1":
                    respostaQ1 = valorSelecionado;
                    break;
                case "questao2":
                    respostaQ2 = valorSelecionado;
                    break;
                case "questao3":
                    respostaQ3 = valorSelecionado;
                    break;
                case "questao4":
                    respostaQ4 = valorSelecionado;
                    break;
                case "questao5":
                    respostaQ5 = valorSelecionado;
                    break;
            }
        }
    }
}
