﻿using System.Diagnostics.Metrics;

namespace NUnitTests.Homework
 
{
    internal class LoopsAndCase
    {
        public readonly List<string> CarManufacturers =
         [
             "Toyota", "Ford", "Honda", "Chevrolet", "Nissan",
                        "BMW", "Mercedes-Benz", "Volkswagen", "Hyundai", "Audi"
         ];

        [Test, Description("TODO use foreach loop to count all CarManufacturers names")]
        public void TestForeach()
        {
            int counter = 0;
            char[] characters;
            foreach (var item in CarManufacturers)
            {
                characters = item.ToCharArray();
                if (characters.Length<=5)
                {
                    counter++;
                }
            }
            
            Assert.That(counter, Is.EqualTo(4),"Amount of Car names isnt 4");

            // apply next logic

            // foreach string name in CarManufacturers
            // if name length less or equal 5
            // increase counter
            // after loop end assert that counter is equal to 4

        }

        [Test, Description("TODO use while loop to get a new list of car brands where brand nama is less than 5 characters.\r\n")]
        public void TestWhileLoop()
        {
            List<string> ShortCarManufacturerNames = new List<string>(); ;
            char[] characters;
           
            int counter = 0;
            while (counter<CarManufacturers.Count) 
            {
                characters = CarManufacturers[counter].ToCharArray();
                if( characters.Length<=5)
                {
                    ShortCarManufacturerNames.Add(CarManufacturers[counter]);
                    
                }
                counter++;
            }
            Assert.That(ShortCarManufacturerNames.Count, Is.EqualTo(4), "Amount of Car names isnt 4");
            foreach (var item in ShortCarManufacturerNames)
            {
                Assert.That(item.Length, Is.LessThan(6), $"Car name '{item}' is longer than 5 symbols");
            }


            string[] emptyArray = [];
            decimal number = 1.01M;

            // apply next logic

            // while counter less thant CarManufacturers size and name length less or equal 5
            // add current name into ShortCarManufacturerNames
            // increment counter
            // after loop foreach strings 'name' in ShortCarManufacturerNames assert name length less than 5 craracters 
        }

        float number = 1.01F;

        [Test, Description("TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")]
        public void TestForLoop()
        {
            List<string> ShortCarManufacturerNames = new(CarManufacturers);
            char[] characters;
            for (int i = ShortCarManufacturerNames.Count-1; i>=0;i--)
            {
                characters = ShortCarManufacturerNames[i].ToCharArray();
                if (characters.Length > 5)
                {
                    ShortCarManufacturerNames.RemoveAt(i);

                }

            }
            foreach (var item in ShortCarManufacturerNames)
            {
                Assert.That(item.Length, Is.LessThan(6), $"Car name '{item}' is longer than 5 symbols");
            }
            // apply next logic
            // caution - starting loop from last element to avoid modifying a collection while iterating over it

            // for index equal ShortCarManufacturerNames length - 1, while index less or equal 0, increment index
            // if ShortCarManufacturerNames by index .length is less or equal 5
            // remove ShortCarManufacturerNames by index
            // after loop finishes
            // foreach strings 'name' in ShortCarManufacturerNames assert name length less than 5 craracters 
        }

        [Test, Description("TODO: Use for cycle to remove items from ShortCarManufacturerNames that are less than 5 characters long")]
        public void TestSwitchCaseSelection()
        {
            List<string> ShortCarManufacturerNames = new(CarManufacturers);
            int requestedIndex = 2;
            string selectedName="Incorrect Name";

            switch (requestedIndex)
            {
                case 0:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 1:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 2:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 3:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 4:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 5:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 6:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 7:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 8:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;

                case 9:
                    selectedName = ShortCarManufacturerNames[requestedIndex];
                    break;
                default:
                    Assert.Fail("Incorrect index");
                    break;
            }
            Assert.That(selectedName, Is.EqualTo(ShortCarManufacturerNames[requestedIndex]), " Car name is incorrect");

        }
            // apply next logic

            // use switch case selection to select manufacturer by requestedIndex
            // make cases from 0 to 9 as first index in list is 0
            // rewrite selectedName with ShortCarManufacturerNames by requestedIndex    
            // Assert that string selectedName is eqal to expected string (for example 2 = "Honda")
    }
}

