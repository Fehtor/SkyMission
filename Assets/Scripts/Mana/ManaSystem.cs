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
    public static bool mayRecover = false;

    private bool isRecovering = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isRecovering && (mana >= allMana || !mayRecover))
        {
            isRecovering = false;
            StopCoroutine("PassiveManaRecover");
        }
        if (mayRecover == true && !isRecovering)
        {
            StartCoroutine("PassiveManaRecover");
        }
    }
    public void ManaAdd(float manaToAdd)
    {
        manaBar.fillAmount = (mana + manaToAdd) / 100;
        mana += manaToAdd;
        if (mana > allMana) mana = allMana;
    }

    public void ManaSpend(float manaToSpend)
    {
        manaBar.fillAmount = (mana - manaToSpend) / 100;
        mana -= manaToSpend;
        
       
    }
    

    IEnumerator PassiveManaRecover()
    {
        isRecovering = true;
        yield return new WaitForSeconds(0.7f);
        while (true)
        {
            yield return new WaitForSeconds(manaRecovery);
            ManaAdd(1);
        }
    }

    IEnumerator PotionManaRecover()
    {
        int i = 10;
        while (i > 0)
        {
            yield return new WaitForSeconds(0.03f);
            ManaAdd(1);
            i--;
        }
    }
}
