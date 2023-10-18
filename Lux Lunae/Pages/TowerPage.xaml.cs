using Lux_Lunae.Pages.TowerGraphics;

namespace Lux_Lunae
{
    public partial class TowerPage : ContentPage
    {

        public TowerPage()
        {
            InitializeComponent();
            button.Clicked += OnButtonClicked;
        }

        private void OnButtonClicked(object sender, EventArgs e) {

        }

    }
}