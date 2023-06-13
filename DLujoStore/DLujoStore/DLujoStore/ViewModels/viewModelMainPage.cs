using DLujoStore.Models;
using DLujoStore.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DLujoStore.ViewModels
{
    public class viewModelMainPage : INotifyPropertyChanged
    {

        public viewModelMainPage()
        {

            autenticacion = new Command(async () =>
            {

                string urlNueva = $"https://apex.oracle.com/pls/apex/frlopez0801/store/auth/{NombreUsuario}/{Contrasenia}";

                ConsumoServicio servicio = new ConsumoServicio(urlNueva);

                Autenticacion  auth = await servicio.Get<Autenticacion>();

                if (auth.items.Count == 0)
                {

                    ResultAuth = "Autenticacion Fallida";

                }
                else {

                    if (auth.items[0].es_valido == 1)
                    {
                        ResultAuth = "Autenticacion Exitosa";

                        var pagina = new viewCategorias();
                        Application.Current.MainPage.Navigation.PushAsync(pagina);

                    }


                }

                
                
            });


            redirigirCrearUsuario = new Command(() => {


                var pagina = new viewCreacionUsuarios();
                Application.Current.MainPage.Navigation.PushAsync(pagina);

                
            } );


        }


        string nombreUsuario;

        public string NombreUsuario {
            get => nombreUsuario;
            set { 
                nombreUsuario = value;
                var args = new PropertyChangedEventArgs(nameof(NombreUsuario));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string contrasenia;

        public string Contrasenia
        {
            get => contrasenia;
            set
            {
                contrasenia = value;
                var args = new PropertyChangedEventArgs(nameof(Contrasenia));
                PropertyChanged?.Invoke(this, args);

            }
        }

        string resultAuth;

        public string ResultAuth
        {
            get => resultAuth;
            set
            {
                resultAuth = value;
                var args = new PropertyChangedEventArgs(nameof(ResultAuth));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command autenticacion { get; }

        public Command redirigirCrearUsuario { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
