
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dict : MonoBehaviour
{public Dictionary<string, string> dict = new Dictionary<string, string>();
    
    // Start is called before the first frame update
    void Start()
    {
        AddWord("dog", "фобака");
        AddWord("cat", "кошечка");
        AddWord("Game", "шпилево");
        PrintDict();
        RemoveWord("Game");
        PrintDict();
       // Debug.Log(RussToEng("кошечка"));
       // Debug.Log(RussToEng("шпилево"));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddWord(string eng, string russ)
    {
        dict[eng] = russ; 
    }
    
    public void RemoveWord(string eng)
    {
        dict.Remove(eng);
    }

    public string EngToRuss(string eng)
    {
        return dict[eng];
    }

    public string RussToEng(string russ)
    {
        foreach(var item in dict)
        {
            if(item.Value == russ)
            {
                return item.Key;
            }
        }
        return null;
    }

    public void PrintDict()
    {
      //  Debug.Log("Our Dictionary:");
        foreach (var item in dict)
        {
            //Debug.Log(item.Key + " : " + item.Value);
        }
    }
}
