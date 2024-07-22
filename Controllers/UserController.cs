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

            return new ResponseDto<DaUser>
            {
                Data = userRepo.GetUsers(requestDto).ToList(),
                page = requestDto.CurrentPage,
                TotalNumberOfPages = (userRepo.Count() / requestDto.PageSize) + 1

            };
        }

        
    }
}
