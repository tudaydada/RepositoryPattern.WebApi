using Domain.Entities;

namespace DataAccess.EFCorre.Specifications
{
    public class DeveloperWithAddressSpecification : BaseSpecifcation<Developer>
    {
        public DeveloperWithAddressSpecification(int followerNum) : base(x => x.Followers > followerNum)
        {
            AddInclude(x => x.Projects);
        }
    }
}
