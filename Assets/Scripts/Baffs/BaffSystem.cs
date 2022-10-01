using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BaffType
{
    Poison,
    HealthDebaff, 
    ManaDebaff,
    SpeedBaff
}
public class BaffSystem : MonoBehaviour
{
    public List<Baff> baffs;
    public int value = 7;
    PlayerHealrhSystem hs;

    // Start is called before the first frame update
    void Start()
    {
        Baff healthBaff = new Baff();
        healthBaff.baffType = BaffType.HealthDebaff;
        healthBaff.value = 5;
        baffs.Add(healthBaff);

        Baff ManaDebaff = new Baff();
        ManaDebaff.baffType = BaffType.ManaDebaff;
        ManaDebaff.value = 5;
        baffs.Add(ManaDebaff);

        Baff SpeedBaff = new Baff();
        SpeedBaff.baffType = BaffType.HealthDebaff;
        SpeedBaff.value = 5;
        baffs.Add(SpeedBaff);

        Baff Poison = new Baff();
        Poison.baffType = BaffType.HealthDebaff;
        Poison.value = 5;
        baffs.Add(Poison);
        StartCoroutine("Timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        while (true)
        {
            foreach (var baff in baffs)
            {
                if (baff.baffTimeLeft <= 0)
                {
                    continue;
                }
                switch (baff.baffType)
                {
                    case BaffType.Poison:
                           PlayerMove playerMove = gameObject.GetComponent<PlayerMove>();
                           playerMove.speed = playerMove.maxSpeed / 2;
                        break;
                    case BaffType.HealthDebaff:
                            PlayerHealrhSystem hs = gameObject.GetComponent<PlayerHealrhSystem>();
                            hs.ChangeHealth(value);
                        break;
                    case BaffType.ManaDebaff:
                            ManaSystem manaSystem = gameObject.GetComponent<ManaSystem>();
                            manaSystem.ManaSpend(value);
                        break;
                    case BaffType.SpeedBaff:
                            playerMove = gameObject.GetComponent<PlayerMove>();
                            playerMove.speed += 50;
                        break;
                    default:
                        break;
                }
                baff.baffTimeLeft--;
            }
            yield return new WaitForSeconds(1f);
        }
    }


    public void ReceiveObjects(float baffTimeLeft, BaffType baffTypes)
    {
        
        switch (baffTypes)
        {
            case BaffType.Poison:
                baffs[3].baffTimeLeft = baffTimeLeft;
                break;
            case BaffType.HealthDebaff:
                baffs[0].baffTimeLeft = baffTimeLeft;
                break;
            case BaffType.ManaDebaff:
                baffs[1].baffTimeLeft = baffTimeLeft;
                break;
            case BaffType.SpeedBaff:
                baffs[2].baffTimeLeft = baffTimeLeft;
                break;
            default:
                break;
        }
    }

    
}
