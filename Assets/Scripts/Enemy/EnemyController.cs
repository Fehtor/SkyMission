using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState
{
    patrol,
    attack
}
public class EnemyController : MonoBehaviour
{
    private Animator anim;
    private EnemyState enemyState;
    private int enemyLayer;
    private int PlayerLayer;
    
    public int radius;
    private GameObject Player;
    public float health = 100;
    public static bool playerDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");

        enemyState = EnemyState.patrol;
    }

    // Update is called once per frame
    void Update()
    {
        
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position - Player.gameObject.transform.position, radius, ~enemyLayer);
            Debug.Log(hit.collider);
            if (hit == Player)
            {
                playerDetected = true;
                enemyState = EnemyState.attack;
            }
        switch (enemyState)
        {
            case EnemyState.patrol:
                anim.SetBool("isRunning", false);
                    break;
            case EnemyState.attack:
                anim.SetBool("isRunning", true);
                break;
        }
    }
    public void EnemyRecieveDamage()
    {

    }

    public void EnemyGiveDamage(GameObject player)
    {
        PlayerHealrhSystem hs = player.GetComponent<PlayerHealrhSystem>();
        hs.ChangeHealth(10);
        BaffSystem baffSystem = player.GetComponent<BaffSystem>();
        baffSystem.ReceiveObjects(10, BaffType.Poison);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == PlayerLayer)
        {
            EnemyGiveDamage(collision.gameObject);
        }
    }

}
