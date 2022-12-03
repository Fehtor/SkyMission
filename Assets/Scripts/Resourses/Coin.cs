using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject player;
    private Wallet wallet;

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
        player = GameObject.FindGameObjectWithTag("Player");
        wallet = player.GetComponent<Wallet>();

        duration = Random.Range(minDuration, maxDuration);
        destination = Random.insideUnitCircle * Random.Range(minRadius, maxRadius);
        destination = transform.position + destination;
        startDistance = Vector3.Distance(transform.position, destination);

        StartCoroutine("CoinFly");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CoinFly()
    {
        while(Vector3.Distance(transform.position, destination) >= step)
        {
            Debug.Log(duration * step / startDistance);
            transform.position = Vector2.MoveTowards(transform.position, destination, step);
            yield return new WaitForSeconds(duration * step / startDistance);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            wallet.ChangeMoney(10);
            Destroy(gameObject);
        }
    }
}
