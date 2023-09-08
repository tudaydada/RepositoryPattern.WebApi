using Domain.Entities;

namespace DataAccess.EFCorre.Specifications
{
    public class DeveloperByIncomeSpecification : BaseSpecifcation<Developer>
    {
        public DeveloperByIncomeSpecification()
        {
            AddOrderByDescending(x => x.Followers);
        }
    }
}
