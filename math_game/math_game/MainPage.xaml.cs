using System.Threading.Tasks;

namespace math_game
{
    public partial class MainPage : ContentPage
    {
        OperacaoAtiva operacoes;

        public MainPage()
        {
            InitializeComponent();
            operacoes = new OperacaoAtiva();
        }

        private void cb_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox? checkBox = sender as CheckBox;

            if (checkBox != null)
            {
                bool isChecked = checkBox.IsChecked;


                switch (checkBox.AutomationId)
                {
                    case "cbAdicao":
                        operacoes.adicao = isChecked;
                        break;
                    case "cbSubt":
                        operacoes.subtracao= isChecked;
                        break;
                    case "cbDiv":
                        operacoes.divisao = isChecked;
                        break;
                    case "cbMulti":
                        operacoes.multiplicacao = isChecked;
                        break;
                }   
            }

        }

        private async void btIniciarJogo_Clicked(object sender, EventArgs e)
        {
            int difficultyLevel = pkNivelDificuldade.SelectedIndex;

            if (!operacoes.adicao && !operacoes.subtracao && !operacoes.multiplicacao && !operacoes.divisao)
            {
                await DisplayAlert("Erro", "Selecione ao menos um tipo de opreação!", "OK");
                return;
            }

            await Navigation.PushAsync(new JogoMatematico(difficultyLevel, operacoes));
        }
    }
}
