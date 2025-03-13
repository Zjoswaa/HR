
using Solution;

var people = new Person[] {
                        new Person(25, "John", "Doe"),
                        new Person(23, "Jane", "Doe"),
                        new Person(65, "Kurt", "Russell"),
                        new Person(57, "Dolph", "Lundgren"),
                        new Person(28, "Tim", "Smith"),
                        new Person(35, "Jack", "Doe"),
                        new Person(23, "Jane", "Doe"),
                        new Person(63, "Ralph", "Lundgren"),
                        new Person(25, "Jane", "Smith"),
                        new Person(23, "Laura", "Doe"),
                        new Person(43, "Laura", "Lundgren"),
};

int minVal = 1000;
int maxVal = 9000;
var rand = new Random();
var keys = new string[people.Length];
for(int i = 0; i < keys.Length; ++i) {
   keys[i] = "08" + rand.Next(minVal, maxVal);
}
//----ADD---
var data = new Entry<string, Person>[people.Length];
var tmpTable = new HashTable<string, Person>(people.Length);

for(int i = 0; i < keys.Length/2; ++i) {
    tmpTable.Add(keys[i], people[i]);
}

data = tmpTable.data.ToArray();
var table1 = new HashTable<string, Person>(data);

for(int i = 0; i < keys.Length * 0.8; ++i) {
    table1.Add(keys[i], people[i]);
}

//---ADD---

var table = new HashTable<string, Person>(people.Length);

int keyIdx = 0;
foreach(var p in people) {
    table.Add(keys[keyIdx++], p);
    if(keyIdx == keys.Length)
      System.Console.WriteLine($"Key: {keys[keyIdx - 1]} deleted? {(table.Delete(keys[keyIdx - 1]) ? "YES" : "NO")}");
}

var testAdd1 = table.Add(keys[keys.Length - 1], new Person(43, "Laura", "Lundgren"));
var testAdd2 = table.Add("08" + rand.Next(maxVal, maxVal + 900), new Person(43, "Laura", "Lundgren"));

var indices = Enumerable.Range(0, keys.Length).OrderBy(x => rand.Next()).ToArray();
var flag = true;
for(int i = 0; i < keys.Length / 2; ++i) {
    var r1 = table.Find(keys[indices[rand.Next(0, keys.Length)]]);
    var key = keys[indices[rand.Next(0, keys.Length)]];
    if( flag && table.Find(key) != null) {
        table.Delete(key);
        flag = false;
    }

}
var delKey = keys[indices[rand.Next(0, keys.Length)]];
var testDelete = table.Delete(delKey);
var r2 = table.Find(delKey);
testDelete = table.Delete(delKey);

System.Console.WriteLine();
