using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers {
  public class ItemsController : Controller {

    [HttpGet ("/items")]
    public ActionResult Index () {
      List<Item> allItems = new List<Item> { };
      return View (allItems);
    }

    [HttpGet ("/items/new")]
    public ActionResult CreateForm () {
      return View ();
    }

    [HttpGet ("/categories/{categoryId}/items/new")]
    public ActionResult CreateForm (int categoryId) {
      Dictionary<string, object> model = new Dictionary<string, object> ();
      Category category = Category.Find (categoryId);
      return View (category);
    }

    [HttpGet ("/categories/{categoryId}/items/{itemId}")]
    public ActionResult Details (int categoryId, int itemId) {
      Item item = Item.Find (itemId);
      Dictionary<string, object> model = new Dictionary<string, object> ();
      Category category = Category.Find (categoryId);
      model.Add ("item", item);
      model.Add ("category", category);
      return View (item);
    }
  }
}
