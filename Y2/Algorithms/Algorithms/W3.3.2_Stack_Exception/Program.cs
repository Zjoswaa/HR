/*

Stack

Topics covered: Generics, Stack data structure, Arrays, Exceptions, Inheritance, Dynamic Polymorphism.

The Stack is a LIFO (Last In First Out) data structure, SimpleStack statically implements this data structure :
when the stack is full (Capacity reached) no elements will be pushed anymore.
Here the class Stack<T> (which inherits from SimpleStack<T>) allows for pushing more elements by changing the inner array as described below (Push method).
Moreover, Pop and Peek will not just return the default value of type T in case the Stack is empty.

Implement the methods Push, Pop and Peek in the Stack class (make use of those in the SimpleStack class).

    Push:
    If the Stack is full (value of top is equal to Capacity - 1), the method Push creates an array of double the size of the inner array (Capacity is also doubled).
    The old array is copied to the new array (which then becomes the Stack inner array),
    the element to be pushed is written in the first available position of the inner array (after the previous elements), here the value of the top has to be modified.

    Pop and Peek:
    method Pop and Peek generate a StackEmptyException when the methods are called on an empty Stack.

Change the signatures (definition) of methods Push, Pop, and Peek in SimpleStack to allow the dynamic polymorphism behaviour (have a look at the Main).

IMPORTANT: only files Stack.cs and SimpleStack.cs can be modified and will be submitted, so no changes on the other files will affect the result.

*/

using System.Reflection;

public record Product(string name, string brand, double price, double quantity);

class MainProgram
{  
    public static void Main()
    {
        Type myType =(typeof(Stack<int>));
        MethodInfo[] myArrayMethodInfo = myType.GetMethods(BindingFlags.Public|BindingFlags.Instance|BindingFlags.DeclaredOnly);
        System.Console.WriteLine("-----------------------------");
        System.Console.WriteLine("Stack<T> implemented methods:");
        myArrayMethodInfo.ToList().ForEach(System.Console.WriteLine);
        System.Console.WriteLine("-----------------------------\n");
        
        var productsList = new List<Product>(new Product[] {
                                new Product("Name1", "Brand1", 10.5, 2),
                                new Product("Name2", "Brand2", 1.5, 30.6),
                                new Product("Name3", "Brand2", 100.5, 4),
                                new Product("Name4", "Brand2", 150.5, 6.5),
                                new Product("Name5", "Brand1", 8.5, 20),
        });

        var intArray = new int[]{3, 9, 0, 2, -1, 4};
        //Stack -> 'Last In First Out'
        var stack1 = new Stack<Product>();
        
        try{
            Console.WriteLine(stack1.Pop());
        }
        catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        
        foreach(var p in productsList)
            stack1.Push(p);
        Console.WriteLine(stack1.Pop());
        stack1.Push(new Product("Name4", "Brand3", 10.5, 2));
        stack1.Push(new Product("Name5", "Brand1", 30.5, 6.7));
        stack1.Push(new Product("Name6", "Brand1", 41, 2));
        Console.WriteLine(stack1.Pop());
        Console.WriteLine(stack1.Peek());

        SimpleStack<int> stack2 = new Stack<int>();
        stack2.Push(0);
        Console.WriteLine(stack2.Pop());
        try{
            Console.WriteLine(stack2.Pop());
        }
        catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        try{
            Console.WriteLine(stack2.Peek());
        }
        catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        finally {   
            foreach(var i in intArray)
                stack2.Push(i);
            Console.WriteLine(stack2.Pop());
            Console.WriteLine(stack2.Peek());
            Console.WriteLine(stack2.Pop());           
        }
    }
}
