using System.ComponentModel.DataAnnotations;

namespace Catcher.Model.Entities
{
    public class ErrorBody
    {
        [Key]
        public string Id { get; set; } = null!;
        public string TypeCode { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int Qty { get; set; }
        public string? Description { get; set; }
    }
}
