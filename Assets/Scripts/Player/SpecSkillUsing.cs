using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecSkillUsing : MonoBehaviour
{
  
    public GameObject specSkill;
    public float time;

    public Image skillBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)  && skillBar.fillAmount == 1f)
        {
            skillBar.fillAmount = 0;
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
