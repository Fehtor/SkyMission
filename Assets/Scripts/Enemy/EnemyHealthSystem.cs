using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class EnemyHealthSystem : MonoBehaviour
{
    public Image healthBar;
    public float health = 100;
    public float allHealth;
    private int fireBall;

    public int healthChangeValue;
    public GameObject Crystalls;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            EnemyController enemyController = gameObject.GetComponent<EnemyController>();
            enemyController.skillBarFil();
            enemyController.AfterDeath(Crystalls);
            Destroy(gameObject);
        }

    }
    public void ChangeHealth(float value)
    {
        health -= value;
        healthBar.fillAmount = (health / 100);
        if (health > allHealth) health = allHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fireBall = LayerMask.NameToLayer("FireBall");
        Debug.Log(collision.gameObject);
        if (collision.gameObject.layer == fireBall)
        {
            ChangeHealth(healthChangeValue);
        }
    }
}


