using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealrhSystem : MonoBehaviour
{
    
    public Image healthBar;
    public float health = 100;
    public Image tookDamageBar;
   
    private int fireBall;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        if (tookDamageBar.fillAmount <= healthBar.fillAmount)
        {
            StopCoroutine("DamageTakedBar");
        }
       
        

    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        Debug.Log(health - damage);
        healthBar.fillAmount = (health / 100);

        StartCoroutine("DamageTakedBar");
        
        
    }
   
    IEnumerator PotionRegeneration()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.003f);
            healthBar.fillAmount += 0.01f;
        }
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
            TakeDamage(damage);
        }
    }
}
