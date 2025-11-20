namespace Baskara
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void btCalcularBhaskara_Clicked(object sender, EventArgs e)
        {
            double fValorA = float.Parse(txValorA.Text);
            double fValorB = float.Parse(txValorB.Text);
            double fValorC = float.Parse(txValorC.Text);

            double delta = (fValorB * fValorB) - 4 * fValorA * fValorC;
            double x1 = (-fValorB + Math.Sqrt(delta)) / (2 * fValorA);
            double x2 = (-fValorB - Math.Sqrt(delta)) / (2 * fValorA);

            txValorx1.Text = x1.ToString();
            txValorx2.Text = x2.ToString();

        }
    }
}
