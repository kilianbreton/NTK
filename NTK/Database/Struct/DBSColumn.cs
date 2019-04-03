/*************************************************************************************
 * NTK - Network Transport Kernel                                                    *
 * DBSColumn Class                                                                   *
 * ----------------------------------------------------------------------------------*
 *                                                                                   *
 * LICENSE: This program is free software: you can redistribute it and/or modify     *
 * it under the terms of the GNU General Public License as published by              *
 * the Free Software Foundation, either version 3 of the License, or                 *
 * (at your option) any later version.                                               *
 *                                                                                   *
 * This program is distributed in the hope that it will be useful,                   *
 * but WITHOUT ANY WARRANTY; without even the implied warranty of                    *
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the                     *
 * GNU General Public License for more details.                                      *
 *                                                                                   *
 * You should have received a copy of the GNU General Public License                 *
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.             *
 *                                                                                   *
 * ----------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTK.Database
{

    public enum DBSType
    {
        INT,VARCHAR,TEXT,DATE,
        TINYINT,SMALLINT,
        BUGINT,DECIMAL,
        FLOAT,DOUBLE,REAL,
        BIT,BOOLEAN,SERIAL,
        DATETIME,TIMESTAMP,
        TIME,YEAR,CHAR,
        TINYTEXT,MEDIUMTEXT,
        LONGTEXT,BINARY,VARBINARY,
        TINYBLOB,MEDIUMBLOB,
        BLOB,LONGBLOB,ENUM,SET,
        GEOMETRY,POINT,LINESTRING,
        POLYGON,MULTIPOINT,
        MULTILINESTRING,MULTIPOLYGON,
        GEOMETRYCOLLECTION
    }

    public enum DBSCollation
    {
        armscii8_bin, armscii8_general_ci, ascii_bin,
        ascii_general_ci, big5_bin, big5_chinese_ci,
        binary, cp1250_bin, cp1250_croatian_ci,
        cp1250_czech_cs, cp1250_general_ci,
        cp1250_polish_ci, cp1251_bin, cp1251_bulgarian_ci,
        cp1251_general_ci, cp1251_general_cs, cp1251_ukrainian_ci,
        cp1256_bin, cp1256_general_ci, cp1257_bin,
        cp1257_general_ci, cp1257_lithuanian_ci, cp850_bin,
        cp850_general_ci, cp852_bin, cp852_general_ci, cp866_bin,
        cp866_general_ci, cp932_bin, cp932_japanese_ci,
        dec8_bin, dec8_swedish_ci, eucjpms_bin, eucjpms_japanese_ci,
        euckr_bin, euckr_korean_ci, gb18030_bin,
        gb18030_chinese_ci, gb18030_unicode_520_ci,
        gb2312_bin, gb2312_chinese_ci,
        gbk_bin, gbk_chinese_ci,
        geostd8_bin, geostd8_general_ci, greek_bin,
        greek_general_ci, hebrew_bin, hebrew_general_ci, hp8_bin,
        hp8_english_ci, keybcs2_bin, keybcs2_general_ci,
        koi8r_bin, koi8r_general_ci, koi8u_bin, koi8u_general_ci,
        latin1_bin, latin1_danish_ci, latin1_general_ci,
        latin1_general_cs, latin1_german1_ci, latin1_german2_ci,
        latin1_spanish_ci, latin1_swedish_ci, latin2_bin,
        latin2_croatian_ci, latin2_czech_cs, latin2_general_ci,
        latin2_hungarian_ci, latin5_bin, latin5_turkish_ci,
        latin7_bin, latin7_estonian_cs, latin7_general_ci,
        latin7_general_cs, macce_bin, macce_general_ci,
        macroman_bin, macroman_general_ci, sjis_bin, sjis_japanese_ci,
        swe7_bin, swe7_swedish_ci, tis620_bin, tis620_thai_ci,
        ucs2_bin, ucs2_croatian_ci, ucs2_czech_ci, ucs2_danish_ci,
        ucs2_esperanto_ci, ucs2_estonian_ci, ucs2_general_ci,
        ucs2_general_mysql500_ci, ucs2_german2_ci, ucs2_hungarian_ci,
        ucs2_icelandic_ci, ucs2_latvian_ci, ucs2_lithuanian_ci,
        ucs2_persian_ci, ucs2_polish_ci, ucs2_roman_ci, ucs2_romanian_ci,
        ucs2_sinhala_ci, ucs2_slovak_ci, ucs2_slovenian_ci,
        ucs2_spanish2_ci, ucs2_spanish_ci, ucs2_swedish_ci, ucs2_turkish_ci,
        ucs2_unicode_520_ci, ucs2_unicode_ci, ucs2_vietnamese_ci,
        ujis_bin, ujis_japanese_ci, utf16_bin, utf16_croatian_ci,
        utf16_czech_ci, utf16_danish_ci, utf16_esperanto_ci,
        utf16_estonian_ci, utf16_general_ci, utf16_german2_ci, utf16_hungarian_ci,
        utf16_icelandic_ci, utf16_latvian_ci, utf16_lithuanian_ci,
        utf16_persian_ci, utf16_polish_ci, utf16_roman_ci, utf16_romanian_ci,
        utf16_sinhala_ci, utf16_slovak_ci, utf16_slovenian_ci,
        utf16_spanish2_ci, utf16_spanish_ci, utf16_swedish_ci, utf16_turkish_ci,
        utf16_unicode_520_ci, utf16_unicode_ci, utf16_vietnamese_ci,
        utf16le_bin, utf16le_general_ci, utf32_bin, utf32_croatian_ci,
        utf32_czech_ci,utf32_danish_ci, utf32_esperanto_ci, utf32_estonian_ci,
        utf32_general_ci, utf32_german2_ci, utf32_hungarian_ci,
        utf32_icelandic_ci, utf32_latvian_ci, utf32_lithuanian_ci, utf32_persian_ci,
        utf32_polish_ci, utf32_roman_ci, utf32_romanian_ci,
        utf32_sinhala_ci, utf32_slovak_ci, utf32_slovenian_ci, utf32_spanish2_ci,
        utf32_spanish_ci, utf32_swedish_ci, utf32_turkish_ci,
        utf32_unicode_520_ci, utf32_unicode_ci, utf32_vietnamese_ci, utf8_bin, utf8_croatian_ci,
        utf8_czech_ci, utf8_danish_ci, utf8_esperanto_ci, utf8_estonian_ci,
        utf8_general_ci, utf8_general_mysql500_ci, utf8_german2_ci, utf8_hungarian_ci, utf8_icelandic_ci,
        utf8_latvian_ci, utf8_lithuanian_ci, utf8_persian_ci, utf8_polish_ci,
        utf8_roman_ci, utf8_romanian_ci, utf8_sinhala_ci, utf8_slovak_ci,
        utf8_slovenian_ci, utf8_spanish2_ci, utf8_spanish_ci, utf8_swedish_ci,
        utf8_turkish_ci, utf8_unicode_520_ci, utf8_unicode_ci,
        utf8_vietnamese_ci, utf8mb4_bin, utf8mb4_croatian_ci, utf8mb4_czech_ci,
        utf8mb4_danish_ci, utf8mb4_esperanto_ci, utf8mb4_estonian_ci,
        utf8mb4_general_ci, utf8mb4_german2_ci, utf8mb4_hungarian_ci, utf8mb4_icelandic_ci,
        utf8mb4_latvian_ci, utf8mb4_lithuanian_ci,
        utf8mb4_persian_ci, utf8mb4_polish_ci, utf8mb4_roman_ci,
        utf8mb4_romanian_ci, utf8mb4_sinhala_ci, utf8mb4_slovak_ci, utf8mb4_slovenian_ci,
        utf8mb4_spanish2_ci, utf8mb4_spanish_ci, utf8mb4_swedish_ci, utf8mb4_turkish_ci,
        utf8mb4_unicode_520_ci, utf8mb4_unicode_ci, utf8mb4_vietnamese_ci
    }

    public enum DBSAttribute
    {
        BINARY, UNSIGNED, UNSIGNED_ZEROFILL, CURRENT_TIMESTAMP
    }
    public enum DBSIndex
    {
        PRIMARY,UNIQUE,INDEX,FULLTEXT,SPACIAL,NONE
    }

    /// <summary>
    /// Représente une colonne de base de données
    /// </summary>
    public class DBSColumn
    {
        private String name;
        private DBSType type;
        private DBSCollation collation;
        private DBSIndex index;
        private int length;
        private String defaultValue;
        private bool autoIncrement;
        private bool primaryKey;
        private bool notnull;
        private List<String> values = new List<String>();


        /// <summary>
        /// Création d'une colonne
        /// </summary>
        /// <param name="name">Nom</param>
        /// <param name="type">type de valeur</param>
        /// <param name="length">Taille</param>
        /// <param name="autoIncrement">Incrémentation automatique</param>
        /// <param name="notnull">Non-null</param>
        /// <param name="collation">Interclassement</param>
        /// <param name="defaultValue">Valeur par défaut</param>
        /// <param name="index">Index</param>
        /// <param name="primarykey">Clée primaire</param>
        public DBSColumn(String name, DBSType type, int length, bool autoIncrement, bool notnull=false,
            DBSCollation collation = DBSCollation.utf8_bin,
            String defaultValue=null, DBSIndex index = DBSIndex.NONE, bool primarykey = false)
        {
            this.Name = name;
            this.Type = type;
            this.Length = length;
            this.Index = index;
            this.Collation = collation;
            this.DefaultValue = defaultValue;
            this.AutoIncrement = autoIncrement;
            this.notnull = notnull;
            this.primaryKey = primarykey;
        }

        /// <summary>
        /// Création d'une colonne
        /// </summary>
        /// <param name="name">Nom</param>
        /// <param name="type">Type de valeur</param>
        /// <param name="length">Taille</param>
        /// <param name="autoIncrement">Incrémentation automatique</param>
        /// <param name="index">Index</param>
        /// <param name="primarykey">Clée primaire</param>
        public DBSColumn(String name, DBSType type, int length, bool autoIncrement,
           DBSIndex index, bool primarykey)
        {
            this.Name = name;
            this.Type = type;
            this.Length = length;
            this.Index = index;
            this.AutoIncrement = autoIncrement;
            this.primaryKey = primarykey;
        }

        /// <summary>
        /// Génère un script SQL
        /// </summary>
        /// <returns></returns>
        public String print()
        {
            String ret = "`" + name + "` " + type.ToString().ToLower() + "(" + length + ") " ;
            if (notnull)
            {
                ret = ret + "NOT NULL ";
            }
            else
            {
                ret = ret + "DEFAULT NULL";
            }


            if (autoIncrement) {

                ret = ret + "AUTO_INCREMENT ";
            }
            else
            {
               // ret = ret + "\n";
            }
            return ret;
        }







        /// <summary>
        /// 
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 
        /// </summary>
        public DBSType Type { get => type; set => type = value; }
        /// <summary>
        /// 
        /// </summary>
        public DBSCollation Collation { get => collation; set => collation = value; }
        /// <summary>
        /// 
        /// </summary>
        public DBSIndex Index { get => index; set => index = value; }
        /// <summary>
        /// 
        /// </summary>
        public int Length { get => length; set => length = value; }
        /// <summary>
        /// 
        /// </summary>
        public string DefaultValue { get => defaultValue; set => defaultValue = value; }
        /// <summary>
        /// 
        /// </summary>
        public bool AutoIncrement { get => autoIncrement; set => autoIncrement = value; }
        /// <summary>
        /// 
        /// </summary>
        public List<string> Values { get => values; set => values = value; }
        /// <summary>
        /// 
        /// </summary>
        public bool PrimaryKey { get => primaryKey; set => primaryKey = value; }
    }
}
