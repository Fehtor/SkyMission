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


        Category goods = new Category();
        goods.name = "Milk's";
        goods.goods[0] = good;

        Basket basket = new Basket();
        basket.buyedGoods[0] = good1;

        User newUser = new User();
        //newUser.yourBasket = basket.buyedGoods[0];
        newUser.setLogin("qwerty");
        newUser.SetPessword(1234567);


        Debug.Log(newUser.GetPassword());
        Debug.Log(newUser.GetLogin());

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
    public List<Good> buyedGoods    = new List<Good>();

    public void GoodAdd()
    {

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
