using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class NewEnemyAI : MonoBehaviour
{
	Transform Player;
	NavMeshAgent agent;


	private void Awake()
	{
		agent = GetComponent<NavMeshAgent>();
		agent.speed = 3f;
		agent.stoppingDistance = 2.5f;

		Player = GameObject.Find("Player").transform;
	}

	void Update()
	{
		agent.SetDestination(Player.position);
	}
}

