using System;
using System.Collections.Generic;

namespace lab4
{
    public abstract class MenuComponent
    {
        public string Name { get; protected set; }
        public string Url { get; protected set; }

        public abstract void Display(int depth);
        public virtual void Add(MenuComponent component)
        {
            throw new NotSupportedException();
        }
        public virtual void Remove(MenuComponent component)
        {
            throw new NotSupportedException();
        }
        public virtual MenuComponent GetChild(int index)
        {
            throw new NotSupportedException();
        }
    }

    public class MenuItem : MenuComponent
    {
        public MenuItem(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public override void Display(int depth)
        {
            string indent = new string('-', depth * 2);
            Console.WriteLine($"{indent} {Name} ({Url})");
        }
    }

    public class Menu : MenuComponent
    {
        private List<MenuComponent> _menuComponents = new List<MenuComponent>();

        public Menu(string name)
        {
            Name = name;
        }

        public override void Add(MenuComponent component)
        {
            _menuComponents.Add(component);
        }

        public override void Remove(MenuComponent component)
        {
            _menuComponents.Remove(component);
        }

        public override MenuComponent GetChild(int index)
        {
            return _menuComponents[index];
        }

        public override void Display(int depth)
        {
            string indent = new string('-', depth * 2);
            Console.WriteLine($"{indent} {Name}");

            foreach (var component in _menuComponents)
            {
                component.Display(depth + 1);
            }
        }
    }

    internal class Program2
    {
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu("Main Menu");

            Menu userMenu = new Menu("User Management");
            userMenu.Add(new MenuItem("Profile", "/profile"));
            userMenu.Add(new MenuItem("Settings", "/settings"));

            Menu productMenu = new Menu("Product Catalog");
            productMenu.Add(new MenuItem("Electronics", "/products/electronics"));
            productMenu.Add(new MenuItem("Clothing", "/products/clothing"));

            mainMenu.Add(userMenu);
            mainMenu.Add(productMenu);

            mainMenu.Add(new MenuItem("Home", "/"));
            mainMenu.Add(new MenuItem("Contact", "/contact"));

            Console.WriteLine("Web Application Menu Structure:");
            mainMenu.Display(0);

            Console.ReadLine();
        }
    }
}