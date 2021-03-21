using ShopApp.Infrastructure;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopApp.Data.Entities
{
    [Table("BlogTags")]
    public class BlogTag : DomainEntity<string>
    {
        public int BlogId { get; set; }
        public string TagId { get; set; }

        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }

        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}