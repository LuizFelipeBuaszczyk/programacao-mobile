namespace DistanciaEntrePontos
{
    public partial class MainPage : ContentPage
    {
        double fDistancia;
        public MainPage()
        {
            InitializeComponent();
        }

        private void btCalcularDistanciaEntrePontos_Clicked(object sender, EventArgs e)
        {
            double ax = float.Parse(txValorAx.Text);
            double ay = float.Parse(txValorAy.Text);
            double az = float.Parse(txValorAz.Text);

            double bx = float.Parse(txValorBx.Text);
            double by = float.Parse(txValorBy.Text);
            double bz = float.Parse(txValorBz.Text);

            double powX = Math.Pow((ax - bx),2);
            double powY = Math.Pow((ay - by), 2);
            double powZ = Math.Pow((az - bz), 2);

            double sumXYZ = powX + powY + powZ;

            fDistancia = Math.Sqrt(sumXYZ);

            txValorDistancia.Text = fDistancia.ToString();
        }
    }
}
