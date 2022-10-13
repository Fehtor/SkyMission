using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSkill : MonoBehaviour
{
    public float damage;
    PlayerHealrhSystem enemyHealrhSystem;
    private CircleCollider2D collider;
    public ContactFilter2D contact;
    List<RaycastHit2D> hits;

    public GameObject baffer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        hits = new List<RaycastHit2D>();
        collider = GetComponent<CircleCollider2D>();
        
    }
    private void OnDisable()
    {
        StopCoroutine("EnemyPoisoning");
    }
    // Update is called once per frame
    void Update()
    {
        Physics2D.CircleCast(transform.position, collider.radius, Vector2.zero, contact, hits);
        if(hits[0] != null)
        {
            EnemyPoisoning();
        }
    }
    
    public void EnemyPoisoning()
    {
        for (int i = 1; i < hits.Count; i++)
        {
            if(hits[i] != hits[i - 1])
            {
                BaffSystem baffSystem = hits[i - 1].collider.gameObject.GetComponent<BaffSystem>();
                baffSystem.ReceiveObjects(10, BaffType.HealthDebaff);
                Debug.Log("sjdjdf");

            }
            else
            {
                Debug.Log("sjdjdf");
                BaffSystem baffSystem = hits[i - 1].collider.gameObject.GetComponent<BaffSystem>();
                baffSystem.ReceiveObjects(10, BaffType.HealthDebaff);
                return;
            }
           
        }
        
    }
}
