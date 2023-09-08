using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace DataAccess.EFCorre.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
