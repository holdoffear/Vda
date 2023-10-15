namespace Vda
{
    public class DynamicArray<T>
    {
        private T[] DataArray;
        private int length;
        public int Length{get{return length;}}
        public DynamicArray()
        {
            DataArray = new T[0];
            length = 0;
        }
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
        public void Add(T item)
        {
            if(DataArray.Length-1 < length)
            {
                Resize(ref DataArray, DataArray.Length+1);
            }
            DataArray[length] = item;
            length++;
        }
        public bool Contains(T item)
        {
            return CreateSpan(DataArray, 0, length).ToArray().Contains(item);
        }
        static public Span<T> CreateSpan(T[] array, int start, int length)
        {
            if(length > -1)
            {
                return new Span<T>(array, start, length);
            }
            return new Span<T>(new T[]{});
        }
        public void Remove(T item)
        {
            int removeIndex = Array.IndexOf(DataArray, item);
            RemoveAt(removeIndex);
        }
        static public void Resize<T2>(ref T2[] array, int newSize)
        {
            Array.Resize(ref array, newSize);
        }
        public void RemoveAt(int removeIndex)
        {
            if (removeIndex < 0 || removeIndex >= length)
            {
                throw new NotImplementedException();
            }
            SwapIndices(DataArray, removeIndex, length-1);
            length--;
        }
        public static void SwapIndices(Array array, int indexA, int indexB)
        {
            dynamic? temp = array.GetValue(indexA);
            array.SetValue(array.GetValue(indexB), indexA);
            array.SetValue(temp, indexB);
        }
    }
}
