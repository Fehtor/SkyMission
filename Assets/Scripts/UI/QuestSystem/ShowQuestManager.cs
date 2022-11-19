using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowQuestManager : MonoBehaviour
{
    [SerializeField] private GameObject loaytGroup;
    [SerializeField] private GameObject contentPlane;
    [SerializeField] private GameObject questPanel;
    [SerializeField] private QuestSystem questSystem;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DelayedStart");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DelayedStart()
    {
        yield return new WaitForEndOfFrame();
        List<Quest> activeQuests = questSystem.GetActiveQuests();
        foreach (var activeQuest in activeQuests)
        {
            GameObject newQuestPanel = Instantiate(questPanel, loaytGroup.transform);
            Text[] texts = newQuestPanel.GetComponentsInChildren<Text>();
            if(texts[0].gameObject.name == "Title")
            {
                texts[0].text = activeQuest.questName;
                texts[1].text = activeQuest.description;
            }
            else
            {
                texts[1].text = activeQuest.questName;
                texts[0].text = activeQuest.description;
            }
        }
    }
}
