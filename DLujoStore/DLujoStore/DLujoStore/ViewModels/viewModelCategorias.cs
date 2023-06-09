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

                listaCategorias.Add(x);


            }

        }

        public ObservableCollection<ItemCategoria> listaCategorias { get; set; } = new ObservableCollection<ItemCategoria>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
