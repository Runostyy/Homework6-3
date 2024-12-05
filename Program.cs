using System;
using System.Collections;
using System.Collections.Generic;

class Tree
{
    public string Name { get; set; } // Назва дерева
    public double Price { get; set; } // Ціна дерева
    public double Height { get; set; } // Висота дерева

    public Tree(string name, double price, double height)
    {
        Name = name;
        Price = price;
        Height = height;
    }

    public override string ToString()
    {
        return $"{Name}: Ціна = {Price:C}, Висота = {Height} м";
    }
}

// Клас для колекції дерев із реалізацією IEnumerable
class TreeCollection : IEnumerable<Tree>
{
    private List<Tree> trees = new List<Tree>();

    // Додавання дерева до колекції
    public void Add(Tree tree)
    {
        trees.Add(tree);
    }

    // Реалізація інтерфейсу IEnumerable<Tree>
    public IEnumerator<Tree> GetEnumerator()
    {
        return trees.GetEnumerator();
    }

    // Реалізація інтерфейсу IEnumerable
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Створення колекції дерев
        TreeCollection treeCollection = new TreeCollection();
        treeCollection.Add(new Tree("Дуб", 1500.00, 10.5));
        treeCollection.Add(new Tree("Сосна", 1000.00, 15.0));
        treeCollection.Add(new Tree("Береза", 1200.00, 12.0));
        treeCollection.Add(new Tree("Ялина", 1800.00, 8.5));

        Console.WriteLine("Список дерев:");
        foreach (var tree in treeCollection)
        {
            Console.WriteLine(tree);
        }

        // Сортування дерев за ціною
        Console.WriteLine("\nСписок дерев, впорядкований за ціною:");
        List<Tree> sortedByPrice = new List<Tree>(treeCollection);
        sortedByPrice.Sort((x, y) => x.Price.CompareTo(y.Price)); // Сортування за ціною
        foreach (var tree in sortedByPrice)
        {
            Console.WriteLine(tree);
        }
    }
}
