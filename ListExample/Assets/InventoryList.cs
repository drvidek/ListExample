using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    //This will be all our possible items
    public string[] possibleItems = new string[] { "Apple", "Potion", "Sword" };

    //This will be the items the player actually has currently
    public List<string> currentItems = new List<string>();

    public string[] copiedItems;

    //This will be used to determine which item to add at random
    private int index;

    //this will temporarily hold the item we should add
    private string randomItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //This demonstrates List.Add()
            AddRandomItem();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            //This demonstrates List.Remove()
            EatAnApple();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //This demonstrates while loop
            ReduceInventory();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            //This demonstrates for loop
            CopyInventory();
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //This demonstrates foreach loop
            SummariseContents();
        }

    }

    private void AddRandomItem()
    {
        //Get a random position in our Item array
        index = Random.Range(0, possibleItems.Length);

        //Use that position to get one of our items
        randomItem = possibleItems[index];

        //Add the item to the list
        currentItems.Add(randomItem);
        Debug.Log("Player receieved one " + randomItem);
    }

    private void EatAnApple()
    {
        //If we successfully remove an apple...
        if (currentItems.Remove("Apple"))
        {
            //Then we can heal the player etc.
            Debug.Log("Player ate one apple!");
        }
        else
        {
            //else, there were no apples in the inventory
            Debug.Log("The player has no apples!");
        }
    }

    private void ReduceInventory()
    {
        int numberRemoved = 0;

        //while - aka "as long as this is true"
        //as long as there are more than 10 items in the list...
        while (currentItems.Count > 10)
        {
            //keep removing one item at a time
            currentItems.RemoveAt(currentItems.Count - 1);

            //count one item removed each time
            numberRemoved++;
        }

        //We only reach this code when "(currentItems.Count > 10)" is no longer true
        Debug.Log(numberRemoved + " items were removed to reduce the inventory to 10 items.");
    }


    private void CopyInventory()
    {
        //Set our array to match the size of our list
        copiedItems = new string[currentItems.Count];

        //for - basically a while loop with a built in counter
        //for as long as i, (starting at 0), is less than the size of our list...
        for (int i = 0; i < currentItems.Count; i++)
        {
            //copy the item at position i in our list, to the copy array (also at position i)
            copiedItems[i] = currentItems[i];

            Debug.Log("Copied the item at position " + i);
            //When we reach here, our code increases i by 1 automatically, and checks the loop again
        }
    }

    private void SummariseContents()
    {
        int appleCount = 0;
        int potionCount = 0;
        int swordCount = 0;

        //foreach - do something with every item in a collection
        //for every string in our currentItems list...
        foreach (string item in currentItems)
        {
            //"item" will be one of the values from the list
            if (item == "Apple")
            {
                Debug.Log("Found an apple");
                appleCount++;
            }
            if (item == "Potion")
            {
                Debug.Log("Found a potion");
                potionCount++;
            }
            if (item == "Sword")
            {
                Debug.Log("Found a sword");
                swordCount++;
            }
        }

        Debug.Log($"The player has... {appleCount} apples. {potionCount} potions. {swordCount} swords.");
    }
}
