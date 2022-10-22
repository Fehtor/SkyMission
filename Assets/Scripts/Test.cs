using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
        
        Human vasya = new Human();
        vasya.name = "Василий";
        
        Human petia = new Human();
        petia.name = "Петр";

        Human vova = new Human();
        vova.name = "Владимир";

        Human[] people = { vasya, petia, vova };
        for (int i = 0; i < 18; i++)
        {
            foreach (var person in people)
            {
                person.HappyBirthday();
            }
        }
        foreach (var person in people)
        {
            //Debug.Log(person.GetAge());
        }

        Car Lada = new Car();
        Lada.SetCost(300000);
        Lada.name = "LadaKalina Sport";

       // Debug.Log("Todays Cost - " + Lada.GetCost());
        Lada.ChangeOwner(petia);
        Lada.ChangeOwner(vova);
        Lada.ShowOwners();
        Lada.ChangeOwner(vasya);
        Lada.ShowOwners();
       // Debug.Log("Todays Cost - " + Lada.GetCost()); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Human
{
    //Свойства
    private int age;
    private float height;
    private float weight;
    public string name;

    //Методы
    public void Say(string text)
    {
        Debug.Log(text);
    }


    public void HappyBirthday()
    {
        age++;
    }

    public int GetAge()
    {
        return age;
    }
}

public class Car
{
    private Human owner;
    private List<Human> previousOwners = new List<Human>();

    public string name;
    private float cost;

    
    public void SetCost(float changes)
    {
        cost = changes;
    }

    public void ChangeOwner(Human newOwner)
    {
        if(owner == null)
        {
            owner = newOwner;
            SetCost(cost * 0.8f);
        }
        else
        {
            previousOwners.Add(owner);
            owner = newOwner;
            SetCost(cost * 0.8f);
        }
    }

    public void ShowOwners()
    {
        foreach (var owner in previousOwners)
        {
            //Debug.Log("Previous owner - " + owner.name);
        }
        //Debug.Log("Current Owner - " + owner.name);
    }

    public float GetCost()
    {
        return cost;
    }
}
