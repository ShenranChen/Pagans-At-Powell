using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour

{
    //upgrade
    public Button rocketUpgradeButton;
    public Button baUpgradeButton;

    //abilities button
    public Button rocketButton;
    public Button healButton;


    //function to call
    public BA_player basicAttackAbility;
    public Rocket_player rocketAbility;
    public PlayerHealthManager healAbility;


    private bool firstRocket = true;
    private bool firstHeal = true;

    //others
    public LettersSO lettersInventory;
    public UnlockedAbilitiesSO unlockManager;


    void Start()
    {
        unlockManager.heal = false;
    }

    // Update is called once per frame
    void Update()
    {
        CheckUpgradeAvailability();

    }

    void CheckUpgradeAvailability()
    {
        if (lettersInventory.R > 0 && lettersInventory.O > 0 && lettersInventory.C > 0 &&
            lettersInventory.K > 0 && lettersInventory.E > 0 && lettersInventory.T > 0)
        {
            rocketUpgradeButton.interactable = true;
        }
        else
        {
            rocketUpgradeButton.interactable = false;
        }

        if (lettersInventory.S > 1 && lettersInventory.L > 0 &&
            lettersInventory.A > 0 && lettersInventory.H > 0)
        {
            baUpgradeButton.interactable = true;
        }
        else
        {
            baUpgradeButton.interactable = false;
        }

        if(lettersInventory.H > 0 && lettersInventory.E > 0 && lettersInventory.A > 0 &&
            lettersInventory.L > 0)
        {
            healButton.interactable = true;
        }
        else
        {
            healButton.interactable = false;
        }
    }

    public void OnRocketUpgradeButtonClicked()
    {
        if (firstRocket)
        {
            firstRocket = false;
            unlockManager.rocket = true;
            rocketButton.interactable = true;
        }

        lettersInventory.R--;
        lettersInventory.O--;
        lettersInventory.C--;
        lettersInventory.K--;
        lettersInventory.E--;
        lettersInventory.T--;

        rocketAbility.UpgradeRocket();
    }

    public void OnBasicUpgradeButtonClicked()
    {
        lettersInventory.S -= 2;
        lettersInventory.L--;
        lettersInventory.A--;
        lettersInventory.H--;

        basicAttackAbility.UpgradeBasicAttack();
    }

    public void OnHealButtonClicked()
    {
        if (firstHeal)
        {
            firstHeal = false;
            unlockManager.heal = true;
        }

        lettersInventory.H--;
        lettersInventory.E--;
        lettersInventory.A--;
        lettersInventory.L--;

        healAbility.HealAbility();
    }
}
