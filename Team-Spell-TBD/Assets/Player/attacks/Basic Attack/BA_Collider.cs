using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BA_Collider : MonoBehaviour
{
    public PlayerStatsSO playerStats;

    private List<GameObject> hitList = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Enemy Collision Detected");

        GameObject hitObject = collider.gameObject;
        if (hitObject != null && !hitList.Contains(hitObject))
        {
            hitList.Add(hitObject);
            hitObject.GetComponent<EnemySetup>().TakeDamage(playerStats.base_ATK * playerStats.ba_MV);
        }
    }
}
