using System.Threading.Tasks;

namespace APPUCENM.Views;

public partial class PageListPersonas : ContentPage
{
	public PageListPersonas()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.PageInit());
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {

    }

    private void ToolbarItem_Clicked_2(object sender, EventArgs e)
    {

    }

    private void listapersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listapersonas.ItemsSource = await App.Database.GetListaPersonas();
    }
}