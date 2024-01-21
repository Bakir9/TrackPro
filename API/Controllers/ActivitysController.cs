using System.Diagnostics;
using API.DTO;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Activity = Core.Entities.Activity;

namespace API.Controllers
{
    public class ActivitysController : BaseApiController
    {
        private readonly ILogger<ActivitysController> _logger;
        public readonly IActivityRepository _actRepository;
        public readonly IMapper _mapper;

        public ActivitysController(IActivityRepository actRepository, ILogger<ActivitysController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _actRepository = actRepository;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<ActionResult<ActivityDTO>> Add(Core.Entities.Activity activity)
        {
            if(activity is null) return NotFound();
            
            _actRepository.Add(activity);
            await _actRepository.SaveAsync();

            return Ok(_mapper.Map<Core.Entities.Activity, ActivityDTO>(activity));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ActivityDTO>> Delete(int id)
        {
            var activity = await _actRepository.GetActivityById(id);
            
            if(activity is null) return NotFound();

            _actRepository.Delete(activity);
            await _actRepository.SaveAsync();
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ActivityDTO>>> GetActivities()
        {
            var activity = await _actRepository.GetActivities();
            return Ok(_mapper.Map<IReadOnlyList<Activity>, IReadOnlyList<ActivityDTO>>(activity));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UserForActivityDTO>>> GetActivity(int id)
        {
            var activity = await _actRepository.GetActivityById(id);
            
            if(activity is null) return NotFound();
            var result = activity.UserActivities.Select(x => x.User).ToList();
            
            return Ok(_mapper.Map<Core.Entities.Activity, UserForActivityDTO>(activity));
        }
    }
}