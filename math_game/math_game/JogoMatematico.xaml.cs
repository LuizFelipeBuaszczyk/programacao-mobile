using Microsoft.Maui.Dispatching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace math_game
{
    public partial class JogoMatematico : ContentPage
    {

        int iValor1 = 0;
        int iValor2 = 0;
        float fR = 0.0f;
        int iTimer = 30;
        int questao = 0;

        int iPontuacao = 0;
        int iAcertouCount = 0;
        int iErrouCount = 0;

        bool telaInicial = true;
        Random rand = new Random();

        OperacaoAtiva operacoesLiberadas;
        int maxValue;

        public JogoMatematico(int nivelDificuldade, OperacaoAtiva operacoes)
        {
            InitializeComponent();
            operacoesLiberadas = operacoes;
            int[] selectMaxValue = { 10, 50, 100 };

            maxValue = selectMaxValue[nivelDificuldade];
            gerarJogo();
            iniciarTimer();
        }

        private async void btOK_Clicked(object sender, EventArgs e)
        {
            try
            {
                float resposta = Convert.ToSingle(txR.Text);
                tratarResposta(resposta);
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Digite um número válido!", "OK");
                return;
            }
            gerarJogo();
        }

        private void gerarJogo()
        {
            iTimer = 30;
            questao++;

            if (questao > 10)
            {
                DisplayAlert("Fim", "A sua pontuaçaõ foi de " + iPontuacao.ToString(), "OK");
                Navigation.PushAsync(new MainPage());
            }

            iValor1 = rand.Next(1, maxValue);
            iValor2 = rand.Next(1, 10);

            lb1.Text = Convert.ToString(iValor1);
            lb2.Text = buscarOperador(rand.Next(1, 5));
            lb3.Text = Convert.ToString(iValor2);
            lbQuestao.Text = questao.ToString();
            lbPontos.Text = iPontuacao.ToString();
        }

        private void tratarResposta(float resposta)
        {
            if (resposta == fR)
            {
                iAcertouCount++;
                lbAcertos.Text = "Acertos: " + Convert.ToString(iAcertouCount);
                imR.Source = "win.png";
                iPontuacao += (iTimer * maxValue);
            }
            else
            {
                iErrouCount++;
                lbErros.Text = "Erros: " + Convert.ToString(iErrouCount);
                imR.Source = "loose.png";
            }
            telaInicial = false;

            reiniciarImagem();
        }

        private async void reiniciarImagem()
        {
            await Task.Delay(2000);
            if (!telaInicial)
            {
                imR.Source = "question.png";
                telaInicial = true;

            }
        }
        private string buscarOperador(int index)
        {

            // Retorna a operação e o resultado já é tratado

            while (true)
            {
                if (operacoesLiberadas.adicao && index == 1)
                {
                    fR = iValor1 + iValor2;
                    return "+";
                }
                if (operacoesLiberadas.subtracao && index == 2)
                {
                    fR = iValor1 - iValor2;
                    return "-";
                }

                if (operacoesLiberadas.multiplicacao && index == 3)
                {
                    fR = iValor1 * iValor2;
                    return "*";
                }

                if (operacoesLiberadas.divisao && index == 4)
                {
                    fR = iValor1 / iValor2;
                    return "/";
                }
                if (index < 4)
                {
                    index++;
                }
                index = 1;
            }
        }

        [Obsolete]
        private void iniciarTimer()
        {

            Device.StartTimer(TimeSpan.FromSeconds(1), () => 
             { 
                if (iTimer > 0)
                {
                    iTimer--;
                    lbTempo.Text = iTimer.ToString() + "s";
                }
                else
                {
                     gerarJogo();
                 }

                 return questao <= 10;
            });
        }
    }
}
