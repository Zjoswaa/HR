using System.Collections.ObjectModel;

namespace Solution;

public class HashTable<K, V> : IHashTable<K, V> {
    Entry<K, V>[]? entries { get; set; }

    public ReadOnlyCollection<Entry<K, V>> data => entries == null ? null : entries.AsReadOnly();

    public HashTable() {
        entries = null;
    }

    public HashTable(Entry<K, V>[]? input) {
        importData(input);
    }

    public HashTable(int capacity) {
        entries = new Entry<K, V>[capacity];
    }

    protected int GetIndex(K key) {
        if (entries is null) {
            return -1;
        }
        return Math.Abs(key.GetHashCode()) % entries.Length;
    }

    public bool Add(K key, V value) {
        if (entries is null || entries.Length == 0) {
            return false;
        }

        int index = GetIndex(key);
        int originalIndex = index;
        
        // Linear probing
        while (entries[index] is not null) {
            if (entries[index].Key.Equals(key)) {
                return false;
            }
            index = (index + 1) % entries.Length;

            // If we've looped back to the original index, the table is full
            if (index == originalIndex) {
                return false;
            }
        }

        entries[index] = new Entry<K, V>(key, value);
        return true;
    }

    public V? Find(K key) {
        if (entries is null || entries.Length == 0) {
            return default(V);
        }
        
        int index = GetIndex(key);
        while (entries[index] is not null) {
            if (entries[index].Key.Equals(key)) {
                return entries[index].Value;
            }
            index = (index + 1) % entries.Length;
        }
        return default(V);
    }

    public bool Delete(K key) {
        if (entries is null || entries.Length == 0) {
            return false;
        }

        int index = GetIndex(key);
        while (entries[index] is not null) {
            if (entries[index].Key.Equals(key)) {
                entries[index] = null;
                return true;
            }
            index = (index + 1) % entries.Length;
        }
        return false;
    }

    //DO NOT REMOVE the following method:
    private void importData(Entry<K, V>[]? inputData) {
        if (inputData != null) {
            entries = new Entry<K, V>[inputData.Length];
            for (int i = 0; i < inputData.Length; ++i)
                entries[i] = inputData[i];
        }
    }
}
