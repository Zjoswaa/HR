using System.Diagnostics;
using System.Reflection;

public class Utils {

    private static int _counter = 0;

    public static int counter {
        get { return _counter; }
    }

    public static int IncrementDoneCounter() {
        return Interlocked.Increment(ref _counter);
    }

    public static int DecrementDoneCounter() {
        return Interlocked.Decrement(ref _counter);
    }

    public static void SetToZero() {
        Interlocked.Exchange(ref _counter, 0);
    }

    public static void ShowCallStack(bool printFlag = true) {
        IncrementDoneCounter();

        StackTrace trace = new StackTrace();
        StackFrame[]? frames = trace.GetFrames();

        if (frames is not null && frames.Length > 1) {
            MethodBase? info = frames[1].GetMethod();
            if (info?.ReflectedType?.FullName is not null && printFlag) {
                Console.WriteLine("{0}.{1} call: {2}", info.ReflectedType.FullName, info.Name, counter);
            }
        }
        else if (printFlag) {
            Console.WriteLine("Unable to retrieve call stack.");
        }
    }

}
