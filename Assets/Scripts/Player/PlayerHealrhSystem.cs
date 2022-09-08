using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealrhSystem : MonoBehaviour
{
    
    public Image healthBar;
    float health = 100;
    public Image tookDamageBar;
    // Start is called before the first frame update
    void Start()
    {
        TakeDamage(5);
    }

    // Update is called once per frame
    void Update()
    {
        health = 100;
        if(healthBar.fillAmount != tookDamageBar.fillAmount)
        {
            StartCoroutine(DamageTakedBar());
        }
        else if (tookDamageBar.fillAmount == healthBar.fillAmount)
        {
            StopCoroutine(DamageTakedBar());
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount  *= (health / 100);
        
    }
    IEnumerator DamageTakedBar()
    {
        yield return new WaitForSeconds(0.5f);
        tookDamageBar.fillAmount -= 0.001f;
    }
}
