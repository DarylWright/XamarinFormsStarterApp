using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProtoApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BonusPage : ContentPage
	{
		public BonusPage ()
		{
			InitializeComponent ();
		}

	    public async void GetBonus_Clicked(object sender, EventArgs e)
	    {
	        
	    }
        
        protected override void OnAppearing()
	    {
	        
	    }
	}
}