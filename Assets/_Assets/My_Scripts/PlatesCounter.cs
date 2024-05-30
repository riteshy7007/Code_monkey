using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter :BaseCounter
{

    [SerializeField]private KitchenObjectSO plateKitchenObject;
    private float plateSpawnTime;
    private float plateSpawnMaxTime =4f;
    private int plateCount;
     private int plateMaxCount = 5;

    void Update()
    {
        plateSpawnTime+= Time.deltaTime;
        if(plateSpawnTime> plateSpawnMaxTime){
            plateSpawnTime = 0;
            if(plateCount< plateMaxCount){
                KitchenObject.SpwanKitchenObject(plateKitchenObject, this);
                plateCount++;
            }
        }
    }

    
   
}
