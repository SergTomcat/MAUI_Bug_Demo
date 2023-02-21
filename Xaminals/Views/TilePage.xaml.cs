using Xaminals.Data;
using Xaminals.Models;

namespace Xaminals.Views;

public partial class TilePage : ContentPage
{

	public IList<Animal> Items { get; set; }

	public TilePage()
	{
		this.BindingContext= this;
		InitializeComponent();
	}


	protected override void OnAppearing()
	{
		base.OnAppearing();

		//var curLayout = new GridItemsLayout(3, ItemsLayoutOrientation.Vertical);
			
		//ItemsCollectionView.SetValue(CollectionView.ItemsLayoutProperty, curLayout);


		IList<Animal> items = MonkeyData.Monkeys;







		Items = items;

		OnPropertyChanged(nameof(Items));


	}


}