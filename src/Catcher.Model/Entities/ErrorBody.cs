using System.ComponentModel.DataAnnotations;

namespace Catcher.Model.Entities
{
    public class ErrorBody
    {
        [Key]
        public string TypeCode { get; set; } = null!;
        public string Type { get; set; } = null!;
        public int Qty { get; set; }
        public string? Description { get; set; }

        public virtual ErrorTitle ErrorTitle { get; set; } = null!;
    }
}
