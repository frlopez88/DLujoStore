using DLujoStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DLujoStore.ViewModels
{
    public class viewModelCategorias : INotifyPropertyChanged
    {
        public viewModelCategorias() {


            cargarCategorias();


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

        public ObservableCollection<GetCategoriasImagen> listaCategorias { get; set; } = new ObservableCollection<GetCategoriasImagen>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
