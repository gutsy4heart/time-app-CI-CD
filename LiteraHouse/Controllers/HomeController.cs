using LiteraHouse.Repository.AddPost;
using Microsoft.AspNetCore.Mvc;
using LiteraHouse.Models;
using System.Diagnostics;
namespace LiteraHouse.Controllers;
public class HomeController : Controller
{

    private readonly IBooksRepository _repos;

    public HomeController(IBooksRepository repos) => _repos = repos;

    #region Get

    public IActionResult Index()
    {
        var books = _repos.GetBooks() ?? new List<Book>();
        return View(books);
    }

    public IActionResult Details(int id)
    {
        var bookToShow = _repos.GetBookById(id);
        if(bookToShow is null)
        {
            return NotFound();
        }
        return View(bookToShow);
    }


    #endregion


    #region Add
    [HttpGet]
    public IActionResult AddBook()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddBook(Book book)
    {
        try
        {
            _repos.AddBook(book);
            TempData["Added"] = "Book added successfuly!";
        }
        catch (Exception)
        {

            TempData["Error"] = "Book wasn't added!";
        }
        return RedirectToAction(nameof(Index));
    }

    #endregion


    #region Delete

    [HttpGet]
    public IActionResult DeleteBook(int? id)
    {
        var bookToDelete = _repos.GetBookById(id.Value);
        return View(bookToDelete);
    }

    [HttpPost]
    public IActionResult DeleteBook(int id)
    {
        _repos.DeleteBook(id);
        TempData["Deleted"] = "Book has been deleted!";
        return RedirectToAction(nameof(Index));
    }


    #endregion


    #region Edit
    [HttpGet]
    public IActionResult EditBook(int id)
    {
        var bookEdit = _repos.GetBookById(id);
        return View(bookEdit);
    }

    [HttpPost]
    public IActionResult EditBook(Book book)
    {
        _repos.UpdateBook(book);
        TempData["Updated"] = "Post udpated successfully";
        return RedirectToAction(nameof(Index));
    }

    #endregion


    #region Error
    public IActionResult Error()
    {
        var obj = new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier };
        return View(obj);
    }
    #endregion

}

