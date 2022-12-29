using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoomsLevel
{
    first, 
    second,
    third,
    
}

public class EnemySpawn : MonoBehaviour
{
    private RoomsLevel levelOfRoom;

    [SerializeField] GameObject EasyEnemy;
    [SerializeField] GameObject MediumEnemy;
    [SerializeField] GameObject HardEnemy;

    
    public GameObject GetEnemies(int depth)
    {
        if(depth < 3)
        {
            levelOfRoom = RoomsLevel.first;
        }
        if(depth < 5)
        {
            levelOfRoom = RoomsLevel.first;
        }
        if(depth < 9)
        {
            levelOfRoom = RoomsLevel.first;
        }

        switch (levelOfRoom)
        {
            case RoomsLevel.first:
                return EasyEnemy;
                
            case RoomsLevel.second:
                return MediumEnemy;
                
            case RoomsLevel.third:
                return HardEnemy; 
                
            default:
                return EasyEnemy;
                
        }
    }

}
