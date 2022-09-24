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
            ManaSystem manaSyst;
            manaSyst = collision.gameObject.GetComponent<ManaSystem>();
            PlayerHealrhSystem playerHS = collision.gameObject.GetComponent<PlayerHealrhSystem>();
            switch (potion)
            {
                case Potion.HealthRecover:
                    PotionHealthRegen(playerHS);
                        break;
                case Potion.ManaRecover:
                    manaSyst.StartCoroutine("PotionManaRecover");
                    break;
            }
                
            
        }
    }

    public void PotionHealthRegen(PlayerHealrhSystem playerHs)
    {
        if(playerHs.health >= 100)
        {
            return;
        }
        else if(playerHs.health < 100)
        {
            StartCoroutine("PotionRegeneration");
        }
    }
}
