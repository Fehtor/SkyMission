using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireBallSpeed;
    public GameObject fireBall;
    public Transform fireBallSpawn;
    private GameObject clone;
    public float fireRate;
    float lastShootTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            float currentShootTime = Time.time;
           
            if(currentShootTime - lastShootTime >= fireRate)
            {
                Shoot();
                lastShootTime = currentShootTime;
            }
        }
    }
   public void Shoot()
    {
        clone = Instantiate(fireBall, fireBallSpawn.position, Quaternion.identity);
        
    }
}
