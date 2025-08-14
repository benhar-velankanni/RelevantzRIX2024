using System.ComponentModel.DataAnnotations;

namespace NameService.Model
{
    public class Name
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}
