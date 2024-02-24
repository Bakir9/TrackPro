using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class HomeController : BaseApiController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActivityRepository _activityRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IActivityRepository activityRepository, IMapper mapper )
        {
            _mapper = mapper;
            _activityRepository = activityRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ActivityDTO>>> SidebarActivities()
        {
            var activity = await _activityRepository.GetActivities();
             return Ok(_mapper.Map<IReadOnlyList<Activity>, IReadOnlyList<ActivityDTO>>(activity));
        }

        // [HttpGet]
        // public string GetSidebarActivities()
        // {
        //     return "Request je prosao";
        // }
    }
}