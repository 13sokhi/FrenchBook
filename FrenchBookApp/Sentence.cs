using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenchBookApp
{
    public class Sentence
    {
        // Scalar properties
        public int SentenceId { get; set; }
        public string? EnglishText { get; set; }
        public string? FrenchText {  get; set; }
        public int TopicId { get; set; }

        // Navigation properties
        public Topic Topic { get; set; }
    }
}
