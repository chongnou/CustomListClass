using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace CustomListClass
{
    public class CustomList<T> : IEnumerable<T>
    {
        //Member Variables
        private int listCount;
        private T[] inputs;
        public int capacity;
        public T this[int index]
        {
            get { return inputs[index]; }
            set { inputs[index] = value; }
        }

        public CustomList()
        {
            listCount = 0;
            capacity = 5;
            inputs = new T[capacity];
        }

        //MEMBER METHODS
        public void Add(T input)
        {
            if (listCount < capacity/2)
            {
                inputs[listCount] = input;  
                listCount++;
            }
            else
            {
                Resize();
                Add(input);
            }
        }

        
    }
}

