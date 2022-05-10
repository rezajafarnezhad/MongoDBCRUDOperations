using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDBCRUDOperations.Service;

namespace MongoDBCRUDOperations.Pages.User;

public class EditModel : PageModel
{

    private readonly IUserService _userService;

    public EditModel(IUserService userService)
    {
        _userService = userService;
    }

    [BindProperty]
    public Enitites.User User  { get; set; }
    public async Task OnGet(Guid Id)
    {
        User = await _userService.GetBy(Id);
    }

    public async Task<IActionResult> OnPost()
    {
        await _userService.Update(User);
        return RedirectToPage("./Index");
    }
}