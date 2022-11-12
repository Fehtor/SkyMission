using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowQuestManager : MonoBehaviour
{
    List<GameObject> questPanels = new List<GameObject>();
    [SerializeField] private QuestSystem questSystem;
    // Start is called before the first frame update
    void Start()
    {
        List<Quest> ativeQuests = questSystem.GetActiveQuests();
        foreach (var quest in ativeQuests)
        {
            quest.name = 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
