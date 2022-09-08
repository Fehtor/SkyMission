

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePath : MonoBehaviour
{
    EnemyController Controller;
    public Transform PlayerPos;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        Controller = gameObject.GetComponent<EnemyController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyController.playerDetected == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerPos.position, speed * Time.deltaTime);
        }
    }
}
