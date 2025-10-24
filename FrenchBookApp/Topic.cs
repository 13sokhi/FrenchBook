using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrenchBookApp
{
    public class Topic
    {
        // Scalar properties
        public int TopicId { get; set; }
        public string? TopicName { get; set; }

        // Navigation properties
        public ICollection<Sentence> Sentences { get; set; }
        public ICollection<Paragraph> Paragraphs { get; set; }
    }
}
