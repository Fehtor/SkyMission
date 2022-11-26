using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Cristall
{
    HealthRecover, 
    ManaRecover
}
public class Cristalls : MonoBehaviour
{
    public Cristall potion;
    private GameObject player;
    private ManaSystem manaSystem;
    private PlayerHealrhSystem playerHS;
    public float value;


    float startDistance;

    float duration = 1;

    [SerializeField] float minDuration;
    [SerializeField] float maxDuration;

    [SerializeField] float step;

    [SerializeField] float minRadius;
    [SerializeField] float maxRadius;

    private Vector3 destination = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        duration = Random.Range(minDuration, maxDuration);
        destination = Random.insideUnitCircle * Random.Range(minRadius, maxRadius);
        destination = transform.position + destination;
        startDistance = Vector3.Distance(transform.position, destination);

        StartCoroutine("CrystallFly");
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
                case Cristall.HealthRecover:
                    StartCoroutine("PotionHealthRecovery");
                   
                        break;
                case Cristall.ManaRecover:
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
            yield return new WaitForSeconds(0.01f);
        }
    }

   IEnumerator PotionHealthRecovery()
    {
       
        for (int i = 0; i < 10; i++)
        {
            playerHS.ChangeHealth(-value / 10);
            yield return new WaitForSeconds(0.03f);
        }
        
    }

    IEnumerator CrystallFly()
    {
        while (Vector3.Distance(transform.position, destination) >= step)
        {
            Debug.Log(duration * step / startDistance);
            transform.position = Vector2.MoveTowards(transform.position, destination, step);
            yield return new WaitForSeconds(duration * step / startDistance);
        }
    }
}
