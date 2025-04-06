
namespace Exam;

public class Helper
{
  public const string undefined = "<NO_VALUE>";
  public static void Display<T>(IEnumerable<T> Array) 
          => Console.WriteLine(string.Join(", ", Array));  

  public static Action<T> printElement<T>(int n) => 
              (T s) => {
                        if(s == null || IsNumberOrChar(s) && s.Equals(default(T)))
                          printNoElement<T>(n)();
                        else
                          Console.Write(String.Concat(Enumerable.Repeat(" ", n - s.ToString().Length)) + s.ToString() + "," );
                       };                    
  
  public static Action printNoElement<T>(int n) => 
              () => Console.Write(String.Concat(Enumerable.Repeat(" ", n - undefined.Length)) + undefined + "," );

  public static void Display<T>(IEnumerable<T> Array, int maxLengthElement)
  {
    if(Array != null) 
      Array.ToList().ForEach(printElement<T>(maxLengthElement));
    Console.WriteLine();
  }
  
  public static void Display<T>(T[][] JaggedArr)
  {   
    var maxLengthElement = JaggedArr.Select(_ => _ == null ? undefined.Length : 
                                                 _.Length == 0 ? undefined.Length :
                                                 _.Select(__ => __.ToString().Length).Max()).Max();
    
    var maxColumns = JaggedArr.Select(_ => _ == null ? 0 : _.Length ).Max();

    var EmptyArray = Enumerable.Repeat(default(T), maxColumns).ToArray();
    
    for (int i = 0; i < JaggedArr.Length; i++) {
      if (JaggedArr[i] != null && JaggedArr[i].Length != 0) {
        var paddedList = JaggedArr[i].ToList();
        paddedList.AddRange(Enumerable.Repeat(default(T), maxColumns - JaggedArr[i].Length));
        Display(paddedList.ToArray(), maxLengthElement + 2);
      }
      else
        Display(EmptyArray, maxLengthElement + 2); 
    }
  }

  public static bool IsNumberOrChar(object value)
  {
    return
      value is char || 
      value is sbyte || 
      value is byte || 
      value is short || 
      value is ushort ||
      value is int ||
      value is uint ||
      value is long ||
      value is ulong ||
      value is Int128 ||
      value is UInt128 ||
      value is nint ||
      value is nuint ||
      value is Half ||
      value is float ||
      value is double ||
      value is decimal;
  }

}
