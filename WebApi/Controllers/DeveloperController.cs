using DataAccess.EFCorre.Specifications;
using Domain.Entities;
using Domain.Interfaces.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeveloperController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: api/<DeveloperController>
        [HttpGet]
        public List<Developer> Get()
        {
            var result = _unitOfWork.Developers.GetAll().ToList();
            return result;
        }

        // GET api/<DeveloperController>/5
        [HttpGet("{id}")]
        public Developer Get(int id)
        {
            var result = _unitOfWork.Developers.GetById(id);
            return result;
        }

        // POST api/<DeveloperController>
        [HttpPost]
        public int Post([FromBody] Developer value)
        {
            _unitOfWork.Developers.Add(value);
            var result = _unitOfWork.Complete();
            return result;
        }

        // PUT api/<DeveloperController>/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] Developer value)
        {
            var isDev = _unitOfWork.Developers.Find(x => x.Id == id).Any();
            if (isDev)
            {
                _unitOfWork.Developers.Edit(value);
                var result = _unitOfWork.Complete();
                return result;
            }
            return 0;
        }

        // DELETE api/<DeveloperController>/5
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var dev = _unitOfWork.Developers.Find(x => x.Id == id).FirstOrDefault();
            if (dev != null)
            {
                _unitOfWork.Developers.Remove(dev);
                var result = _unitOfWork.Complete();
                return result;
            }
            return 0;
        }

        [HttpGet("specify")]
        public async Task<IActionResult> Specify(int followerNum)
        {
            var specification = new DeveloperWithAddressSpecification(followerNum);
            //var specification = new DeveloperByIncomeSpecification();
            var developers = _unitOfWork.Developers.FindWithSpecificationPattern(specification);
            return Ok(developers);
        }
    }
}
