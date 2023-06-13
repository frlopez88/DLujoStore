﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DLujoStore.Models
{


    public class ItemCategoria
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string foto { get; set; }
    }

    public class LinkCategoria
    {
        public string rel { get; set; }
        public string href { get; set; }
    }

    public class GetCategoriasResponse
    {
        public List<ItemCategoria> items { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int count { get; set; }
        public List<LinkCategoria> links { get; set; }
    }

}
