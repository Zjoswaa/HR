using Solution;

Entry<int, string>[] buckets = new Entry<int, string>[5];
// hide the access of buckets and provide add Method in ht to test

buckets[0] = new Entry<int, string>(0, "Zero"); //First add then remove
buckets[1] = new Entry<int, string>(1, "One"); //First add then remove
buckets[2] = new Entry<int, string>(2, "Two");
buckets[4] = new Entry<int, string>(4, "Four");
buckets[3] = new Entry<int, string>(6, "Six"); // because Index(6)-> 1 where one is already occupied, 
//linear probing lead to 3rd location
System.Console.WriteLine($"Index(6): {Math.Abs(6.GetHashCode() % buckets.Length)}");

buckets[0] = null;
buckets[1] = null;

buckets[0] = new Entry<int, string>(8, "Eight"); // because Index(8)-> 3
System.Console.WriteLine($"Index(8): {Math.Abs(8.GetHashCode() % buckets.Length)}");


HashTable<int, string> ht = new HashTable<int, string>(buckets);

Console.WriteLine($"Find: 3 => {ht.Find(3)}");
Console.WriteLine($"Find: 6 => {ht.Find(6)}");
Console.WriteLine($"Find: 8 => {ht.Find(8)}");
Console.WriteLine();
