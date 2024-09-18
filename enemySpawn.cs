using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class enemySpawn : MonoBehaviour
{
    public int numEnemies = 10;
    public GameObject prefab;
    int originalChildren;
    Transform enemies;

    Random rand = new Random();

    void makeAChild()
    {
        // Grab some random coordinates
        float childX = rand.Next(50);
        float childZ = rand.Next(50);

        // Make a new gameobject, instantiate a copy of the prefab at the location we randomised
        GameObject newChild = Instantiate(prefab, new Vector3(childX, 10f, childZ), Quaternion.identity) as GameObject;


        // Set the parent of the enemy to be the Enemies game object
        newChild.transform.parent = enemies;
    }

    void Start()
    {
        enemies = GameObject.Find("Enemies").transform;
        for (int i = 0; i < numEnemies; i++)
        {
            makeAChild();
        }

        // Count how many children there are
        originalChildren = transform.childCount;
    }

    void Update()
    {
        // Get the current number of enemies
        int currentChildren = transform.childCount;

        // if there are less enemies than there were originally, make another
        if (currentChildren < originalChildren)
        {
            makeAChild();
        }
    }
}
