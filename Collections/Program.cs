using System;
using System.Collections.Generic;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
           // All of these methods mutate the original collection
            
            // List<T> is a generic type, a type that requires me to tell it what type of stuff it does or uses
            // in this case, string is a type parameter used to tell the List<T> how to work
            var e14Names = new List<string>();

            // add a single item
            // works like push, appends to the end of the list
            e14Names.Add("Martin");
            e14Names.Add("Chie");
            e14Names.Add("Holly");

            // puts the item into a certain spot
            // Chris now goes right after Martin
            e14Names.Insert(1, "Chris");

            // collection initializer = curly braces with elements inside
            var teacherNames = new List<string> { "Nathan", "Jameka", "Dylan", "Tom" };

            // add one collection to the other
            e14Names.AddRange(teacherNames);

            // removes tom (this uses a thing called reference equality)
            e14Names.Remove("Tom");

            // removes at the index, removes Martin
            e14Names.RemoveAt(0);

            // remove by expression
            e14Names.RemoveAll(name => name.StartsWith("N"));

            // normal c# foreach loop
            foreach (var name in e14Names)
            {
                Console.WriteLine($"{name} is in e14!");
            }

            // list specific loop, takes in an Action<T> (like a fat arrow function)
            e14Names.ForEach(name => Console.WriteLine($"{name} is in e14!"));

            // get the item at the index of 0
            var firstStudent = e14Names[0];

            // Dictionary<TKey, TValue> -- Open Generic (no one has specified what type of thing it is yet)
            // Arity (`2) -> how many generic type parameters a type has. Dictionary`2
            // like a physical dictionary, kinda
            // keys have to be unique
            // our dictionary is keyed by strings and has string values
            // good for: infrequently updated but often read data
            // good for: loading information at startup or in the background and fast retrieval on demand (caching)
            var dictionary = new Dictionary<string, string>(); // closed generic (we have told it how to behave)

            // adding things requires a key and a value
            dictionary.Add("Penultimate", "second to last");
            dictionary.Add("Jib", "The things that stick out of rollercoasters");
            dictionary.Add("Arbitrary", "Someone who doesn't like Arby's");

           // get one thing back based on its key
            var definition = dictionary["Arbitrary"]; // case sensitive

            // this won't work : dictionaries require each key to be unique
            //dictionary.Add("Penultimate", "Thing said too many times at the olympics");

            // try methods return a boolean indicating success or failure
            // kind of expensive just to find out of the key exists
            if (!dictionary.TryAdd("Penultimate", "Thing said too many times at the olympics"));
            {
                Console.WriteLine("It's already in the dictionary, I couldn't add it.");
            }

            if (dictionary.ContainsKey("Penultimate"))
            {
                dictionary["Penultimate"] = "Thing said too many times at the olympics";
            }

            // give me all the keys in a collection, can do with values too
            var allTheWords = dictionary.Keys;

            //foreach (var item in dictionary)
            //{
            //    Console.WriteLine($"{item.Key}'s definition is {item.Value}");
            //}

            // c# destructuring
            foreach (var (word, def) in dictionary)
            {
                Console.WriteLine($"{word}'s definition is {def}");
            }

            var complicatedDictionary = new Dictionary<string, List<string>>();

            complicatedDictionary.Add("Soup", new List<string>());
            var soupDefinitions = complicatedDictionary["Soup"];
            soupDefinitions.Add("This is a definition of soup");

            complicatedDictionary.Add("Arity", new List<string> { "A definition of arity" });

            foreach (var (word, definitions) in complicatedDictionary)
            {
                Console.WriteLine(word);
                foreach (var def in definitions)
                {
                    Console.WriteLine($"\t{def}");
                }
            }

            // Hashset<T>
            // like a list in that they store a value at an index
            // like a dictionary in that the value has to be unique
            // completely different in that it elimates non-unique stuff without errors
            // pretty slow at adding data
            // super fast at getting data out, comparing data
            // they enforce uniqueness
            // uses Hashcodes to figure out uniqueness
            
            var uniqueNames = new HashSet<string>();
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Jameka");
            uniqueNames.Add("Dylan");
            uniqueNames.Add("Dylan");

            uniqueNames.Remove("Dylan");

            foreach (var name in uniqueNames)
            {
                Console.WriteLine($"{name} is unique");
            }

            // Queue><T>
            // FIFO (first in, first out) based collection
            // things that have to be done in order
            // enqueue goes straight to the back
            var queue = new Queue<int>();
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(98);

            while(queue.Count > 0)
            {
                Console.WriteLine($"dequeuing {queue.Dequeue()}");
            }

            // Stack<T>
            // LIFO (last in, first out) based collection
            // things done in order, but with a bias towards recency
            var stack = new Stack<int>();
            stack.Push(2);
            stack.Push(5);
            stack.Push(76);
            stack.Push(55);

            while (stack.Count > 0)
            {
                Console.WriteLine($"popping {stack.Pop()}");
            }
        }
    }
}
