using System.ComponentModel.DataAnnotations;

namespace RestoManager_SadkaouiMouhamed.Models.RestosModel
{
    public class Avis
    {
        public int CodeAvis { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string NomPersonne { get; set; }

        [Range(1, 5, ErrorMessage = "La note doit être comprise entre 1 et 5.")]
        public int Note { get; set; }

        [StringLength(500, ErrorMessage = "Le commentaire ne peut pas dépasser 500 caractères.")]
        public string Commentaire { get; set; }

        public int NumResto { get; set; }

        public Restaurant LeResto { get; set; }  
    }
}
