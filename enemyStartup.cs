using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyStartup : MonoBehaviour
{
    void Start()
    {
        // We are delaying 1.5f seconds before calling the function
        Invoke("delayAddingScript", 1.5f);

    }

    void delayAddingScript()
    {
        gameObject.AddComponent<NavMeshAgent>();
        gameObject.AddComponent<NewEnemyAI>();
        Destroy(GetComponent<Rigidbody>());
    }
}
