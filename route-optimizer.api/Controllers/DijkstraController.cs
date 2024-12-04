using Microsoft.AspNetCore.Mvc;
using route_optimizer.api.Requests;
using route_optimizer.api.Responses;
using route_optimizer.api.Services;

namespace route_optimizer.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DijkstraController : ControllerBase
    {
    

        private readonly ILogger<DijkstraController> _logger;
        private readonly ShortestPathService _shortestPathService;

        public DijkstraController(ILogger<DijkstraController> logger)
        {
            _logger = logger;
            _shortestPathService = new ShortestPathService();
        }


        [HttpPost("GetShortestPath")]
        public IActionResult CalculateShortestPath([FromBody] PathRequest request)
        {

            try
            {
                if (string.IsNullOrEmpty(request.From) || string.IsNullOrEmpty(request.To))
                {
                    //return BadRequest("Both From and To nodes are required.");
                    return BadRequest(ApiResponse<object>.ErrorResponse("Both From and To nodes are required"));
                }

                var result = _shortestPathService.CalculateShortestPath(request.From, request.To);


                var data = result;

                // Return successful response
                return Ok(ApiResponse<object>.SuccessResponse(data));
            }
            catch (ArgumentException ex)
            {
                // Handle specific exceptions
                return BadRequest(ApiResponse<object>.ErrorResponse(ex.Message));
            }
            catch (Exception ex)
            {
                // Handle unexpected exceptions
                return StatusCode(500, ApiResponse<object>.ErrorResponse("An unexpected error occurred."));
            }
    
        }

    }
}
