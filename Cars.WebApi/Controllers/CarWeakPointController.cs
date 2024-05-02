using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarWeakPointController : Controller
    {
        private readonly ICarWeakPointService _carWeakPointService;

        public CarWeakPointController(ILogger<CarWeakPointController> logger, ICarWeakPointService carWeakPointService)
        {
            _carWeakPointService = carWeakPointService;
        }

        [HttpGet("CarAllWeakPoints/{carId}")]
        public ActionResult Get(Guid carId)
        {
            List<WeakPointDto> weakPointDtos = _carWeakPointService.GetAllDtosByCarId(carId);
            if (!weakPointDtos.Any())
                return BadRequest("Слабые стороны авто не найдены");

            return Ok(weakPointDtos);
        }

        [HttpGet("CarWeakPoint/{id}")]
        public ActionResult Get(int id)
        {
            CarWeakPointReadDto? carWeakPointReadDto = _carWeakPointService.GetDtoById(id);
            if (carWeakPointReadDto == null)
                return BadRequest("Запись не найдена");

            return Ok(carWeakPointReadDto);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CarWeakPointWriteDto carWeakPointDto)
        {
            if (carWeakPointDto == null)
                return BadRequest("У машины не найдены слабые стороны");

            return Ok(_carWeakPointService.CreateById(carWeakPointDto));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(!_carWeakPointService.EntryExisted(id))
                return NotFound();

            _carWeakPointService?.DeleteById(id);
            return Ok("Запись успешно удалена");
        }
    }
}
