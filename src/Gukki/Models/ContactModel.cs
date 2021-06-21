using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gukki.Models
{
    public class ContactModel
    {
        public int Id { get; init; }

        [DisplayName("*Назва контакту"), Required, Column("contact_name", TypeName = "text")]
        public string ContactName { get; set; } = null!;

        [DisplayName("*Текст контакту"), Required, Column("contact_text", TypeName = "text")]
        public string ContactText { get; set; } = null!;
        public PlaceModel Place {get;set;}
    }
}