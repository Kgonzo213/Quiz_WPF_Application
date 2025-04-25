using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programowanie_Projekt.Model;

namespace Programowanie_Projekt.Model
{
    public class Ask
    {
        public int Id { get; set; }
        public string Category { get; set; }

        public string Question { get; set; }

        public Answer[]? Answers { get; set; }

        public byte[]? Image { get; set; }

        public Ask()
        {
            Answers = new Answer[4]; 
        }



    }
}
