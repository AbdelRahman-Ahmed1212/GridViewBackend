using Microsoft.AspNetCore.Mvc;
using Task2.DTOs;
using Task2.IRepository;
using Task2.Models;
using Task2.Services;
using Task2.ViewModels;

namespace Task2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController: ControllerBase
    {
        private readonly UserService userService;
        private readonly IUserRepo userRepo;
        public UserController(UserService userService, IUserRepo userRepo)
        {
            this.userService = userService;
            this.userRepo = userRepo;
        }

        [HttpPost]
        public  ResponseDto<UserViewModel> Get(RequestDto requestDto)
        {
            var query = requestDto.filters.GenerateFilterQuery();
            return new ResponseDto<UserViewModel>()
            {
                Data = userService.GetUsersViewModel(requestDto).ToList(),
                page = requestDto.CurrentPage,
                TotalNumberOfPages = (this.userRepo.Count(query) / requestDto.PageSize) + 1

            };
        }

        
    }
}
