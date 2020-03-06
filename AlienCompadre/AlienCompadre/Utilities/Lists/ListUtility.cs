using System;
using System.Collections.Generic;

namespace AlienCompadre.Utilities.Lists
{
    public class ListUtility
    {
        public static void ShuffleList<E>(ref List<E> inputList)
        {
            List<E> randomList = new List<E>();
            Random r = new Random();
            int randomIndex;

            while (inputList.Count > 0)
            {
                randomIndex = r.Next(0, inputList.Count); //Choose a random object in the list
                randomList.Add(inputList[randomIndex]); //add it to the new, random list
                inputList.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            inputList = randomList;
        }
    }
}
