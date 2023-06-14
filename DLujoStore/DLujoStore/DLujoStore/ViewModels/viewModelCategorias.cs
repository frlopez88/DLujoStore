using DLujoStore.Models;
using DLujoStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace DLujoStore.ViewModels
{
    public class viewModelCategorias : INotifyPropertyChanged
    {
        public viewModelCategorias() {


            cargarCategorias();

            SelecccionCategoria = new Command(() => {

                var pagina = new viewArticulos();
                var viewModelPagina = new viewModelArticulosCategoria(CategoriaSeleccionada.id);
                pagina.BindingContext = viewModelPagina;

                Application.Current.MainPage.Navigation.PushAsync(pagina);


            } );


        }

        public async void cargarCategorias() {

            ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/frlopez0801/store/categorias");
            GetCategoriasResponse responseCategoria = await servicio.Get<GetCategoriasResponse>();


            foreach (ItemCategoria x in responseCategoria.items) {

                GetCategoriasImagen imgTmp = new GetCategoriasImagen() { 
                
                    id = x.id,
                    nombre =x.nombre,
                    fotoBase64 = x.foto
                    
                };

                imgTmp.convertirImagen();

                listaCategorias.Add(imgTmp);


            }

        }

        GetCategoriasImagen categoriaSeleccionada;

        public GetCategoriasImagen CategoriaSeleccionada {

            get => categoriaSeleccionada;

            set {

                categoriaSeleccionada = value;
                var args = new PropertyChangedEventArgs(nameof(CategoriaSeleccionada));
                PropertyChanged?.Invoke(this, args);



            }
        }

        public ObservableCollection<GetCategoriasImagen> listaCategorias { get; set; } = new ObservableCollection<GetCategoriasImagen>();

        public Command SelecccionCategoria { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
