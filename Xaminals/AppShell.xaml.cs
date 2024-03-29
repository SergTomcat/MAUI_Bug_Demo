﻿using System.Windows.Input;
using Xaminals.Views;
using System.Linq;
using System.Collections.Generic;
namespace Xaminals;

public partial class AppShell : Shell
{
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();
    public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));
   
	public AppShell()
	{
		InitializeComponent();
		RegisterRoutes();
		BindingContext = this;


	}

    void RegisterRoutes()
    {
        Routes.Add("monkeydetails", typeof(MonkeyDetailPage));
        Routes.Add("beardetails", typeof(BearDetailPage));
        Routes.Add("catdetails", typeof(CatDetailPage));
        Routes.Add("dogdetails", typeof(DogDetailPage));
        Routes.Add("elephantdetails", typeof(ElephantDetailPage));

	   foreach (var item in Routes)
        {
            Routing.RegisterRoute(item.Key, item.Value);
        }

		Routing.RegisterRoute("kitties", new GenPageNav("cat"));
		Routing.RegisterRoute("doggies", new GenPageNav("dog"));
	}

    //protected override void OnNavigating(ShellNavigatingEventArgs args)
    //{
    //    base.OnNavigating(args);

    //    // Cancel any back navigation
    //    //if (e.Source == ShellNavigationSource.Pop)
    //    //{
    //    //    e.Cancel();
    //    //}
    //}

    //protected override void OnNavigated(ShellNavigatedEventArgs args)
    //{
    //    base.OnNavigated(args);

    //    // Perform required logic
    //}
}


class GenPageNav : RouteFactory
{
	private readonly string type;

	public GenPageNav(string t) : base()
	{
		this.type = t;
	}

	public override Element GetOrCreate()
	{
		return GetOrCreate(null);
	}
	public override Element GetOrCreate(IServiceProvider provider)
	{
		return new GeneralAnimalPage(type);
	}
}
