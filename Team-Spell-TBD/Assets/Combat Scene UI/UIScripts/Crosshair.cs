using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject mouseCursor;
    public Sprite crosshair;
    public Sprite clicker;
    public Sprite clickerSelected;

    // Start is called before the first frame update
    void Start()
    {
        mouseCursor.SetActive(true);
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition; // Get the mouse position in screen coordinates
        mousePosition.z = 10.0f; // Set this to be the distance from the camera to the object

        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); // Convert to world coordinates

        mouseCursor.transform.position = worldPosition; // Update the position of the GameObject this script is attached to
    }
}
