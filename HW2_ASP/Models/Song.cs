namespace HW2_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Song")]
    public partial class Song
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(50)]
        public string song_name { get; set; }

        [StringLength(50)]
        public string song_author { get; set; }

        [StringLength(50)]
        public string song_path { get; set; }

        public int? id_song_genre { get; set; }

        public int? id_user_add { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
