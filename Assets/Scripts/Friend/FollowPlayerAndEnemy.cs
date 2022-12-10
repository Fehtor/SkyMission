using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayerAndEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform PlayerPos;
    public int speed;

    private bool playerInSmallCircle;
    private bool playerInBigCircle;
    private Collider2D enemy;

    [SerializeField] private LayerMask playerMask;
    [SerializeField] private LayerMask enemyMask;

    private EnemyHealthSystem enemyHealthSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {

        playerInSmallCircle = Physics2D.OverlapCircle(transform.position, 2, playerMask);
        playerInBigCircle = Physics2D.OverlapCircle(transform.position, 10, playerMask);
        enemy = Physics2D.OverlapCircle(transform.position, 5, enemyMask);

        
        if (enemy == null && playerInBigCircle)
        {
            if (!playerInSmallCircle)
            {
                agent.SetDestination(PlayerPos.position);
            }
            else
            {
                agent.SetDestination(transform.position);
            }
        }
        else if(enemy != null && playerInBigCircle)
        {
            agent.SetDestination(enemy.gameObject.transform.position);
        }
        else
        {
            agent.SetDestination(PlayerPos.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyHealthSystem = collision.gameObject.GetComponent<EnemyHealthSystem>();
            enemyHealthSystem.ChangeHealth(8);
        }
    }
}
