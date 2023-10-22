namespace Vda
/**
    \namespace Vda
*/
{
    /**
        \class DynamicArray<T>
        A class that represents a dynamic array
    */
    public class DynamicArray<T>
    {
        /**
            Array of type T
        */
        private T[] DataArray;
        /**
            The number of elements in the DataArray
        */
        private int length;
        /**
            Public accessor for length variable.
        */
        public int Length{get{return length;}}
        public DynamicArray()
        {
            DataArray = new T[0];
            length = 0;
        }
        /**
            The public accessor for DataArray. Returns a reference to DataArray
        */
        public ref T this[int i]
        {
            get
            {
                if (i < 0 || i >= length)
                {
                    throw new NotImplementedException();
                }
                return ref DataArray[i];
            }
        }
        /**
            Adds an item of type T to DataArray
        */
        public void Add(T item)
        {
            if(DataArray.Length-1 < length)
            {
                Resize(ref DataArray, DataArray.Length+1);
            }
            DataArray[length] = item;
            length++;
        }
        /**
            Determines whether the item of type T exists within DataArray
        */
        public bool Contains(T item)
        {
            return CreateSpan(DataArray, 0, length).ToArray().Contains(item);
        }
        /**
            Creates a Span of type T from provided array from start index to provided length
        */
        static public Span<T> CreateSpan(T[] array, int start, int length)
        {
            if(length > -1)
            {
                return new Span<T>(array, start, length);
            }
            return new Span<T>(new T[]{});
        }
        /**
            Removes item of type T from DataArray
        */
        public void Remove(T item)
        {
            int index = Array.IndexOf(DataArray, item);
            RemoveAt(index);
        }
        /**
            Removes item of type T from index
            
            *Note*: Throws exception if index is < 0 or > length
            
            ~length refers to the field length of the class~
        */
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new NotImplementedException();
            }
            SwapIndices(DataArray, index, length-1);
            length--;
        }
        /**
            Resizes a given array of type T2 to provided newSize
        */
        static public void Resize<T2>(ref T2[] array, int newSize)
        {
            Array.Resize(ref array, newSize);
        }
        /**
            Swaps position of element at indexA with position of element at indexB
            within the provided array
        */
        public static void SwapIndices(Array array, int indexA, int indexB)
        {
            dynamic? temp = array.GetValue(indexA);
            array.SetValue(array.GetValue(indexB), indexA);
            array.SetValue(temp, indexB);
        }
    }
}
