using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public float health = 50f;
    public GameObject collectable;

    public void TakeDamage(float amt)
    {
        health -= amt;
        Debug.Log(health);

        if(health <= 0f)
        {
            Instantiate(collectable, gameObject.transform.position, Quaternion.identity);
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
