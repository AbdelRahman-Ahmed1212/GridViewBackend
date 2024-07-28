using Task2.DTOs;
using Task2.IRepository;
using Task2.ViewModels;

namespace Task2.Services
{
    public class UserService
    {
        private readonly IUserRepo repo;
        public UserService(IUserRepo userRepo)
        {
            this.repo = userRepo;
        }
        public IEnumerable<UserViewModel> GetUsersViewModel(RequestDto requestDto)
        {
            var filterQuery = requestDto.searchObj.GenerateFilterQuery();

            return repo.GetUsers(requestDto, filterQuery).Select(item=> new UserViewModel()
            {
                DOB = item.DOB,
                Email = item.Email,
                FirstName = item.FirstName,
                id = item.id,
                LastName = item.LastName,
                Phone = item.Phone
                
            });
        }
    } 


}
