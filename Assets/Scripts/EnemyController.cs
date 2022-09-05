using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int PlayerLayer;
    public LayerMask layerMask;
    public int radius;
    // Start is called before the first frame update
    void Start()
    {
        PlayerLayer = LayerMask.NameToLayer("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D gameObj = Physics2D.OverlapCircle(transform.position, radius);
        if(gameObj.gameObject.layer == PlayerLayer)
        {
            PlayerDetected(gameObj);
        }
        Debug.Log(gameObj);
    }
    public void EnemyRecieveDamage()
    {

    }

    public void EnemyGiveDamage()
    {

    }

    public void PlayerDetected(Collider2D gameOgj)
    {
        RaycastHit hit;
       // Physics2D.Raycast(transform.position, transform.position - gameOgj.gameObject.transform.position,  out hit, )
    }
}
