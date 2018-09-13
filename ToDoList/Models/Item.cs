using System;
using System.Collections.Generic;

namespace ToDoList.Models {
  public class Item {
    private string _description;
<<<<<<< HEAD
    private static List<Item> _instances = new List<Item> { };
    public Item (string description) {
=======
    private int _id;
    private static List<Item> _instances = new List<Item> {};

    public Item (string description)
    {
>>>>>>> abfb6e1f73373b5bae3b086e77c06b83c428341a
      _description = description;
      _instances.Add(this);
      _id = _instances.Count;
    }
    public string GetDescription () {
      return _description;
    }
    public void SetDescription (string newDescription) {
      _description = newDescription;
    }
<<<<<<< HEAD
    public static List<Item> GetAll () {
      return _instances;
    }
    public void Save () {
      _instances.Add (this);
    }
    public static void ClearAll () {
      _instances.Clear ();
=======
    public int GetId()
    {
      return _id;
    }
    public static List<Item> GetAll()
    {
      return _instances;
    }
    public void Save()
    {
      _instances.Add(this);
>>>>>>> abfb6e1f73373b5bae3b086e77c06b83c428341a
    }
    public static Item Find (int searchId) {
      return _instances[searchId - 1];
    }
    public static Item Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}