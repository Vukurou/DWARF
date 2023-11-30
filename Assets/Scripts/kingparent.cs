using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class KingParent : MonoBehaviour
{   
    private Vector3 spawnPoint;
    public GameObject dwarfKing;

    // Start is called before the first frame update
    private void Awake()
    {
        spawnPoint = transform.position;
        if (dwarfKing != null)
        {
            dwarfKing.SetActive(false); // Set the DwarfKing to inactive
        }
    }
    //Update is called once per frame
    void Update()
    {
        bool onlyPlatforms = GameObject.FindGameObjectsWithTag("Spike").Length == 0;

        if (onlyPlatforms && dwarfKing != null && !dwarfKing.activeSelf)
        {
            dwarfKing.SetActive(true); // Reactivate DwarfKing when only platforms are present
        }

        // HACK JULIAN 
        if (onlyPlatforms)
        {
            GameObject[] zwergObjects = GameObject.FindGameObjectsWithTag("Zwerg");
            foreach (GameObject zwerg in zwergObjects)
            {
                Destroy(zwerg);
            }
    }
}
}