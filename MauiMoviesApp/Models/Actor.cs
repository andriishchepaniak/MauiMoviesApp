using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiMoviesApp.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profile_Path { get; set; }
        public string Character { get; set; }
        public string Biography { get; set; }
        public string Birthday { get; set; }
        public string Place_Of_Birth { get; set; }
    }
}
