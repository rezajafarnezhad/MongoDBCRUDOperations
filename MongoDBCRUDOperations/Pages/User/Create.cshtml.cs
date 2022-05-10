using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDBCRUDOperations.Service;

namespace MongoDBCRUDOperations.Pages.User;

public class CreateModel : PageModel
{

    private readonly IUserService _userService;

    public CreateModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    public Enitites.User User  { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        await _userService.Insert(User);
        return RedirectToPage("./Index");
    }
}