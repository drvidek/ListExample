using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    //This will be all our possible items
    public string[] possibleItems = new string[] { "Apple", "Potion", "Sword" };

    //This will be the items the player actually has currently
    public List<string> currentItems = new List<string>();

    //This will be used to determine which item to add at random
    private int index;

    //this will temporarily hold the item we should add
    private string randomItem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            //Get a random position in our Item array
            index = Random.Range(0, possibleItems.Length);

            //Use that position to get one of our items
            randomItem = possibleItems[index];

            //Add the item to the list
            currentItems.Add(randomItem);
            Debug.Log("Player receieved one " + randomItem);
        }

        if (Input.GetKeyDown(KeyCode.D))
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
    }
}
