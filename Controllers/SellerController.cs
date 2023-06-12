using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.Dto;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;

namespace OnlineStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController: Controller
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public SellerController(ISellerRepository sellerRepository, ICountryRepository countryRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Seller>))]
        public IActionResult GetSellers()
        {
            var sellers = _mapper.Map<List<SellerDto>>(_sellerRepository.GetSellers());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(sellers);
        }

        [HttpGet("{sellerId}")]
        [ProducesResponseType(200, Type = typeof(Seller))]
        [ProducesResponseType(400)]
        public IActionResult GetSeller(int sellerId)
        {
            if (!_sellerRepository.SellerExists(sellerId))
            {
                return NotFound();
            }

            var seller = _mapper.Map<SellerDto>(_sellerRepository.GetSeller(sellerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(seller);
        }

        [HttpGet("{sellerId}/product")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Product>))]
        [ProducesResponseType(400)]
        public IActionResult GetProductBySeller(int sellerId)
        {
            if (!_sellerRepository.SellerExists(sellerId))
            {
                return NotFound();
            }

            var products = _mapper.Map<List<ProductDto>>(_sellerRepository.GetProductBySeller(sellerId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateSeller([FromQuery] int countryId, [FromBody] SellerDto sellerCreate)
        {
            if (sellerCreate == null)
            {
                return BadRequest(ModelState);
            }

            var seller = _sellerRepository.GetSellers()
                .Where(s => s.Name.Trim().ToUpper() == sellerCreate.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (seller != null)
            {
                ModelState.AddModelError("", "Seller already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sellerMap = _mapper.Map<Seller>(sellerCreate);

            sellerMap.Country = _countryRepository.GetCountry(countryId);

            if (!_sellerRepository.CreateSeller(sellerMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{sellerId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSeller(int sellerId, [FromBody] SellerDto updatedSeller)
        {
            if (updatedSeller == null)
            {
                return BadRequest(ModelState);
            }

            if (sellerId != updatedSeller.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_sellerRepository.SellerExists(sellerId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var sellerMap = _mapper.Map<Seller>(updatedSeller);

            if (!_sellerRepository.UpdateSeller(sellerMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
