using System;
using System.Collections.Generic;
using System.Text;

namespace DLujoStore.Models
{
 

    public class ItemArticuloCategoria
    {
        public int id_articulo { get; set; }
        public string nombre_articulo { get; set; }
        public string foto { get; set; }
    }

    

    public class GetArticuloCategoriaResponse
    {
        public List<ItemArticuloCategoria> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<Link> links { get; set; }
    }

}
