using Api.Data.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressEventController : ControllerBase
    {
        private readonly IAddressEventRepository _addressEventRepository;

        public AddressEventController(IAddressEventRepository addressEventRepository)
        {
            _addressEventRepository = addressEventRepository;
        }

        [HttpGet(Name = "GetAddressEvent")]
        public IEnumerable<AddressEvent> GetEvents()
        {
            return _addressEventRepository.GetAll();
        }
    }
}
