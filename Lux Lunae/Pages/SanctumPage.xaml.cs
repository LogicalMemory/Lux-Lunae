namespace Lux_Lunae
{
    public partial class SanctumPage : ContentPage
    {
        int count = 0;

        public SanctumPage()
        {
            InitializeComponent();
            CounterBtn.Clicked += OnCounterClicked;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

        }
    }
}
//public const double MyFontSize = 28;
//x:Static Member=mycdoe:MainPage.MyFontSize