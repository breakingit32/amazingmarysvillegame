using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using UnityEngine.EventSystems;
public class Month2 : MonoBehaviour
{

    public static float rent;
    public static float food;
    public static float utilites;
    public static float carInsurance;
    public static float gas;
    public static float internet;
    public static bool rentPaid = false;
    public static bool foodPaid = false;
    public static bool utilitesPaid = false;
    public static bool carInsurancePaid = false;
    public static bool gaspaid = false;
    public static bool internetPaid = false;
    public static bool rentPaidButton = true;
    public static bool foodPaidButton = true;
    public static bool utilitesPaidButton = true;
    public static bool carInsurancePaidButton = true;
    public static bool gaspaidButton = true;
    public static bool internetPaidButton = true;
    public Manager manager;
    public Button Rent;
    public Button Finish;
    public Button Gas;
    public Button Utilites;
    public Button CarInsurance;
    public Button Food;
    public Button Internet;
    public Button NextPlayer;
    public Text Warning;
    public static Month2 M;
    public CalCol month2;
    public float checkBal;
    public float billss;
    public bool buttonPressed;
    public string[] AllSitucation;
    public List<string> Situation = new List<string>();
    public GameObject ResultPanel;
    public GameObject MainPanel;
    public GameObject Finish2;
    public float monthTracker;

    // Start is called before the first frame update
    public void Start()
    {

        manager.playerTracker = 0;
        month2.UpdateVar(rent, food, utilites, carInsurance, gas, internet);
        Debug.Log(manager.playerTracker);
        rent = 1500;
        food = 100;
        utilites = 50;
        carInsurance = 130;
        gas = 150;
        internet = 700;
        monthTracker = 1f;
    }


    public void ListenForButton()
    {
        Text rent = Rent.GetComponentInChildren<Text>();
        rent.text = "Rent: $" + manager.players[manager.playerTracker].monthlyPills.rent.ToString();
        Text food = Food.GetComponentInChildren<Text>();
        food.text = "Food: $" + manager.players[manager.playerTracker].monthlyPills.food.ToString();
        Text gas = Gas.GetComponentInChildren<Text>();
        gas.text = "Gas: $" + manager.players[manager.playerTracker].monthlyPills.gas.ToString();
        Text utilites = Utilites.GetComponentInChildren<Text>();
        utilites.text = "Utilites: $" + manager.players[manager.playerTracker].monthlyPills.utilites.ToString();
        Text carInsurance = CarInsurance.GetComponentInChildren<Text>();
        carInsurance.text = "Car Insurance: $" + manager.players[manager.playerTracker].monthlyPills.carInsurance.ToString();
        Text internet = Internet.GetComponentInChildren<Text>();
        internet.text = "Internet: $" + manager.players[manager.playerTracker].monthlyPills.internet.ToString();
        
    }




    public void PaidInternet()
    {
        Warning.text = "";
        //manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - internet;

        if (internetPaidButton == true)
        {
            checkBal = month2.CheckBal(manager.players[manager.playerTracker], internet);

            if (checkBal == 0)
            {
                internetPaidButton = false;
                manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - manager.players[manager.playerTracker].monthlyPills.internet;
                manager.players[manager.playerTracker].monthlyPills.internet = 0f;
                manager.players[manager.playerTracker].monthlyPills.total = manager.players[manager.playerTracker].monthlyPills.totalCal();
                manager.players[manager.playerTracker].Bills = manager.players[manager.playerTracker].monthlyPills.total;
                month2.internetPaid = true;
                Text text = Internet.GetComponentInChildren<Text>();
                text.text = "paid";
                Internet.enabled = false;
            }
            else if (checkBal == 1)
            {

                StartCoroutine(Timer());
            }
        }




    }

    public void PaidCarInsurance()
    {
        Warning.text = "";
        //manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - carInsurance;

        if (carInsurancePaidButton == true)
        {

            checkBal = month2.CheckBal(manager.players[manager.playerTracker], carInsurance);
            if (checkBal == 0)
            {
                carInsurancePaidButton = false;
                manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - manager.players[manager.playerTracker].monthlyPills.carInsurance;
                manager.players[manager.playerTracker].monthlyPills.carInsurance = 0f;
                manager.players[manager.playerTracker].monthlyPills.total = manager.players[manager.playerTracker].monthlyPills.totalCal();
                manager.players[manager.playerTracker].Bills = manager.players[manager.playerTracker].monthlyPills.total;
                month2.carInsurancePaid = true;
                Text text = CarInsurance.GetComponentInChildren<Text>();
                text.text = "paid";
                CarInsurance.enabled = false;

            }
            else if (checkBal == 1)
            {

                StartCoroutine(Timer());
            }
        }




    }

