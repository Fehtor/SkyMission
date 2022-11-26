using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum EnemyState
{
    patrol,
    attack
}
public enum EnemyType
{
    Nightmare
}


public class EnemyController : MonoBehaviour
{
    private int nummOfHealCrystals;
    

    public EnemyType enemyType;
    private float skillCharging = 0;
    public Image SkillBar;

    private Animator anim;
    private EnemyState enemyState;
    private int enemyLayer;
    private int PlayerLayer;
    
    public int radius;
    private GameObject Player;
   
    public static bool playerDetected = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        PlayerLayer = LayerMask.NameToLayer("Player");
        enemyLayer = LayerMask.NameToLayer("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");

        enemyState = EnemyState.patrol;
    }

    // Update is called once per frame
    void Update()
    {
        
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position - Player.gameObject.transform.position, radius, ~enemyLayer);
            if (hit == Player)
            {
                playerDetected = true;
                enemyState = EnemyState.attack;
            }
        switch (enemyState)
        {
            case EnemyState.patrol:
                anim.SetBool("isRunning", false);
                    break;
            case EnemyState.attack:
                anim.SetBool("isRunning", true);
                break;
        }
    }
   

    public void EnemyGiveDamage(GameObject player)
    {
        PlayerHealrhSystem hs = player.GetComponent<PlayerHealrhSystem>();
        hs.ChangeHealth(10);
        BaffSystem baffSystem = player.GetComponent<BaffSystem>();
        baffSystem.ReceiveObjects(1000, BaffType.SpeedBaff);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == PlayerLayer)
        {
            EnemyGiveDamage(collision.gameObject);
        }
    }

    public void skillBarFil()
    {
        switch (enemyType)
        {
            case EnemyType.Nightmare:
                skillCharging = 10;
                SkillBar.fillAmount = SkillBar.fillAmount + (skillCharging / 100);
                break;
        }
    }

    public void AfterDeath(GameObject crystall)
    {
        switch (enemyType)
        {
            case EnemyType.Nightmare:
                nummOfHealCrystals = Random.Range(0, 1);
                while(nummOfHealCrystals > 0)
                {
                    Instantiate(crystall, transform.position, Quaternion.identity);
                    nummOfHealCrystals--;
                }
                break;
        }
    }
}
