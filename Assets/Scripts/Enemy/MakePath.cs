

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class MakePath : MonoBehaviour
{
    private NavMeshAgent agent;
    EnemyController Controller;
    public Transform PlayerPos;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        Controller = gameObject.GetComponent<EnemyController>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyController.playerDetected == true)
        {
            
            agent.SetDestination(PlayerPos.position);
        }
    }
}
