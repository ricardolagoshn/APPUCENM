using System.Threading.Tasks;

namespace APPUCENM.Views;

public partial class PageInit : ContentPage
{
    FileResult filefoto = null;

	public PageInit()
	{
		InitializeComponent();
	}

    private async Task<String> ImageBase64()
    {
        if (filefoto != null)
        {
            using (var stream = await filefoto.OpenReadAsync())
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    await stream.CopyToAsync(ms);
                    byte[] data = ms.ToArray();
                    return Convert.ToBase64String(data);
                }
            }
        }

        return null;
    }

    private async void btnprocesar_Clicked(object sender, EventArgs e)
    {
        var persona = new Models.Personas
        {
            Nombres = nombres.Text,
            Apellidos = apellidos.Text,
            FechaNac = fechanac.Date,
            Telefono= telefono.Text,
            Correo = correo.Text,
            Foto = await ImageBase64()
        };

        if (await App.Database.GuardarPersona(persona) > 0)
        {
            await DisplayAlert("Aviso", "Persona Ingresada con exito", "OK");
        }
        else
        {
            await DisplayAlert("Aviso", "Datos no Registrados", "OK");
        }

        var pagina = new Views.PageListPersonas();
        await Navigation.PushAsync(pagina);

    }

    private async void btnfoto_Clicked(object sender, EventArgs e)
    {
        try
        {
            filefoto = await MediaPicker.Default.CapturePhotoAsync();

            if (filefoto != null) 
            {
                var stream = await filefoto.OpenReadAsync();
                foto.Source = ImageSource.FromStream(() => stream);
            }
        }
        catch (Exception ex) 
        {
            await DisplayAlert("Error", $"No se puedo capturar imagen {ex.Message}", "OK");
        }

    }
}