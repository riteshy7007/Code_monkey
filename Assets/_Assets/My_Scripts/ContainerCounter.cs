using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter
{
    public EventHandler OnGrabingObject;
   


  

    


 [SerializeField] KitchenObjectSO kitchenObjectSO;

     public  override void Interact(NewPlayer newPlayer){
         
      
     if(!newPlayer.HasKitchenObject()) {

       Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.counterObject).transform;
         kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(newPlayer);
        
        OnGrabingObject?.Invoke(this, EventArgs.Empty);
         
         
     } 
     }



}
