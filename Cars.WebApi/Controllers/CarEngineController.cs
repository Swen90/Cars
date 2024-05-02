using Cars.Domain.Interfaces;
using Cars.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cars.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarEngineController : Controller
    {
        private readonly ICarEngineService _carEngineService;

        public CarEngineController(ILogger<CarEngineController> logger, ICarEngineService carEngineService)
        {
            _carEngineService = carEngineService;
        }

        [HttpGet]
        public ActionResult Get(Guid carId)
        {
            List<EngineReadDto>? engineDtos = _carEngineService.GetAllByCarId(carId);
            if (!engineDtos.Any())
                return BadRequest("Список пуст");

            int pageCount;
            int totalCount = engineDtos.Count();
            int page = 2; ///Comment: Количество элементов в странице

            if (totalCount % 2 == 0)
            {
                pageCount = totalCount / page; ///Comment: Количество страниц для четного числа
            }
            else
            {
                pageCount = (totalCount / page) + 1; ///Comment: Количество страниц для нечетного числа
            }

            ResponseList<List<EngineReadDto>> responceList = new ResponseList<List<EngineReadDto>>(engineDtos, page, pageCount, totalCount);

            return Ok(engineDtos);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CarEngineWriteDto carEngineWriteDto)
        {
            if (carEngineWriteDto == null)
                return BadRequest("Не выбран двигатель для добавления");

            return Ok(_carEngineService.CreateByCarId(carEngineWriteDto));
        }

        [HttpDelete]
        public ActionResult Delete(CarEngineWriteDto carenginewritedto)
        {
            _carEngineService.DeleteById(carenginewritedto);
            return Ok("Удаление успешно");
        }
    }
}
