using Newtonsoft.Json;
using SalgueroEjemploAPI.Model;

namespace SalgueroEjemploAPI.Views;

public partial class Weather : ContentPage
{
	public Weather()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		string latitud = lat.Text;
        string longitud = lon.Text;
		if (Connectivity.NetworkAccess==NetworkAccess.Internet)
		{
			using(var client = new HttpClient())
			{
				string url = $"https://api.openweathermap.org/data/2.5/weather?lat=" + latitud + "&lon=" + longitud + "&appid=c81e8290e3f10714e469ebf65309edab";
                var response = await client.GetAsync(url);
				if (response.IsSuccessStatusCode) 
				{
					var json = await response.Content.ReadAsStringAsync();
					var clima = JsonConvert.DeserializeObject<Rootobject>(json);
					var pais = JsonConvert.DeserializeObject<Sys>(json); 
					weatherlabelSalguero.Text = clima.weather[0].main;
                    citylabelSalguero.Text = clima.name;
					countrylabelSalguero.Text = pais.country;
                }
			}
			
		}
    }
}