using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAnims : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DisableAnim()
    {
        animator.SetInteger("Disabled", 2);
    }

    public void EnableAnim()
    {
        animator.SetInteger("Disabled", 1);
    }
}
