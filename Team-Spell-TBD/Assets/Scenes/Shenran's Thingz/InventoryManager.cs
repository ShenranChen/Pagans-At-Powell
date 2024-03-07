using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public GameObject inventoryPanel;

    private bool isInventoryVisible = false;

    public void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible; 
        inventoryPanel.SetActive(isInventoryVisible); 

        if (isInventoryVisible)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
