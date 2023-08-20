//using AutoMapper;
//using LibraryApp.Data.Dto;
//using LibraryApp.Data.Model;
//using LibraryApp.Services.AcademicYearService;
//using LibraryApp.Services.FalcutyService;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace LibraryApp.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class FalcutyController : ControllerBase
//    {
//        private readonly IFalcutyService _falcutyService;
//        private readonly IMapper _mapper;
//        public FalcutyController(IFalcutyService falcutyService, IMapper mapper) 
//        {
//            _falcutyService = falcutyService;
//            _mapper = mapper;
//        }

//        [HttpGet]
//        public async Task<IActionResult> GetFalcuty()
//        {
//            var falcuty = await _falcutyService.GetFalcuties();

//            var falcutyDto = _mapper.Map<List<Falcuty>>(falcuty);

//            return Ok(falcutyDto);
//        }

//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetFalcutyById(int id)
//        {
//            var falcuty = await _falcutyService.GetFalcutyById(id);

//            var falcutyDto = _mapper.Map<Falcuty>(falcuty);

//            return Ok(falcutyDto);
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddFalcuty(FalcutyDto falcuty)
//        {

//            var falcutyAdd= _mapper.Map<Falcuty>(falcuty);

//            var falcutyMap = await _falcutyService.AddFalcuty(falcutyAdd);

//            return Ok(falcutyMap);


//        }

//        [HttpPut("{id}")]
//        public async Task<IActionResult> UpdateFalcuty(int id, FalcutyDto falcuty)
//        {
//            var falcutyUpdate = _mapper.Map<Falcuty>(falcuty);

//            var falcutyMap = await _falcutyService.UpdateFalcuty(id, falcutyUpdate);

//            return Ok(falcutyMap);
//        }

//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteFalcuty(int id)
//        {
//            var falcuty = await _falcutyService.DeleteFalcuty(id);

//            return Ok(falcuty);
//        }

//        [HttpGet("search")]
//        public async Task<IActionResult> Search(string searchString)
//        {
//            var search = await _falcutyService.Search(searchString);

//            return Ok(search);
//        }
//    }
//}
