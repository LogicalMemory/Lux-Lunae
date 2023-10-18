using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using SQLite;

namespace Lux_Lunae.Resources.Database
{
    [Table("LatinVerbDef")]
    public class LatinVerbDef
    {
        public LatinVerbDef() { }
        public LatinVerbDef(List<String> s) {
            Word = s[0];
            Definition = s[1];
            SemanticGroup = s[2];
            FrequencyRank = s[3];
            Generated = true;
        }

        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Word { get; set; }

        [MaxLength(50)]
        public string Parts { get; set; }

        [MaxLength(250)]
        public string Definition { get; set; }

        public bool IsIrregular { get; set; }
        public bool IsDeponent { get; set; }

        [MaxLength(500)]
        public string ActiveIndicative { get; set; }

        [MaxLength(500)]
        public string PassiveIndicative { get; set; }

        [MaxLength(500)]
        public string ActiveSubjunctive { get; set; }

        [MaxLength(500)]
        public string PassiveSubjunctive { get; set; }

        [MaxLength(500)]
        public string Infinitive { get; set; }

        [MaxLength(500)]
        public string Participle { get; set; }

        [MaxLength(100)]
        public string Imperative { get; set; }

        [MaxLength(100)]
        public string Gerund { get; set; }

        public bool Generated { get; set; }

        [MaxLength(50)]
        public string SemanticGroup { get; set; }

        [MaxLength(50)]
        public string FrequencyRank { get; set; }


        public string[][][] extractAI() {
            return null;
        }
        public string[][][] extractPI()
        {
            return null;
        }
        public string[][][] extractAS()
        {
            return null;
        }
        public string[][][] extractPS()
        {
            return null;
        }
        public string[][] extractInf()
        {
            return null;
        }
        public string[][] extractPar()
        {
            return null;
        }
        public string[][] extractImp()
        {
            return null;
        }
        public string[] extractGer()
        {
            return null;
        }
    }
}
