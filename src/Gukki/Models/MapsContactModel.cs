using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gukki.Models
{
    // Модель для представленння контактів на мапі
    public class MapsContactModel
    {
        public int Id { get; init; }

        [DisplayName("*Посилання на google maps"), Required, Column("maps_url", TypeName = "text")]
        public string MapsURL { get; set; } = null!;

        [DisplayName("*Повна адреса"), Required, Column("full_address", TypeName = "text")]
        public string FullAddress { get; set; } = null!;

        // Навігаціонне посилання на відділення
        public PlaceModel Place {get;set;}
    }
}