using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BaffType
{
    Poison,
    playerHealthDebaff, 
    enemyHealthDebaff, 
    ManaDebaff,
    SpeedBaff,
    ManaBaff
}
public class BaffSystem : MonoBehaviour
{
    public List<Baff> baffs;
    public float healValue = 7;
    public float manaValue = 7;
    public float time;
    PlayerHealrhSystem hs;
    [SerializeField] ManaSystem ManaSystem;

    private GameObject Player;
    PlayerMove playerMove;
    // Start is called before the first frame update
    void Start()
    {

        Player = GameObject.FindGameObjectWithTag("Player");
        playerMove = Player.GetComponent<PlayerMove>();

        if(gameObject.tag == "Player")
        {
            Baff ManaDebaff = new Baff();
            ManaDebaff.baffType = BaffType.ManaDebaff;
            baffs.Add(ManaDebaff);
            
            Baff ManaBaff = new Baff();
            ManaBaff.baffType = BaffType.ManaBaff;
            baffs.Add(ManaBaff);

            Baff SpeedBaff = new Baff();
            SpeedBaff.baffType = BaffType.SpeedBaff;
            baffs.Add(SpeedBaff);

            Baff playerHealthBaff = new Baff();
            playerHealthBaff.baffType = BaffType.playerHealthDebaff;
            baffs.Add(playerHealthBaff);
        }
        Baff enemyHealthBaff = new Baff();
        enemyHealthBaff.baffType = BaffType.enemyHealthDebaff;
        baffs.Add(enemyHealthBaff);


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
                           // Debug.Log(gameObject.name);
                            
                            break;
                    }       
                 
                    continue;
                }



                switch (baff.baffType)
                {
                    case BaffType.Poison:
                           playerMove.speed = playerMove.maxSpeed / 2;
                        break;
                    case BaffType.playerHealthDebaff:
                            PlayerHealrhSystem hs = gameObject.GetComponent<PlayerHealrhSystem>();
                            hs.ChangeHealth(-healValue);
                        break;
                    case BaffType.enemyHealthDebaff:
                            EnemyHealthSystem ehs = gameObject.GetComponent<EnemyHealthSystem>();
                            ehs.ChangeHealth(-healValue);
                        break;
                    case BaffType.ManaDebaff:
                           ManaSystem.ManaSpend(manaValue);
                        break;
                    
                    case BaffType.ManaBaff:
                           ManaSystem.ManaAdd(manaValue);
                        break;

                    case BaffType.SpeedBaff:
                            playerMove = gameObject.GetComponent<PlayerMove>();
                            playerMove.speed = playerMove.maxSpeed + 5;
                        Debug.Log(gameObject.name +  " Player speed " +  playerMove.speed);
                        break;
                    default:
                        break;
                }
                baff.baffTimeLeft--;                
            }
            yield return new WaitForSeconds(time);
        }
    }


    public void ReceiveObjects(float baffTimeLeft, BaffType baffTypes)
    {
        foreach (var baff in baffs)
        {
            if(baff.baffType == baffTypes)
            {
                baff.baffTimeLeft = baffTimeLeft;
                break;
            }
        }
    }
}
