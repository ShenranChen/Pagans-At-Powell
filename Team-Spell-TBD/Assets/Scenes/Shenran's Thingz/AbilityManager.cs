using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour

{
    public Button rocketButton;
    public Button baButton;
    public LettersSO lettersInventory;
    public BA_player basicAttackAbility;
    public Rocket_player rocketAbility;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckAbilitiesAvailability();
    }

    void CheckAbilitiesAvailability()
    {
        if (lettersInventory.R > 0 && lettersInventory.O > 0 && lettersInventory.C > 0 &&
            lettersInventory.K > 0 && lettersInventory.E > 0 && lettersInventory.T > 0)
        {
            rocketButton.interactable = true;
        }
        else
        {
            rocketButton.interactable = false;
        }

        if (lettersInventory.S > 1 && lettersInventory.L > 0 &&
            lettersInventory.A > 0 && lettersInventory.H > 0)
        {
            baButton.interactable = true;
        }
        else
        {
            baButton.interactable = false;
        }
    }

    public void OnRocketButtonClicked()
    {
        lettersInventory.R--;
        lettersInventory.O--;
        lettersInventory.C--;
        lettersInventory.K--;
        lettersInventory.E--;
        lettersInventory.T--;

        rocketAbility.UpgradeRocket();
    }

    public void OnHealButtonClicked()
    {
        lettersInventory.S -= 2;
        lettersInventory.L--;
        lettersInventory.A--;
        lettersInventory.H--;

        basicAttackAbility.UpgradeBasicAttack();
    }
}
