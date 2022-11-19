using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfPartManager : MonoBehaviour
{
    [SerializeField]List<GameObject> parts = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivePart(GameObject gameObject)
    {
        foreach (var part in parts)
        {
            if(gameObject.name == part.name)
            {
                part.SetActive(true);
            }
            else
            {
                part.SetActive(false);
            }
        }
    }
}
