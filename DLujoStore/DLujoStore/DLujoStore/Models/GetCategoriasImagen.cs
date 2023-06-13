using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace DLujoStore.Models
{
    public class GetCategoriasImagen
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string fotoBase64 { get; set; }
        public byte [] fotoBytes { get; set; }
        public ImageSource imagen { get; set; }

        public void convertirImagen() {

             fotoBytes = Convert.FromBase64String(fotoBase64);
            imagen = ImageSource.FromStream(() => new MemoryStream(fotoBytes));

        }

    }
}
