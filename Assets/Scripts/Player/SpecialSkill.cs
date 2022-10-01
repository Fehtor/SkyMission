using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialSkill : MonoBehaviour
{
    public float damage;
    PlayerHealrhSystem enemyHealrhSystem;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnDisable()
    {
        StopCoroutine("EnemyPoisoning");
    }
    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator EnemyPoisoning()
    {
        while (true)
        {
            enemyHealrhSystem.ChangeHealth(damage);
            yield return new WaitForSeconds(0.5f);
        }       

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemyHealrhSystem = collision.GetComponent<PlayerHealrhSystem>();
            StartCoroutine("EnemyPoisoning");
        }
    }
   
}
