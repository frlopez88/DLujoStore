using DLujoStore.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace DLujoStore.ViewModels
{
    public class viewModelArticulosCategoria : INotifyPropertyChanged
    {

        public viewModelArticulosCategoria( int IdCategoria ) { 
        
            this.idCategoria = IdCategoria;
            getArticulos();

        }

        public viewModelArticulosCategoria() { 
        
        
        }


        public async void getArticulos() {

            ConsumoServicio servicio = new ConsumoServicio("https://apex.oracle.com/pls/apex/frlopez0801/store/articulos/categoria/"+ idCategoria);
            GetArticuloCategoriaResponse responseCategoria = await servicio.Get<GetArticuloCategoriaResponse>();

            foreach (ItemArticuloCategoria x in responseCategoria.items)
            {

                GetArticuloCategoriaImagen imgTmp = new GetArticuloCategoriaImagen()
                {

                    id_articulo = x.id_articulo,
                    nombre_articulo = x.nombre_articulo,
                    fotoBase64 = x.foto

                };

                imgTmp.convertirImagen();

                listaArticulo.Add(imgTmp);


            }


        }

        int idCategoria;

        public ObservableCollection<GetArticuloCategoriaImagen> listaArticulo { get; set; } = new ObservableCollection<GetArticuloCategoriaImagen>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
