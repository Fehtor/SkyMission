using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Potion
{
    HealthRecover, 
    ManaRecover
}
public class Potions : MonoBehaviour
{
    public Potion potion;
    private GameObject player;
    private ManaSystem manaSystem;
    private PlayerHealrhSystem playerHS;
    public float value;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            manaSystem = collision.gameObject.GetComponentInChildren<ManaSystem>();
            playerHS = collision.gameObject.GetComponent<PlayerHealrhSystem>();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            switch (potion)
            {
                case Potion.HealthRecover:
                    StartCoroutine("PotionHealthRecovery");
                   
                        break;
                case Potion.ManaRecover:
                    StartCoroutine("PotionManaRecovery");
                    break;
            }
        }
    }

    IEnumerator PotionManaRecovery()
    {
       
        for (int i = 0; i < 10; i++)
        {
            manaSystem.ManaAdd(value / 10);
            yield return new WaitForSeconds(0.1f);
        }
    }

   IEnumerator PotionHealthRecovery()
    {
       
        for (int i = 0; i < 10; i++)
        {
            playerHS.ChangeHealth(-value / 10);
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
