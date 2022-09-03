using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{

    Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
       mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
       
        transform.Translate((mousePos - transform.position) * Time.deltaTime * 10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
    }
}
