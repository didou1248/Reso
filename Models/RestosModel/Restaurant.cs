using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestoManager_SadkaouiMouhamed.Models.RestosModel
{
    public class Restaurant
    {
        public int CodeResto { get; set; }

        [Required]
        [StringLength(20)]
        public string NomResto { get; set; }

        [StringLength(20)]
        public string Specialite { get; set; }

        [StringLength(20)]
        public string Ville { get; set; }

        [StringLength(8)]
        public string Tel { get; set; }

        public int NumProp { get; set; }

        public Proprietaire LeProprio { get; set; }

        // Propriété de navigation vers les avis
        public ICollection<Avis> LesAvis { get; set; }  // Relation 1-* avec Avis
    }
}
