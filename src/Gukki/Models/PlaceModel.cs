using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gukki.Models
{
    // Модель для представленння відділення
    public class PlaceModel
    {
        public int Id { get; init; }

        [DisplayName("*Місто"), Required, Column("city_name", TypeName = "text")]
        public string CityName { get; set; } = null!;

        [DisplayName("*Район"), Required, Column("block_name", TypeName = "text")]
        public string BlockName { get; set; } = null!;

        // Навігаціонне посилання на контакти цього відділення на мапі 
        public int MapsContactId { get; set; }
        public MapsContactModel MapsContact{get;set;}

        // Навігаціонне посилання на контакти цього відділення
        public List<ContactModel> Contacts {get;set;}
    }
}