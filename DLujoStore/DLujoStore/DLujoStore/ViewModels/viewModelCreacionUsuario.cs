using DLujoStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DLujoStore.ViewModels
{
    public class viewModelCreacionUsuario : INotifyPropertyChanged
    {



        public viewModelCreacionUsuario() {


            crearUsuario = new Command(async () => {


                if (Contrasenia != ConfirmacionContrasenia)
                {

                    Application.Current.MainPage.DisplayAlert("Error", "Contraseñas no coinciden", "OK");

                }
                else {


                    ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/frlopez0801/store/usuarios");

                    NuevoUsuarioRequest datos = new NuevoUsuarioRequest()
                    {
                        app_user= NombreUsuario, 
                        pass = Contrasenia
                    };

                    NuevoUsuarioResponse responose = await servicio.PostAsync<NuevoUsuarioResponse>(datos);

                    if (   responose != null ) {

                        Application.Current.MainPage.DisplayAlert("Mensaje", responose.mensaje , "OK");

                    }

                }
               


            
            } );



        }


        string nombreUsuario;

        public string NombreUsuario
        {
            get => nombreUsuario;
            set
            {
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

        string confirmacionContrasenia;

        public string ConfirmacionContrasenia
        {
            get => confirmacionContrasenia;
            set
            {
                confirmacionContrasenia = value;
                var args = new PropertyChangedEventArgs(nameof(ConfirmacionContrasenia));
                PropertyChanged?.Invoke(this, args);

            }
        }

        public Command crearUsuario { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
