using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DLujoStore.Models
{
    public class ConsumoServicio
    {

        public string url { get; set; }

        public ConsumoServicio( string newUrl ) {

            url = newUrl;


        }

        public async Task<T> Get<T>() {

            try {

                HttpClient cliente = new HttpClient();
                
                var response = await cliente.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.OK && response != null ) { 
                

                    var jsonString = await response.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jsonString);

                }


            }
            catch
            {
                 Application.Current.MainPage.DisplayAlert("Error", "Error al consumir web service", "Cancelar");
                
            }

            return default(T);
        }

    }
}
