using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendHealthSyystem : MonoBehaviour
{
    public Image healthBar;
    [SerializeField] private float health = 20;
    [SerializeField] private float allHealth;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(health > allHealth)
        {
            ChangeHealth(1);
            StopCoroutine("HealthRegen");
        }
        if(health < allHealth)
        {
            StartCoroutine("HealthRegen");
        }
    }

    public void ChangeHealth(float value)
    {
        health -= value;
        healthBar.fillAmount = (health / 100);
        if (health > allHealth) health = allHealth;
    }

    IEnumerator HealthRegen()
    {
        yield return new WaitForSeconds(1f);
        ChangeHealth(-0.01f);
    }
}
