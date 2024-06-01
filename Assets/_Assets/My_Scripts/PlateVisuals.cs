using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlateVisuals : MonoBehaviour
{
    
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform visualPrefab;
    [SerializeField] private PlatesCounter platesCounter;

    void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
    }
   
   private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform visual = Instantiate(visualPrefab, counterTopPoint );
        
    }
   
}
