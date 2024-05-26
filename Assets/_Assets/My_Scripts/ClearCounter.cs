using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Rendering;
using UnityEngine;


public class ClearCounter : BaseCounter
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    
  





     public override void Interact(NewPlayer newPlayer){
        if (!HasKitchenObject())
        {
          if(newPlayer.HasKitchenObject()){
            //player has kitchen object
              newPlayer.GetKitchenObject().SetKitchenObjectParent(this);
          }else{
              Debug.LogError("No kitchen object to transfer");
          }
            
          
        }else{
            if(newPlayer.HasKitchenObject()){
                //player has kitchen object
            }else{
                //player has no kitchen object
                GetKitchenObject().SetKitchenObjectParent(newPlayer);
            }
         
      
    
     }



     }

}
