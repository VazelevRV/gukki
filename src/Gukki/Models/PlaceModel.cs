using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gukki.Models
{
    public class PlaceModel
    {
        public int Id { get; init; }

        [DisplayName("*Місто"), Required, Column("city_name", TypeName = "text")]
        public string CityName { get; set; } = null!;

        [DisplayName("*Район"), Required, Column("block_name", TypeName = "text")]
        public string BlockName { get; set; } = null!;
        public List<ContactModel> Contacts {get;set;}
    }
}