using System.ComponentModel.DataAnnotations;

namespace Catcher.Model.Entities
{
    public class ErrorTitle
    {
        [Key]
        public string Id { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string TypeCode { get; set; } = null!;
        public DateTime ErrorDate { get; set; } = DateTime.MinValue!;
        public string? Memo { get; set; }


        public virtual ICollection<ErrorBody>? ErrorBodys { get; set; }
    }
}
