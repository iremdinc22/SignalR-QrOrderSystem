using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR.EntityLayer.Entities;

public class Notification
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // 🚀 otomatik artan
    public int NotificationID { get; set; }
    public string Type { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}