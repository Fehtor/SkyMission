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
        Debug.Log(hits);
        if(hits != null)
        {
            EnemyPoisoning();
        }
    }
    
    public void EnemyPoisoning()
    {
        Debug.Log(hits.Count);
        for (int i = 0; i < hits.Count; i++)
        {
                BaffSystem baffSystem = hits[i].collider.gameObject.GetComponent<BaffSystem>();
                baffSystem.ReceiveObjects(5, BaffType.HealthDebaff);
                Debug.Log("sjdjdf");
        }
        
    }
}
