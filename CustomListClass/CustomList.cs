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

        public void Remove(T input)
        {
            for (int i = 0; i < listCount; i++)
            {
                T checkInput = inputs[i];
                if(checkInput.Equals(input) == true)
                {
                    for(int x = i; x < listCount; x++)
                    {
                        inputs[x] = inputs[x + 1];  
                    }
                    listCount--;
                }
            }
        }

        public override string ToString()
        {
            string listString = "";
            for (int i = 0; i < listCount; i++)
            {
                if(i == listCount-1)
                {
                    T value = inputs[i];
                    listString += value + " ";  
                }
                else
                {
                    T value = inputs[i];
                    listString += value + ", ";  
                }
            }
            return listString;
        }

        public int ListCount()
        { 
            return listCount;
        }

        public CustomList<T> ZipNewArray(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> newInputs = new CustomList<T>();
            int newListCount1 = listOne.listCount; 
            int newListCount2 = listTwo.listCount;
            int newListCount = newListCount1 + newListCount2;
                                      

            for (int x = 0; x < newListCount; x++)
            {
                if(newListCount1 > 0 && newListCount2 > 0)
                {
                    newInputs.Add(listOne[x]);
                    newListCount1--;
                    newInputs.Add(listTwo[x]);
                    newListCount2--; 
                }
                else if (newListCount1 > 0 && newListCount2 <= 0)
                {
                    newInputs.Add(listOne[x]);
                    newListCount1--;
                }
                else if (newListCount2 > 0 && newListCount1 <= 0)
                {
                    newInputs.Add(listTwo[x]);
                    newListCount2--;
                }
                else
                {
                    return newInputs;
                }
               
            }
            return newInputs;
        }

        public static CustomList<T> operator +(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> newInputs = new CustomList<T>();
            int newListCount1 = listOne.ListCount()+2; 
            int newListCount2 = listTwo.ListCount()+2;

            for (int x = 0; x < newListCount1; x++)
            {
                newInputs.Add(listOne[x]);
                newListCount1--;
            }
            for (int x = 0; x < newListCount2; x++)
            {
                newInputs.Add(listTwo[x]);
                newListCount2--;
            }
            return newInputs;
        }

        public static CustomList<T> operator -(CustomList<T> listOne, CustomList<T> listTwo)
        {
            CustomList<T> listThree = new CustomList<T>();
            listThree= listThree.TransferListContents(listOne);

            for (int x = 0; x < listTwo.listCount; x++)                 //for each item in list2 (list2Item)
            {
                T listTwoItem = listTwo[x];                         
                for (int i = 0; i < listThree.listCount; i++)             //loop through list1     (list1Item)
                {
                    T listThreeItem = listThree[i];
                    if (listThreeItem.Equals(listTwoItem) == true)    //If they are equal
                    {
                        listThree.Remove(listTwoItem);                //remove from list1                            
                    }
                }
            }
            return listThree;
        }

        public CustomList<T> TransferListContents(CustomList<T> listOne)
        {
            CustomList<T> listTwo = new CustomList<T>();
            for (int x = 0; x < listOne.listCount; x++)
            {
                listTwo.Add(listOne[x]);
            }
            return listTwo;
        }



        public T[] Resize()
        {
            capacity *= 2;
            T[] inputs2 = new T[capacity];
            for (int x = 0; x < inputs.Length; x++)
            {
                inputs2[x] = inputs[x];
            }
            inputs = inputs2;
            return inputs;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int x = 0; x <= inputs.Length; x++)
            {
                yield return inputs[x];
            } 
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}

