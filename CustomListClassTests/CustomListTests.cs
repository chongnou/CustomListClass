using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CustomListClass;

namespace CustomListClassTests
{
    [TestClass]
    public class CustomListTests
    {

        //Item was added to the list
        //List count has increased
        //List index is equal to list count -1

        [TestMethod]

        public void CustomListAdd_Element_WasAddedToList()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            int expected = 32;
            int actual;

            //Act
            listName.Add(expected);
            actual = listName[0];
                
            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomListAdd_ListCount_IncreasedByOne()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            int firstInt = 32;
            int expected = 1;
            int actual;

            //Act
            listName.Add(firstInt);
            actual = listName.ListCount();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomListAdd_ListIndex_EqualsNumberOfElementsMinusOne()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            int expected = 32;
            int actual;

            //Act
            listName.Add(expected);
            actual = listName[0];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        //Capacity increase to accomodate more items

        [TestMethod]
        public void CustomListRemove_ListElement_IsNotInList()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            listName.Add(1);
            listName.Add(3);
            listName.Add(5);

            //Act
            listName.Remove(1);

            //Assert
            Assert.IsFalse(listName[0] == 1);
        }

        [TestMethod]
        public void CustomListRemove_ListCount_IsZeroIfNoElements()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            listName.Add(5);
            int? expected = 0;
            int actual;

            //Act
            listName.Remove(5);
            actual = listName.ListCount();

            //Assert  
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CustomListRemove_ListIndexes_ResetToFillGap()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            listName.Add(1);
            listName.Add(3);
            listName.Add(5);

            //Act
            listName.Remove(3);

            //Assert
            Assert.IsTrue(listName[1] == 5);
        }

        [TestMethod]
        public void CustomListCount_ListCount_StartsAtOne()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            listName.Add(64);
            int expected = 1;
            int actual;

            //Act
            actual = listName.ListCount();

            //Assert
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CustomListCount_ListCount_IncreasesAfterEachAddedItem()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            listName.Add(64);
            listName.Add(32);
            listName.Add(16);
            int expected = 3;
            int actual;

            //Act
            actual = listName.ListCount();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Resize_NewArraySize_IsGreaterByFiftyPercent()
        {
            //Arrange
            CustomList<int> listName = new CustomList<int>();
            int expected = listName.capacity;

            //Act
            listName.Add(64);
            listName.Add(32);   //Resize #1 (5/2 = 2)
            listName.Add(16);
            listName.Add(46);
            listName.Add(23);   //Resize #2 (10/2 = 5) Capacity is now 20;
            listName.Add(61);
            int actual = listName.capacity;

            //Assert
            Assert.AreEqual(expected, (actual/4));
        }

        [TestMethod]
        public void ZipNewArray_ReturnedArray_ZippedNewItems()
        {
            //Arrange
            CustomList<int> listOne = new CustomList<int>();
            listOne.Add(64);
            listOne.Add(32);
            listOne.Add(16);
            CustomList<int> listTwo = new CustomList<int>();
            listTwo.Add(46);
            listTwo.Add(23);
            listTwo.Add(61);
            CustomList<int> expected = new CustomList<int>{};
            expected.Add(64);
            expected.Add(46);
            expected.Add(32);
            expected.Add(23);
            expected.Add(16);
            expected.Add(61);
            CustomList<int> actual = new CustomList<int>();
            int x = 3;

            //Act
            actual = listOne.ZipNewArray(listOne, listTwo);

            //Assert
            Assert.AreEqual(expected[x], actual[x]);
        }

        [TestMethod]
        public void PlusOperator_ReturnedList_IsFirstListThenSecondListItems()
        {
            //Arrange
            CustomList<string> listOne = new CustomList<string>();
            listOne.Add("This");
            listOne.Add("add");
            listOne.Add("operator");
            CustomList<string> listTwo = new CustomList<string>();
            listTwo.Add("is");
            listTwo.Add("working!");
            CustomList<string> expected = new CustomList<string>();
            expected.Add("This");
            expected.Add("add");
            expected.Add("operator");
            expected.Add("is");
            expected.Add("working!");
            CustomList<string> actual = new CustomList<string>();
            int x = 3;

            //Act
            actual = listOne + listTwo;

            //Assert
            Assert.AreEqual(expected[x], actual[x]);
        }

        [TestMethod]
        public void MinusOperator_ReturnedList_DoesNotContainList2Elements()
        {
            //Arrange
            CustomList<string> listOne = new CustomList<string>{"This", "add", "operator", "is", "working!"};
            CustomList<string> listTwo = new CustomList<string>{"add"};
            CustomList<string> expected = new CustomList<string>{ "This", "operator", "is", "working!" };
            CustomList<string> actual = new CustomList<string>();

            //Act
            actual = listOne - listTwo;

            //Assert
            Assert.AreEqual(expected[3], actual[3]);
        }

        [TestMethod]
        public void MinusOperator_ReturnedList_RemovedAllSubtractedItems()
        {
            //Arrange
            CustomList<int> listOne = new CustomList<int> { 8, 16, 32, 32, 64 };
            CustomList<int> listTwo = new CustomList<int> { 16, 32 };
            CustomList<int> expected = new CustomList<int> { 8, 32, 64 };
            CustomList<int> actual = new CustomList<int>();

            //Act
            actual = listOne - listTwo;

            //Assert
            Assert.AreEqual(expected[3], actual[3]);
        }

        public void MinusOperator_ListOne_IsUnchangedIfNothingToRemove()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
