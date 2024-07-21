using Microsoft.AspNetCore.Mvc;
using Task2.DTOs;
using Task2.IRepository;
using Task2.Models;

namespace Task2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly IUserRepo userRepo;
        public UserController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public IList<DaUser> Get(RequestDto requestDto)
        {
            return userRepo.GetUsers(requestDto.CurrentPage, requestDto.PageSize).ToList();
        }
        

        
    }
}
