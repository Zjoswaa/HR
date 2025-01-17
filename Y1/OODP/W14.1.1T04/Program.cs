public class Program
{

    static void Main(string[] args)
    {

        switch (args[1])
        {
            case "PEEK":
                PeekTest();
                break;
            case "SOLVE":
                SolveTest();
                break;
            case "SHOWALL":
                PrintAllRequestsTest();
                break;
            default:
                Console.WriteLine("Command not found");
                break;
        }
    }


    static void PeekTest()
    {
        Department department = new Department("IT");
        department.AddRequest(new Request("Mice", "I need a new mice", "Amirah"));
        department.AddRequest(new Request("Monitor", "Help! My monitor broke", "Emre"));
        Console.WriteLine("Get next request:");
        Console.WriteLine(department.GetNextRequest());
        //expected output:
        // Get next request:
        // Name: Mice
        // Description: I need a new mice
        // Customer Name: Amirah
    }

    //Test peek and solve next request
    static void SolveTest()
    {

        Department department = new Department("IT");
        department.AddRequest(new Request("Admin rights", "I want admin rights on my work laptop!", "Kavya"));
        department.AddRequest(new Request("Toilet", "I dropped my iPhone in the toilet", "Tariq"));
        Console.WriteLine("Solve next request:");
        Console.WriteLine(department.SolveNextRequest());
        Console.WriteLine("Get next request:");
        Console.WriteLine(department.GetNextRequest());


        // Solve next request:
        // Name: Mice
        // Description: I need a new mice
        // Customer Name: Amirah
        // Get next request:
        // Name: Monitor
        // Description: Help! My monitor broke
        // Customer Name: Emre
    }




    //Test print all requests
    static void PrintAllRequestsTest()
    {
        Department department = new Department("IT");
        department.AddRequest(new Request("Mice", "I need a new mice", "Amirah"));
        department.AddRequest(new Request("Monitor", "Help! My monitor broke", "Emre"));
        Console.WriteLine("Print all requests:");
        department.PrintAllRequests();
        // Expected output
        // Print all requests:
        // Name: Mice
        // Description: I need a new mice
        // Customer Name: Amirah
        // 
        // Name: Monitor
        // Description: Help! My monitor broke
        // Customer Name: Emre
    }
}
