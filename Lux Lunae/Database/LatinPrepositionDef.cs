using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Lux_Lunae.Resources.Database
{
    [Table("LatinPrepositionDef")]
    public class LatinPrepositionDef
    {
        public LatinPrepositionDef() { }
        public LatinPrepositionDef(List<String> s) {
            // "ā ab abs","from, by (+abl.)",Preposition,Place,21
            //word, def, group, freq, pos, extrapos
          
            Word = s[0];
            Definition = s[1];
            SemanticGroup = s[2];
            FrequencyRank = s[3];
            TakesCase = s[1];
            Generated = true;
        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Word { get; set; }

        [MaxLength(250)]
        public string TakesCase { get; set; }

        [MaxLength(250)]
        public string Definition { get; set; }

        [MaxLength(50)]
        public string SemanticGroup { get; set; }

        [MaxLength(50)]
        public string FrequencyRank { get; set; }

        public bool Generated { get; set; }


    }
}
