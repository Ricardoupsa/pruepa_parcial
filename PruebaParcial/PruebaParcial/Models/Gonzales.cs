
namespace PruebaParcial.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Gonzales
    {
        [Key]
        [Required]
        public int GonzalesID { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 2)]
        //[DisplayName("Nombre completo")]
        public string FriendofRicardo { get; set; }


        [Required(ErrorMessage = "Ingresar lugar")]
        public Place place { get; set; }


        [EmailAddress(ErrorMessage = "Ingresar email en el formato correcto")]
        public string Email { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Birthdate { get; set; }
    }

    public enum Place
    {
        Bolivia,
        Argentina,
        Colombia,
        Uruguay,
        Venezuela
    }
}