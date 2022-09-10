using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int enemyLayer;
    private int PlayerLayer;
    public LayerMask layerMask;
    public int radius;
    
    public float health = 100;
    public static bool playerDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameObj = Physics2D.OverlapCircle(transform.position, radius).gameObject;
        Debug.Log(gameObj);
        if(gameObj.layer == PlayerLayer)
        {
            GameObject Player = gameObj;
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position - Player.gameObject.transform.position, radius, ~enemyLayer);
            if (hit == Player)
            {
                playerDetected = true;
            }
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
