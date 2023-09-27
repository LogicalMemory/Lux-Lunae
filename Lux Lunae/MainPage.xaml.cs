namespace Lux_Lunae
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
            CounterBtn.Clicked += OnCounterClicked;
            SaveBtn.Clicked += OnSaveBtnClicked;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnSaveBtnClicked(object sender, EventArgs e)
        {
            SavedTextLabel.Text = TextEditor.Text;
        }
    }
}