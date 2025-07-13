using Microsoft.AspNetCore.Mvc;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace packers.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var assignments = await _assignmentService.GetAllAssignmentsAsync();
            return Ok(assignments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var assignment = await _assignmentService.GetAssignmentByIdAsync(id);
            if (assignment == null) return NotFound();
            return Ok(assignment);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Assignment assignment)
        {
            var created = await _assignmentService.CreateAssignmentAsync(assignment);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Assignment assignment)
        {
            if (id != assignment.Id) return BadRequest();
            var updated = await _assignmentService.UpdateAssignmentAsync(assignment);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _assignmentService.DeleteAssignmentAsync(id);
            return NoContent();
        }

        [HttpGet("by-driver/{driverId}")]
        public async Task<IActionResult> GetByDriverId(Guid driverId)
        {
            var assignments = await _assignmentService.GetAssignmentsByDriverIdAsync(driverId);
            return Ok(assignments);
        }

        [HttpGet("by-truck/{truckId}")]
        public async Task<IActionResult> GetByTruckId(Guid truckId)
        {
            var assignments = await _assignmentService.GetAssignmentsByTruckIdAsync(truckId);
            return Ok(assignments);
        }

        [HttpGet("by-move-request/{moveRequestId}")]
        public async Task<IActionResult> GetByMoveRequestId(Guid moveRequestId)
        {
            var assignments = await _assignmentService.GetAssignmentsByMoveRequestIdAsync(moveRequestId);
            return Ok(assignments);
        }

        [HttpGet("by-status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var assignments = await _assignmentService.GetAssignmentsByStatusAsync(status);
            return Ok(assignments);
        }
    }
} 