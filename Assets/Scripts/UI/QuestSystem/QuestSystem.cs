using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestSystem : MonoBehaviour
{
    private List<Quest> _quests = new List<Quest>();
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] questObjects = GameObject.FindGameObjectsWithTag("Quest");
        foreach (var questObject in questObjects)
        {
            _quests.Add(questObject.GetComponent<Quest>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Quest> GetActiveQuests()
    {
        List<Quest> activeQuests = new List<Quest>();
        foreach (var quest in _quests)
        {
            if (quest.IsActive())
            {
                activeQuests.Add(quest);
            }
            
        }

        return activeQuests;
    }


    public void ReceiveKilledEnemy(EnemyType enemyType)
    {
        foreach (var quest in GetActiveQuests())
        {
            if(quest.typeOfQuest == TypeOfQuest.KillForScore)
            {
                quest.CounterMinus(enemyType);
            }
        }
    }
}
