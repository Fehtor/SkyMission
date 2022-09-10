using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaSystem : MonoBehaviour
{
    public Image manaBar;
    public float mana;
    public float allMana;
    public float manaRecovery;
    private bool needRecover = true;
    // Start is called before the first frame update
    void Start()
    {
        ManaAdd(5);
    }

    // Update is called once per frame
    void Update()
    {
        if(mana < allMana && needRecover)
        {
            StartCoroutine("ManaRecover");
            needRecover = false;
        }
        else
        {
            StopCoroutine("ManaRecover");
            needRecover = true;
        }
    }
    public void ManaAdd(float manaToAdd)
    {
        manaBar.fillAmount = (mana + manaToAdd) / 100;
        mana += manaToAdd;
    }

    public void ManaSpend(float manaToSpend)
    {
        manaBar.fillAmount = (mana - manaToSpend) / 100;
        mana -= manaToSpend;
    }
    

    IEnumerator ManaRecover()
    {
        ManaSystem manaSyst = gameObject.GetComponent<ManaSystem>();
        yield return new WaitForSeconds(manaRecovery);
        manaSyst.ManaAdd(1);
    }
}
