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
       
    }

    // Update is called once per frame
    void Update()
    {

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
    IEnumerator DamageTakedBar()
    {
        yield return new WaitForSeconds(0.5f);
        while (true)
        {
            yield return new WaitForSeconds(0.003f);
            tookDamageBar.fillAmount -= 0.001f;
        }
        
    }
}
