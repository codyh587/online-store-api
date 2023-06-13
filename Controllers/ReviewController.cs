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
    public class ReviewController: Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IReviewerRepository _reviewerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ReviewController(
            IReviewRepository reviewRepository,
            IReviewerRepository reviewerRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _reviewerRepository = reviewerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public IActionResult GetReviews()
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviews());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviews);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public IActionResult GetReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var review = _mapper.Map<ReviewDto>(_reviewRepository.GetReview(reviewId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(review);
        }

        [HttpGet("{productId}/product")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewsForAProduct(int productId)
        {
            var reviews = _mapper.Map<List<ReviewDto>>(_reviewRepository.GetReviewsOfAProduct(productId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(reviews);
        }

        [HttpGet("{reviewId}/reviewer")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewAuthor(int reviewId)
        {
            var reviewer = _mapper.Map<ReviewerDto>(_reviewRepository.GetReviewAuthor(reviewId));

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(reviewer);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateReview([FromQuery] int reviewerId, [FromQuery] int productId, [FromBody] ReviewDto reviewCreate)
        {
            if (reviewCreate == null)
            {
                return BadRequest(ModelState);
            }

            var reviews = _reviewRepository.GetReviews()
                .Where(c => c.Title.Trim().ToUpper() == reviewCreate.Title.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (reviews != null)
            {
                ModelState.AddModelError("", "Review title already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewMap = _mapper.Map<Review>(reviewCreate);

            reviewMap.Product = _productRepository.GetProduct(productId);
            reviewMap.Reviewer = _reviewerRepository.GetReviewer(reviewerId);

            if (!_reviewRepository.CreateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{reviewId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateReview(int reviewId, [FromBody] ReviewDto updatedReview)
        {
            if (updatedReview == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewId != updatedReview.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_reviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var reviewMap = _mapper.Map<Review>(updatedReview);

            if (!_reviewRepository.UpdateReview(reviewMap))
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{reviewId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteReview(int reviewId)
        {
            if (!_reviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var reviewToDelete = _reviewRepository.GetReview(reviewId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!_reviewRepository.DeleteReview(reviewToDelete))
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
            }

            return NoContent();
        }
    }
}
