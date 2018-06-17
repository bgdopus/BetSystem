using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetSystem.Data.Models.Abstract
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
