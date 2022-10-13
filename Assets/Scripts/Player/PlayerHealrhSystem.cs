using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealrhSystem : MonoBehaviour
{
   

    public Image healthBar;
    public float health = 100;
    public Image tookDamageBar;
    public float allHealth;
    private int fireBall;

    public int healthChangeValue;

    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            EnemyController enemyController = gameObject.GetComponent<EnemyController>();
            enemyController.skillBarFil();
            Destroy(gameObject);
        }

        if (tookDamageBar.fillAmount <= healthBar.fillAmount)
        {
            StopCoroutine("DamageTakedBar");
            tookDamageBar.fillAmount = healthBar.fillAmount;
        }
       
        

    }
    public void ChangeHealth(float value)
    {
        health -= value;
        healthBar.fillAmount = (health / 100);
        StartCoroutine("DamageTakedBar");
        if (health > allHealth) health = allHealth;  
    }
   
   
    IEnumerator DamageTakedBar()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            yield return new WaitForSeconds(0.003f);
            tookDamageBar.fillAmount -= 0.001f;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        fireBall = LayerMask.NameToLayer("FireBall");
        Debug.Log(collision.gameObject);
        if(collision.gameObject.layer == fireBall)
        {
            ChangeHealth(healthChangeValue);
        }
    }
}