    public void PaidUtilities()
    {
        Warning.text = "";
        if (utilitesPaidButton == true)
        {

            checkBal = month2.CheckBal(manager.players[manager.playerTracker], utilites);
            if (checkBal == 0)
            {
                utilitesPaidButton = false;
                manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - manager.players[manager.playerTracker].monthlyPills.utilites;
                manager.players[manager.playerTracker].monthlyPills.utilites = 0f;
                manager.players[manager.playerTracker].monthlyPills.total = manager.players[manager.playerTracker].monthlyPills.totalCal();
                manager.players[manager.playerTracker].Bills = manager.players[manager.playerTracker].monthlyPills.total;
                month2.utilitesPaid = true;
                Text text = Utilites.GetComponentInChildren<Text>();
                text.text = "paid";
                Utilites.enabled = false;
            }
            else if (checkBal == 1)
            {

                StartCoroutine(Timer());
            }
        }




    }

    public void PaidFood()
    {
        Warning.text = "";
        if (foodPaidButton == true)
        {

            checkBal = month2.CheckBal(manager.players[manager.playerTracker], food);
            //manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - food;
            if (checkBal == 0)
            {
                foodPaidButton = false;
                manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - manager.players[manager.playerTracker].monthlyPills.food;
                manager.players[manager.playerTracker].monthlyPills.food = 0f;
                manager.players[manager.playerTracker].monthlyPills.total = manager.players[manager.playerTracker].monthlyPills.totalCal();
                manager.players[manager.playerTracker].Bills = manager.players[manager.playerTracker].monthlyPills.total;
                month2.foodPaid = true;
                Text text = Food.GetComponentInChildren<Text>();
                text.text = "paid";
                Food.enabled = false;
            }
            else if (checkBal == 1)
            {

                StartCoroutine(Timer());
            }
        }


    }


    public void PaidGas()
    {

        if (gaspaidButton == true)
        {
            Warning.text = "";

            checkBal = month2.CheckBal(manager.players[manager.playerTracker], gas);
            Debug.Log(checkBal + "If 0 you have money");
            if (checkBal == 0)
            {
                gaspaidButton = false;
                manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - manager.players[manager.playerTracker].monthlyPills.gas;
                manager.players[manager.playerTracker].monthlyPills.gas = 0f;
                manager.players[manager.playerTracker].monthlyPills.total = manager.players[manager.playerTracker].monthlyPills.totalCal();
                manager.players[manager.playerTracker].Bills = manager.players[manager.playerTracker].monthlyPills.total;
                month2.gaspaid = true;
                Text text = Gas.GetComponentInChildren<Text>();
                text.text = "paid";
                Gas.enabled = false;
            }
            else if (checkBal == 1)
            {

                StartCoroutine(Timer());
            }
        }



        //else if(month2.gaspaid == true)
        //{
        //    
        //    Warning.text = "";
        //    return;
        //}



    }
    public void PaidRent()
    {
        Debug.Log(rent);
        Warning.text = "";
        if (rentPaidButton == true)
        {

            checkBal = month2.CheckBal(manager.players[manager.playerTracker], rent);
            //manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck - rent;
            if (checkBal == 0)
            {
                rentPaidButton = false;
                manager.players[manager.playerTracker].monthlyPills.rentPaid = true;
                manager.players[manager.playerTracker].monthlyPills.rent = 0f;
                manager.players[manager.playerTracker].monthlyPills.total = manager.players[manager.playerTracker].monthlyPills.totalCal();
                manager.players[manager.playerTracker].Bills = manager.players[manager.playerTracker].monthlyPills.total;

                Text text = Rent.GetComponentInChildren<Text>();
                text.text = "paid";
                Rent.enabled = false;
            }
            else if (checkBal == 1)
            {

                StartCoroutine(Timer());
            }
        }

        //else if (month2.rentPaid == true)
        //{
        //    manager.players[manager.playerTracker].PayCheck = manager.players[manager.playerTracker].PayCheck + rent;
        //    Warning.text = "";
        //    return;
        //}

    }

    public void BillManager()
    {
        
    }
        // Update is called once per frame
        void Update()
    {
        
    }

