using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed = 1f;
    private Transform player;
    private bool shouldMove = true;
    public GameObject letterPrefab;

    //testing
    private LetterDropper letterDropper;
    private LetterDisplay letterDisplay;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //testing
        letterDropper = GetComponent<LetterDropper>();
        letterDisplay = GetComponent<LetterDisplay>();

    }

    // Update is called once per frame
    void Update()
    {
        if(shouldMove && player != null)
        {
            //subtrating player position with enemy
            Vector3 direction = player.position - transform.position;

            //only need direction, not distance
            direction.Normalize();

            //move enemy toward player
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enemy touched the player!");
            shouldMove = false;

            //testing
            char letterToDrop = letterDropper.ChooseLetter();
            Debug.Log(letterToDrop);
            Vector3 currPos = transform.position;
            gameObject.SetActive(false);

            if (letterToDrop != ' ')
            {
                letterDisplay.SpawnLetter(letterToDrop, currPos);
            }
            
            Destroy(gameObject);


        }
        else
        {
            Debug.Log("boo");
        }
    }
}
