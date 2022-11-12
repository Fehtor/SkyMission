using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
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
}
