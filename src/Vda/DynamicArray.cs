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
            Gets the number elements in the DynamicArray<T>
        */
        public int Length{get{return length;}}
        public DynamicArray()
        {
            DataArray = new T[0];
            length = 0;
        }
        /**
            Gets or sets the element at the specified index.
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
            The object to be added to the end of the DynamicArray<T>
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
            Determines whether an element is in the DynamicArray<T>.
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
            Removes the first occurrence of a specific object from the DynamicArray<T>.
        */
        public bool Remove(T item)
        {
            int index = Array.IndexOf(DataArray, item);
            if(index < 0)
            {
                return false;
            }
            RemoveAt(index);
            return true;
        }
        /**
            Removes the element at the specified index of the DynamicArray<T>.
        */
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException();
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
