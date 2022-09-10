using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRecovery : MonoBehaviour
{
    public float manaRecovery;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ManaRecover()
    {
        ManaSystem manaSyst = gameObject.GetComponent<ManaSystem>();
        yield return new WaitForSeconds(manaRecovery);
        manaSyst.ManaAdd(1);
    }
}
