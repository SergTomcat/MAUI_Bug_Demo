namespace Xaminals.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Number
{
	public Number(string title, string url)
	{ 
		Title= title;
		ImageUrl = url;
	}
	public string Title { get; set; }
	public string ImageUrl { get; set; }
}

public class NumbersVM: INotifyPropertyChanged
{
	ObservableCollection<Number> numArr = null;

	public ObservableCollection<Number> NumbersArray
	{
		get => numArr;
		set
		{
			SetProperty(ref numArr, value);
			//_filteredItems = value;
		}
	}

	ObservableCollection<Number> numArr2 = null;

	public ObservableCollection<Number> NumbersArray2
	{
		get => numArr2;
		set
		{
			SetProperty(ref numArr2, value);
			//_filteredItems = value;
		}
	}


	#region INotifyPropertyChanged
	public event PropertyChangedEventHandler PropertyChanged;
	protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
	{
		var changed = PropertyChanged;
		if (changed == null)
			return;

		changed.Invoke(this, new PropertyChangedEventArgs(propertyName));

	}
	protected bool SetProperty<T>(ref T backingStore, T value,
		    [CallerMemberName] string propertyName = "",
		    Action onChanged = null)
	{
		if (EqualityComparer<T>.Default.Equals(backingStore, value))
			return false;

		backingStore = value;
		onChanged?.Invoke();
		OnPropertyChanged(propertyName);
		return true;
	}
	#endregion
}


public partial class NumbersList : ContentPage
{
	NumbersVM vm;
	public NumbersList()
	{
		
		this.BindingContext = vm = new NumbersVM();

		InitializeComponent();
	}


	protected override void OnAppearing()
	{
		base.OnAppearing();

		Task.Run(LoadData);


	}

	void LoadData()
	{
		var arr = new Number[] {
			new ("Zero", null),
			new ("One", "https://upload.wikimedia.org/wikipedia/commons/8/87/TVE_La1_-_Logo_2008.png"),
			new ("Two", "https://m.media-amazon.com/images/I/71DNNuEwyUL._SY879_.jpg"),
			new ("Three", "https://numerograph.files.wordpress.com/2020/02/number-3.jpg"),
			new ("Four", "https://creazilla-store.fra1.digitaloceanspaces.com/cliparts/7811756/number-four-clipart-md.png"),
			new ("Five", "https://www.pngarts.com/files/2/Number-5-Picture.png"),
			new ("Six", null),
			new ("Seven", null),
			new ("One", "https://upload.wikimedia.org/wikipedia/commons/8/87/TVE_La1_-_Logo_2008.png"),
			new ("Two", "https://m.media-amazon.com/images/I/71DNNuEwyUL._SY879_.jpg"),
			new ("Three", "https://numerograph.files.wordpress.com/2020/02/number-3.jpg"),
			new ("Four", "https://creazilla-store.fra1.digitaloceanspaces.com/cliparts/7811756/number-four-clipart-md.png"),
			new ("Five", "https://www.pngarts.com/files/2/Number-5-Picture.png"),

		};


		var arr2 = new Number[] {
			new ("Zero", null),
			new ("One", "https://upload.wikimedia.org/wikipedia/commons/8/87/TVE_La1_-_Logo_2008.png"),
			new ("Zero", null),
			new ("One", "https://upload.wikimedia.org/wikipedia/commons/8/87/TVE_La1_-_Logo_2008.png"),
			new ("Two", "https://m.media-amazon.com/images/I/71DNNuEwyUL._SY879_.jpg"),
			new ("Six", null),
			new ("Seven", null),
			
			new ("Three", "https://numerograph.files.wordpress.com/2020/02/number-3.jpg"),
			new ("One", "https://upload.wikimedia.org/wikipedia/commons/8/87/TVE_La1_-_Logo_2008.png"),
			new ("Two", "https://m.media-amazon.com/images/I/71DNNuEwyUL._SY879_.jpg"),
			
		};


		vm.NumbersArray = new ObservableCollection<Number>(arr2);

		vm.NumbersArray2 = new ObservableCollection<Number>(arr2);
	}
	

}
