using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour
{
    public int scoreValue = 1;
    bool hit = false;

    void OnTriggerEnter(Collider other)
    {
        //Check if the collider's parent has the tag Player
        if (other.transform.root.CompareTag("Player"))
        {
            hit = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hit == true)
        {
            GameManager.instance.ChangeScore(scoreValue);
            Destroy(gameObject);
        }
    }
}