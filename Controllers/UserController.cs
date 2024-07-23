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

        [HttpPost]
        public  ResponseDto<DaUser> Get(RequestDto requestDto)
        {
            var users = userRepo.GetUsers(requestDto).ToList();

            return new ResponseDto<DaUser>
            {
                Data = users,
                page = requestDto.CurrentPage,
                TotalNumberOfPages = (users.Count() / requestDto.PageSize) + 1

            };
        }

        
    }
}
