using Microsoft.AspNetCore.Mvc;
using API.Services.Interfaces;
using Shared.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/grade-adjustments")]
    public class GradeAdjustmentController : ControllerBase
    {
        private readonly IGradeAdjustmentService _service;

        public GradeAdjustmentController(IGradeAdjustmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGradeAdjustmentRequest request)
        {
            var result = await _service.CreateAsync(request);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(
            int id,
            UpdateGradeAdjustmentStatusRequest request)
        {
            await _service.UpdateStatusAsync(id, request);
            return Ok();
        }
    }
}
