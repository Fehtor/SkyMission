using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string description;
    public string questName; //enum; questName == discr
    public int calculator;
    [SerializeField]private int reward;
    [SerializeField]private bool isActive;
    [SerializeField]private bool isDone;


    public bool IsActiv()
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
