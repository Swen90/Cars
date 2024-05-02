using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarStrongPointController : Controller
    {
        private readonly ICarStrongPointService _carStrongPointService;

        public CarStrongPointController(ILogger<CarController> logger, ICarStrongPointService carStrongPointService)
        {
            _carStrongPointService = carStrongPointService;
        }

        [HttpGet()] ///Comment: Название в атрибуте и во входной переменной get должны быть одинаковы, чтобы не писать дважды и чтобы значение с атрибута перешло в параметр метода
        public ActionResult Get([FromQuery(Name = "carId")] Guid carId) ///Comment: Это способ получения querry параметров, в адресной строке они указываются после знака вопроса
        {
            List<StrongPointDto> strongPointDtos = _carStrongPointService.GetAllDtosByCarId(carId);
            if (!strongPointDtos.Any())
                return BadRequest($"Сильные стороны авто не найдены");

            return Ok(strongPointDtos);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            CarStrongPointReadDto? carStrongPointReadDto = _carStrongPointService.GetDtoById(id);
            if (carStrongPointReadDto == null)
                return BadRequest("Запись не найдена");

            return Ok(carStrongPointReadDto);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CarStrongPointWriteDto carStrongPointDto)
        {
            if (carStrongPointDto == null)
                return BadRequest("У машины не найдены сильные стороны");

            return Ok(_carStrongPointService.CreateById(carStrongPointDto));
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_carStrongPointService.EntryExisted(id)) ///Comment: Ппроверка на существующий id записи в БД
                return NotFound(); ///Comment: Http (404)

            _carStrongPointService?.DeleteById(id);
            return NoContent(); ///Comment: Нет сообщения. Ответ в виде Http кода (204)
        }
    }
}
