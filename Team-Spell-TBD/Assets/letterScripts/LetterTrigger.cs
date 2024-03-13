using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class LetterTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform letterTransform;

    void Start()
    {
        letterTransform = this.transform;
        letterTransform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {        
        if (other != null && other.CompareTag("Player"))
        {
            Debug.Log("Letter Collided");
            PlayerInv playerInventory = other.GetComponent<PlayerInv>();
            playerInventory.AddLetterToInventory(gameObject.name[0]);
            PlayerXP playerXP = other.GetComponent<PlayerXP>();
            playerXP.CollectedLetter();
            LetterUIUpdate letterUIUpdate = FindObjectOfType<LetterUIUpdate>();
            letterUIUpdate.RefreshUI();

            Destroy(gameObject);
        }
    }
}
