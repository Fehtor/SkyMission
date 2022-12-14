using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HmWrk : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Good good = new Good();        
        good.name = "Cheese";
        

        Good good1 = new Good();        
        good1.name = "Bread";
        
        good1.cost = 60;


        Category goods = new Category();
        goods.name = "Milk's";
        goods.AddNewGood(good);

        Basket basket = new Basket();

        User newUser = new User();
        newUser.yourBasket = basket;
        newUser.yourBasket.GoodAdd(good1);
        newUser.setLogin("qwerty");
        newUser.SetPessword(1234567);

        newUser.yourBasket.GetAllGoods();
        Debug.Log(newUser.yourBasket.SummAlCost());
        newUser.yourBasket.RemoveGood(good1);
        newUser.yourBasket.GetAllGoods();

       // Debug.Log(newUser.GetPassword());
      //  Debug.Log(newUser.GetLogin());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Good
{
    public string name;
    public float cost;
  
    private float rating;
    public int ID;

    public float GetRating()
    {
        return rating;
    }
}

public class Category
{
    public string name;
    public List<Good> goods = new List<Good>();

    public void AddNewGood(Good good)
    {
        goods.Add(good);
        
    }

    public void RemoveGood(Good good)
    {
        foreach (var product  in goods)
        {
            if(product.ID == good.ID)
            {
                goods.Remove(product);
                return;
            }
            
        }
    }
}

public class Basket
{
    private List<Good> choosenGoods    = new List<Good>();
    public Dictionary<float, Good> dict = new Dictionary<float, Good>();

    private float summedCost;
    public void GoodAdd(Good good)
    {
        choosenGoods.Add(good);
        dict[1] = good;
    }

    public void RemoveGood(Good good)
    {
        foreach (var product in dict)
        {
            if (product.Value == good)
            {
                if(product.Key == 1)
                {
                    choosenGoods.Remove(product.Value);
                    dict.Remove(product.Key);
                    return;
                }
                else
                {
                    dict[product.Key - 1] = good;
                    dict.Remove(product.Key);
                }
               
            }

        }
    }

    public float CostOfGood(Good good)
    {
        foreach (var product in dict)
        {
            if(good == product.Value)
            {
                 return good.cost * product.Key;
            }
        }
        return 0;
    }

    public float SummAlCost()
    {
        summedCost = 0;
        foreach (var product in dict)
        {
            summedCost += product.Key * product.Value.cost;
        }
        return summedCost;
    }

    public void GetAllGoods()
    {
        foreach (var product in dict)
        {
            Debug.Log(product.Value.name);
        }
    }
}

public class User
{
    public Basket yourBasket; 
    private string login;
    private int password;

    public void setLogin(string newLogin)
    {
        login = newLogin;
    }
    public void SetPessword(int newPassword)
    {
        password = newPassword;
    }

    public string GetLogin()
    {
        return login;
    }

    public int GetPassword()
    {
        return password;
    }
}
