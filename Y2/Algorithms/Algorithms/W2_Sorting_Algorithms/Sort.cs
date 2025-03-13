namespace ToDo;

public class Sort<T> : ISort<T> where T : IComparable<T> {
    public static void InsertionSort(T[] data) {
        for (int i = 1; i < data.Length; i++) {
            T key = data[i];
            int j = i - 1;
            while (j >= 0 && data[j].CompareTo(key) == 1) {
                data[j + 1] = data[j];
                j--;
            }
            data[j + 1] = key;
        }
    }
    
    public static void BubbleSort(T[] data) {
        bool swapped;
        do {
            swapped = false;
            for (int i = 0; i < data.Length - 1; i++) {
                if (data[i].CompareTo(data[i + 1]) == 1) {
                    // Swap
                    (data[i + 1], data[i]) = (data[i], data[i + 1]);
                    swapped = true;
                }
            }
        } while (swapped);
    }
    
    public static void MergeSort(T[] array, int low, int high) {
        if (low < high) {
            int middle = (low + high) / 2;
            MergeSort(array, low, middle);
            MergeSort(array, middle + 1, high);
            Merge(array, low, middle, high);
        }
    }

    public static void Merge(T[] array, int low, int middle, int high) {
        int leftSize = middle - low + 1;
        int rightSize = high - middle;

        T[] leftArray = new T[leftSize];
        T[] rightArray = new T[rightSize];
        for (int i = 0; i < leftSize; i++) {
            leftArray[i] = array[low + i];
        }
        for (int j = 0; j < rightSize; j++) {
            rightArray[j] = array[middle + 1 + j];
        }
        
        int leftIndex = 0, rightIndex = 0, insertIndex = low;
        while (leftIndex < leftSize && rightIndex < rightSize) {
            if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) <= 0) {
                array[insertIndex] = leftArray[leftIndex];
                leftIndex++;
            }
            else {
                array[insertIndex] = rightArray[rightIndex];
                rightIndex++;
            }
            insertIndex++;
        }

        while (leftIndex < leftSize) {
            array[insertIndex] = leftArray[leftIndex];
            leftIndex++;
            insertIndex++;
        }

        while (rightIndex < rightSize) {
            array[insertIndex] = rightArray[rightIndex];
            rightIndex++;
            insertIndex++;
        }
    }
}
