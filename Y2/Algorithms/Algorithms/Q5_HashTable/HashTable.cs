using System.Collections.ObjectModel;

namespace Solution;

public class HashTable<K, V> {
    Entry<K, V>[]? buckets { get; set; }

    public ReadOnlyCollection<Entry<K, V>> data => buckets == null ? null : buckets.AsReadOnly();

    public HashTable() {
        buckets = null;
    }

    public HashTable(Entry<K, V>[]? input) {
        importData(input);
    }

    public HashTable(int capacity) {
        buckets = new Entry<K, V>[capacity];
    }

    protected int getIndex(K key) {
        int hashCode = Math.Abs(key.GetHashCode()) % buckets.Length;
        int potentialIndex = hashCode;
        do {
            if (buckets[potentialIndex] is not null && key.Equals(buckets[potentialIndex].Key)) {
                return potentialIndex;
            }
            potentialIndex = (potentialIndex + 1) % buckets.Length;
        } while (potentialIndex != hashCode);
        return -1;
    }

    public V? Find(K key) {
        int potentialIndex = getIndex(key);
        if (potentialIndex == -1) {
            return default;
        }
        return buckets[potentialIndex].Value;
    }

    //DO NOT REMOVE the following method:
    private void importData(Entry<K, V>[]? inputData) {
        if (inputData != null) {
            buckets = new Entry<K, V>[inputData.Length];
            for (int i = 0; i < inputData.Length; ++i)
                buckets[i] = inputData[i];
        }
    }
}
