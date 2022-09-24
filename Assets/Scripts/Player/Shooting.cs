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

    
    public GameObject ManaController;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ManaSystem manaSyst = ManaController.GetComponent<ManaSystem>();
            float currentShootTime = Time.time;
           
            if(currentShootTime - lastShootTime >= fireRate && manaSyst.mana - 10 >= 0)
            {
                Shoot();
                lastShootTime = currentShootTime;
            }
        }
       
    }
   public void Shoot()
    {
        StopCoroutine("EnableManaRecover");
        clone = Instantiate(fireBall, fireBallSpawn.position, Quaternion.identity);
        ManaSystem manaSyst = ManaController.GetComponent<ManaSystem>();
        manaSyst.ManaSpend(10);
        ManaSystem.mayRecover = false;
        StartCoroutine("EnableManaRecover");
    }

    IEnumerator EnableManaRecover()
    {
        yield return new WaitForSeconds(1);
        ManaSystem.mayRecover = true;
        Debug.Log("StartRecovering");
    }
}
