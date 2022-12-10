using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfQuest{
    KillForScore
}

public class Quest : MonoBehaviour
{
    public TypeOfQuest typeOfQuest;

    [Header("Quest Description")]
    [TextArea(3, 20)]public string description;
    public string questName;
    [SerializeField] private int reward;
    
    [Space]

    [Header("Counter")]
    public int counter;
    
    [Space]

    [Header("Settings")]
    [SerializeField]private bool isActive;
    [SerializeField]private bool isDone;


    public bool IsActive()
    {
        return isActive;
    }

    public bool IsDone()
    {
        return isDone;
    }

    public int GetReward()
    {
        return reward;
    }

    public void CounterMinus(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Nightmare:
                counter--;
                break;
            default:
                break;
        }

        if(counter == 0)
        {
            isDone = true;
        }
    }
}
