using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gukki.Models
{
    public class Schedule
    {
        public int Id { get; init; }

        [DisplayName("*Індекс порядку відображення"),Required, Column("order_index", TypeName = "integer")]
        public int OrderIndex{get;set;} = 1;

        [DisplayName("*Назва дня тижня"), Required, Column("weekday_name", TypeName = "text")]
        public string WeekdayName { get; set; } = null!;

        [DisplayName("*Час відчинення"), Required, Column("open_time", TypeName = "text")]
        public string OpenTime {get;set;} = null!;

        [DisplayName("*Час зачинення"), Required, Column("close_time", TypeName = "text")]
        public string CloseTime {get;set;} = null!;
    }
}