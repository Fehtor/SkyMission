using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    

    private int enemyLayer;
    private int PlayerLayer;
    
    public int radius;
    private GameObject Player;
    public float health = 100;
    public static bool playerDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position - Player.gameObject.transform.position, radius, ~enemyLayer);
            Debug.Log(hit.collider);
            if (hit == Player)
            {
                playerDetected = true;
            }
        
    }
    public void EnemyRecieveDamage()
    {

    }

    public void EnemyGiveDamage(GameObject player)
    {
        PlayerHealrhSystem hs = player.GetComponent<PlayerHealrhSystem>();
        hs.TakeDamage(10);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == PlayerLayer)
        {
            EnemyGiveDamage(collision.gameObject);
        }
    }

}
