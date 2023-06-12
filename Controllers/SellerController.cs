using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineStoreAPI.Dto;
using OnlineStoreAPI.Interfaces;
using OnlineStoreAPI.Models;
using OnlineStoreAPI.Repository;

namespace OnlineStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController: Controller
    {
        private readonly ISellerRepository _sellerRepository;
        private readonly IMapper _mapper;

        public SellerController(ISellerRepository sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
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

        // TODO is this wrong?
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
    }
}
