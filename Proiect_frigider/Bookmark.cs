using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_frigider
{
    public class Bookmark
    {
        public int id { get; set; }
        public int id_user { get; set; }
        public int id_reteta { get; set; }
        public int id_reteta_api { get; set; }


    public Bookmark(int id, int id_user, int id_reteta, int id_reteta_api)
        {
            this.id = id;
            this.id_user = id_user; 
            this.id_reteta = id_reteta;    
            this.id_reteta_api = id_reteta_api;      
        }
    }
}
