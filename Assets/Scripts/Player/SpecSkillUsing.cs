using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecSkillUsing : MonoBehaviour
{
  
    public GameObject specSkill;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            specSkill.gameObject.transform.position = transform.position;
            specSkill.gameObject.SetActive(true);
            StartCoroutine("stopSpecSkill");
        }
    }

    IEnumerator stopSpecSkill()
    {
        yield return new WaitForSeconds(time);
        specSkill.gameObject.SetActive(false);
        StopCoroutine("stopSpecSkill");
    }
}
