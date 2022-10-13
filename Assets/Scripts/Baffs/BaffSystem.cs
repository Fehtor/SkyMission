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

    private GameObject Player;
    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        playerMove = Player.GetComponent<PlayerMove>();

        Baff healthBaff = new Baff();
        healthBaff.baffType = BaffType.HealthDebaff;
        baffs.Add(healthBaff);

        Baff ManaDebaff = new Baff();
        ManaDebaff.baffType = BaffType.ManaDebaff;
        baffs.Add(ManaDebaff);

        Baff SpeedBaff = new Baff();
        SpeedBaff.baffType = BaffType.SpeedBaff;
        baffs.Add(SpeedBaff);

        Baff Poison = new Baff();
        Poison.baffType = BaffType.Poison;
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
                    switch (baff.baffType)
                    {
                        case BaffType.SpeedBaff:
                            playerMove.speed = playerMove.maxSpeed;
                            Debug.Log("Not here"); // сюда проходят 2 speedBaff, поэтому не робит
                            break;
                    }       
                 
                    continue;
                }



                switch (baff.baffType)
                {
                    case BaffType.Poison:
                           playerMove.speed = playerMove.maxSpeed / 2;
                        break;
                    case BaffType.HealthDebaff:
                            PlayerHealrhSystem hs = gameObject.GetComponent<PlayerHealrhSystem>();
                            hs.ChangeHealth(value);
                        Debug.Log("I'm here");
                        Debug.Log(baff.baffTimeLeft);
                        break;
                    case BaffType.ManaDebaff:
                            ManaSystem manaSystem = gameObject.GetComponent<ManaSystem>();
                            manaSystem.ManaSpend(value);
                        break;
                    case BaffType.SpeedBaff:
                            playerMove = gameObject.GetComponent<PlayerMove>();
                            playerMove.speed = playerMove.maxSpeed + 5;
                        Debug.Log("Player speed" + playerMove.speed);
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
