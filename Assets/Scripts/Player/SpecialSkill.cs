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
        Debug.Log("start");
        
        StartCoroutine("EnemyPoisoning");
    }
    private void OnDisable()
    {
        StopCoroutine("EnemyPoisoning");
    }
    // Update is called once per frame
    void Update()
    {
        Physics2D.CircleCast(transform.position, collider.radius, Vector2.zero, contact, hits);
    }
    
    IEnumerator EnemyPoisoning()
    {
        while (true)
        {
            foreach (var hit in hits)
            {
                BaffSystem baffSystem = hit.collider.gameObject.GetComponent<BaffSystem>();
                baffSystem.ReceiveObjects(10, BaffType.HealthDebaff);
            }
            yield return new WaitForSeconds(0.00000001f);
        }
    }


   
}
