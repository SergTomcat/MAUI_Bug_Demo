using Xaminals.ViewModels;

namespace Xaminals.Views
{
    public partial class MonkeyDetailPage : ContentPage
    {
        public MonkeyDetailPage()
        {
            InitializeComponent();
            BindingContext = new MonkeyDetailViewModel();
        }

          private async void Btn_DeeperClick(object sender, EventArgs e)
          {
			await Shell.Current.GoToAsync($"///elephants");
		}

          private void Btn_Deeper2Click(object sender, EventArgs e)
          {
               Navigation.PushAsync(new CatsPage());
          }
     }
}