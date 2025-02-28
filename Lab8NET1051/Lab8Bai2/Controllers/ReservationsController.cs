using Lab8Bai2.Models;
using Lab8Bai2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Lab8Bai2.Controllers
{
    
        [Route("api/[controller]")]
        [ApiController]
        public class ReservationsController : ControllerBase
        {
            private readonly IReservationRepository _repository;

            public ReservationsController(IReservationRepository repository)
            {
                _repository = repository;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                var reservations = await _repository.GetAllAsync();
                return Ok(reservations);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetById(int id)
            {
                var reservation = await _repository.GetByIdAsync(id);
                if (reservation == null) return NotFound();
                return Ok(reservation);
            }

            [HttpPost]
            public async Task<IActionResult> Create(Reservation reservation)
            {
                await _repository.AddAsync(reservation);
                return CreatedAtAction(nameof(GetById), new { id = reservation.Id }, reservation);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Reservation reservation)
            {
                if (id != reservation.Id) return BadRequest();
                await _repository.UpdateAsync(reservation);
                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                await _repository.DeleteAsync(id);
                return NoContent();
            }
        }
    }
