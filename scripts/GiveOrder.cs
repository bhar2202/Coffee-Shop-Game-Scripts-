using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class GiveOrder : MonoBehaviour
{

    public string[] ingredients = new string[] { "Milk", "Almond Milk", "Ice", "Light Coffee", "Dark Coffee", "Chocolate", "Caramel", "Whipped Cream" };
    public Dictionary<string, string[]> orders = new Dictionary<string, string[]>();
    public string[] currCoffee;
    public string[] currOrder;
    public string currOrderName;
    public bool isfull;
    public Text orderText;
    public Text moneyText;
    public Text gameOverMoneyText;
    public int money;
    public int coffeeState;
    public GameObject c0;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;


    // Start is called before the first frame update
    void Start()
    {
        currOrder = new string[4];
        currCoffee = new string[4];

        orders.Add("Mocha", new string[] { ingredients[0],ingredients[5],ingredients[3],ingredients[3] });
        orders.Add("Iced Coffee", new string[] { ingredients[0], ingredients[2], ingredients[4], ingredients[7] });
        orders.Add("Hot Chocolate", new string[] { ingredients[0], ingredients[0], ingredients[5], ingredients[5] });
        orders.Add("Carmel Latte", new string[] { ingredients[1], ingredients[6], ingredients[4], ingredients[4] });
        orders.Add("Expresso", new string[] { ingredients[4], ingredients[4], ingredients[4], ingredients[7] });
        orders.Add("Almond Coffee", new string[] { ingredients[1], ingredients[1], ingredients[3], ingredients[3] });
        currOrderName = "";
        isfull = false;
        money = 0;
        coffeeState = 0;
        pickNewOrder();
    }

    public void addIngredient(string ing)
    {
        for(int i = 0;i < currCoffee.Length; i++)
        {
            
            if (currCoffee[i] == null)
            {
                currCoffee[i] = ing;
                
                if (i == currCoffee.Length - 1)
                {
                    
                    isfull = true;
                    
                }
                break;
            }
        }
       

        coffeeState++;
        if(coffeeState == 4)
        {
            isfull = true;
        }
       
    }

    public string giveOrder()
    {
        string sent = "";
        foreach(string s in currOrder)
        {
            sent += s + ", ";
        }
        sent = sent.Remove(sent.Length - 2, 1);
        return sent;
    }
    

    public void pickNewOrder()
    {
        List<string> keyList = new List<string>(orders.Keys);
        List<string[]> valuesList = new List<string[]>(orders.Values);

        int rand = (int)UnityEngine.Random.Range(0, keyList.Count);

        currOrder = valuesList[rand];

        currOrderName = keyList[rand];

        ;

        orderText.text = currOrderName + ": \n" + giveOrder();


    }

    public void resetCoffee()
    {
        coffeeState = 0;
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(false);
        c4.SetActive(false);

        currCoffee = new string[4];

    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (isfull)
        {
            //int matchCount = 0;
            //compare currcoffe to current order

            string[] currOrderCopy = new string[4];
            currOrderCopy = currOrder;

            Array.Sort(currCoffee);
            Array.Sort(currOrder);

            //give money if both arrays match
            if (currOrder.SequenceEqual(currCoffee))
            {
                money += 4;
                moneyText.text = "$" + money;
                gameOverMoneyText.text = "Money made: " + moneyText.text;
            } 

            isfull = false;

            resetCoffee();

            pickNewOrder();
        }

        //update coffee Image
        switch (coffeeState)
        {
            case 1: 
                c1.SetActive(true);
                break;
            case 2:
                c2.SetActive(true);
                break;
            case 3:
                c3.SetActive(true);
                break;
            case 4:
                c4.SetActive(true);
                break;
            default:
                break;
        }
    }

}
