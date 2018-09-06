using System.Collections.Generic;
using System;
namespace ToDoList.Models
{
  public class Item
  {
    private string _description;
    private static List<Item> _instances = new List<Item> {};
    public Item (string description)
    {
      _description = description;
    }
    public string GetDescription()
    {
      return _description;
    }
    public void SetDescription(string newDescription)
    {
      _description = newDescription;
    }
    public static List<Item> GetAll()
    {
      // return new List<Item> {};
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this); 
    }
    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
  public class Program
  {
    public static void Main()
    {
      Console.WriteLine("Welcome. Would you like to add to or view a list? (add/view/end)");
      string AddView = Console.ReadLine();
      if (AddView == "add")
      {
        Console.WriteLine("Please enter your item.");
        string listInput = Console.ReadLine();
        Item newItem = new Item(listInput);
        newItem.Save();
        Main();
      }
      else if (AddView == "view") 
      {
        List<Item> input = Item.GetAll();

        foreach(Item itemToDo in input)
        {
          Console.WriteLine(itemToDo.GetDescription());
        }
        Main();
      }
      else if (AddView == "end")
      {
        Console.WriteLine("Goodbye.");
      }
      else
      {
        Console.WriteLine("Please enter 'add,' 'view,' or 'end.'");
        Main();
        // Console.ReadLine();
      }
    }
  }
}

