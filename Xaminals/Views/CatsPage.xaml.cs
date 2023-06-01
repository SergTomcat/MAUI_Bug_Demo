using Xaminals.Models;

namespace Xaminals.Views
{
     public partial class CatsPage : ContentPage
     {


          public CatsPage()
          {
               this.BindingContext = this;
               InitializeComponent();
          }


          public IEnumerable<Animal> Cats => Data.CatData.Cats;

          public int ItemThreshold { get; set; } = 1;


	   async void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string catName = (e.CurrentSelection.FirstOrDefault() as Animal).Name;
            // The following route works because route names are unique in this application.
            await Shell.Current.GoToAsync($"catdetails?name={catName}");
            // The full route is shown below.
            // await Shell.Current.GoToAsync($"//animals/domestic/cats/catdetails?name={catName}");
        }

		private void ActionFormCollection_RemainingItemsThresholdReached(object sender, EventArgs e)
		{

		}
	}
}
