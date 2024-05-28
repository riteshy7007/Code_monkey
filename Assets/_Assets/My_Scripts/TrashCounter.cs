using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter :BaseCounter

{
    public override void Interact(NewPlayer newPlayer)
    {
       
        if (newPlayer.HasKitchenObject())
        {
           newPlayer.GetKitchenObject().OnDestroy();
           
        }
    }
}
