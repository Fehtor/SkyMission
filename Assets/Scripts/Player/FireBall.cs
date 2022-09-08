using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private int playerLayer;
    Vector3 mousePos;
    public LayerMask layerMask;
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
