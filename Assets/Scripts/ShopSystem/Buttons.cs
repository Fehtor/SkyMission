using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    GameObject shopSystem;
    // Start is called before the first frame update
    void Start()
    {
        shopSystem = GameObject.FindGameObjectWithTag("ShopSystem");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetButton()
    {
        ShopManager shopManager = shopSystem.GetComponent<ShopManager>();
        shopManager.ButtonReceive(gameObject);
            
    }
}
