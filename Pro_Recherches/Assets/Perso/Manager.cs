using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject vfxPrefab;

    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits something
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the hit object is the ground
                if (hit.collider.tag == "Ground")
                {
                    // Spawn VFX at the hit point
                    Instantiate(vfxPrefab, hit.point, Quaternion.identity);
                }
            }
        }
    }
}