    public void Done()
    {
        Situation.Clear();
        buttonPressed = true;
        if (month2.carInsurancePaid == false)
        {
            string outcomes = "Not legally allowed to drive. May risk car being impounded if pulled overed";
            Situation.Add(outcomes);
            Debug.Log(outcomes);
        }

        if (month2.internetPaid == false)
        {
            string outcomes = "You lose internet access for a month. You get very bored"; //Place Holder
            Situation.Add(outcomes);
            Debug.Log(outcomes);
        }

        if (month2.utilitesPaid == false)
        {
            string outcomes = "Your power, gas, and water are shut off. Resulting in higher food costs due to increase take outs."; //Place Holder
            Situation.Add(outcomes);
            Debug.Log(outcomes);
        }

        if (month2.foodPaid == false)
        {
            string outcomes = "You have nothing to eat and must rely on hand outs and the Food Bank. You feel embarrassed."; //Place Holder
            Situation.Add(outcomes);
            Debug.Log(outcomes);
        }

        if (month2.gaspaid == false)
        {
            string outcomes = "Your unable to drive your car for the month. You lose 1/2 your hours due to lack of transportation."; //Place Holder
            Situation.Add(outcomes);
            Debug.Log(outcomes);
        }

        if (month2.rentPaid == false)
        {
            string outcomes = "You get a eviction letter from your landlord telling you to pay by next month or get out. You are extremely stressed out."; //Place Holder
            Situation.Add(outcomes);
            Debug.Log(outcomes);
        }

        Button nextPlayer = NextPlayer.GetComponent<Button>();
        MainPanel.SetActive(false);
        ResultPanel.SetActive(true);
        manager.playerTracker = manager.playerTracker + 1;
        if (manager.playerTracker > 4)
        {
            manager.playerTracker = 0;
            monthTracker++;
            if(monthTracker == 1)
            if(monthTracker < 7)
            {
                MainPanel.SetActive(false);
                ResultPanel.SetActive(false);
                Finish2.SetActive(true);
            }
        }
        //month2.Cal();SSS
        reset();
        //SceneManager.LoadScene(manager.scenes[manager.playerTracker]);
        
        Debug.Log(manager.playerTracker);
    }

    
        
        
    
    public void reset()
    {
        
        Situation.Clear();
        MainPanel.SetActive(true);
        ResultPanel.SetActive(false);
        bool rentP = month2.rentPaid == true ? false : false;
        bool gasP = month2.gaspaid == true ? false : false;
        bool internetP = month2.internetPaid == true ? false : false;
        bool foodP = month2.foodPaid == true ? false : false;
        bool utilitesP = month2.utilitesPaid == true ? false : false;
        bool carInsuranceP = month2.carInsurancePaid == true ? false : false;

        rentPaidButton = true;
        utilitesPaidButton = true;
        gaspaidButton = true;
        internetPaidButton = true;
        foodPaidButton = true;
        carInsurancePaidButton = true;
        Text rent = Rent.GetComponentInChildren<Text>();
        rent.text = "Rent: $" + manager.players[manager.playerTracker].monthlyPills.rent.ToString();
        Text food = Food.GetComponentInChildren<Text>();
        food.text = "Food: $" + manager.players[manager.playerTracker].monthlyPills.food.ToString();
        Text gas = Gas.GetComponentInChildren<Text>();
        gas.text = "Gas: $" + manager.players[manager.playerTracker].monthlyPills.gas.ToString();
        Text utilites = Utilites.GetComponentInChildren<Text>();
        utilites.text = "Utilites: $" + manager.players[manager.playerTracker].monthlyPills.utilites.ToString();
        Text carInsurance = CarInsurance.GetComponentInChildren<Text>();
        carInsurance.text = "Car Insurance: $" + manager.players[manager.playerTracker].monthlyPills.carInsurance.ToString();
        Text internet = Internet.GetComponentInChildren<Text>();
        internet.text = "Internet: $" + manager.players[manager.playerTracker].monthlyPills.internet.ToString();
        Rent.enabled = true;
        Utilites.enabled = true;
        Gas.enabled = true;
        Internet.enabled = true;
        CarInsurance.enabled = true;
        Food.enabled = true;
        buttonPressed = false;
        Text textR = Rent.GetComponentInChildren<Text>();
        if (rentP == false) textR.text = "Rent";
        Text textG = Gas.GetComponentInChildren<Text>();
        if (gasP == false) textG.text = "Gas";
        Text textI= Internet.GetComponentInChildren<Text>();
        if (internetP == false) textI.text = "Internet";
        Text textF = Food.GetComponentInChildren<Text>();
        if (foodP == false) textF.text = "Food";
        Text textU = Utilites.GetComponentInChildren<Text>();
        if (utilitesP== false) textU.text = "Utilites";
        Text textC = CarInsurance.GetComponentInChildren<Text>();
        if (carInsuranceP == false) textC.text = "Car Insurance";
        
        

    }

    public IEnumerator Timer()
    {
        Warning.text = "Incifienant Funds";
        yield return new WaitForSeconds(5);
        Warning.text = "";

        
    }
}
