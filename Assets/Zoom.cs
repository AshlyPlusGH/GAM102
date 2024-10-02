using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll > 0f)
        {
            // Scroll up
            gameObject.GetComponent<Camera>().orthographicSize += 1;
        }
        else if (scroll < 0f)
        {
            // Scroll down
            if (gameObject.GetComponent<Camera>().orthographicSize > 0){
                gameObject.GetComponent<Camera>().orthographicSize -= 1;
            }
        }
    }
}
