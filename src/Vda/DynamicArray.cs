﻿using System;
using System.Linq;

namespace Vda
/**
    \namespace Vda
*/
{
    /**
        \class DynamicArray<T>
        A class that represents a dynamic array.
        If an item being added exceeds the length of the dynamic array, then the dynamic array will be resized to twice that of its current size.
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
        /**
            Default constructor
        */
        public DynamicArray()
        {
            DataArray = new T[1];
            length = 0;
        }
        /**
            Gets or sets the element at the specified index.
        */
        public ref T this[int i]
        {
            get
            {
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
                Resize(ref DataArray, DataArray.Length*2);
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
            Returns the index of the first occurrence of item
        */
        public int IndexOf(T item)
        {
            return Array.IndexOf(DataArray, item);
        }
        /**
            Removes the first occurrence of a specific object from the DynamicArray<T>.
        */
        public bool Remove(T item)
        {
            int index = IndexOf(item);
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
                throw new IndexOutOfRangeException($"Provided index: {index} is out of array bounds");
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
            dynamic temp = array.GetValue(indexA);
            array.SetValue(array.GetValue(indexB), indexA);
            array.SetValue(temp, indexB);
        }
    }
}
