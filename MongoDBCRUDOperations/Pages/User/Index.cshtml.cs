using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDBCRUDOperations.Service;

namespace MongoDBCRUDOperations.Pages.User;

public class IndexModel : PageModel
{

    private readonly IUserService _userService;

    public IndexModel(IUserService userService)
    {
        _userService = userService;
    }

    public List<Enitites.User> Users  { get; set; }
    
    public async Task OnGet()
    {
        Users = await _userService.GetUsers();
    }
}