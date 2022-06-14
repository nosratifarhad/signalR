using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.Infrastructure.DBEntitys
{

    public partial class TbOnlineUser
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string IpAddress { get; set; }
        [Required] public string Browser { get; set; }
        [Required] public string Country { get; set; }
        [Required] public System.DateTime EntryDate { get; set; }
        public System.DateTime? OutDate { get; set; }
        [Required] public string OS { get; set; }
        [Required] public string Url { get; set; }
    }
}
