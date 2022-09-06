using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int enemyLayer;
    private int PlayerLayer;
    public LayerMask layerMask;
    public int radius;
    public int speed;
    public float health = 100;
    // Start is called before the first frame update
    void Start()
    {
        PlayerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D gameObj = Physics2D.OverlapCircle(transform.position, radius);
        
        if(gameObj.gameObject.layer == PlayerLayer)
        {
            GameObject Player = gameObj.gameObject;
            PlayerLayer = LayerMask.NameToLayer("Player");

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position - Player.gameObject.transform.position, radius, PlayerLayer);

            if (hit == Player)
            {

                transform.position = Vector2.MoveTowards(transform.position, Player.gameObject.transform.position, speed * Time.deltaTime);
            }
            
        }
        Debug.Log(gameObj);

    }
    public void EnemyRecieveDamage()
    {

    }

    public void EnemyGiveDamage()
    {

    }

  
}
