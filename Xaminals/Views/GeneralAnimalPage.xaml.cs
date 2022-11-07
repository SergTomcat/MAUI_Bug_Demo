namespace Xaminals.Views;

public partial class GeneralAnimalPage : ContentPage
{
	public string CurType { get; set; }
	public GeneralAnimalPage(string type)
	{
		CurType = type;

		InitializeComponent();
	}

	public GeneralAnimalPage()
	{
		CurType = "unknown";

		InitializeComponent();
	}
}