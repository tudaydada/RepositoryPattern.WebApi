using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Developer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public virtual Project Projects { get; set; }
    }
}
