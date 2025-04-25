using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programowanie_Projekt.Model
{
    public class Answer
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int IsCorrect { get; set; }
        public int QuestionId { get; set; }
    }
}
