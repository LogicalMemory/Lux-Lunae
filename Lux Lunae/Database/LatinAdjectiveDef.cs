﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Lux_Lunae.Resources.Database
{
    [Table("LatinAdjectiveDef")]
    public class LatinAdjectiveDef
    {
        public LatinAdjectiveDef() { }
        public LatinAdjectiveDef(List<String> s)
        {
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

        [MaxLength(50)]
        public string Definition { get; set; }
        public byte Gender { get; set; }
        public byte Declension { get; set; }

        [MaxLength(250)]
        public string Cases { get; set; }

        [MaxLength(50)]
        public string Comparitive { get; set; }

        [MaxLength(50)]
        public string Superlative { get; set; }

        [MaxLength(50)]
        public string SemanticGroup { get; set; }

        [MaxLength(50)]
        public string FrequencyRank { get; set; }


        public bool Generated {  get; set; }

        public string[][] extractCases()
        {
            return null;
        }
    }
}
