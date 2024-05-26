using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, IkithchenObjectParent
{
    //[SerializeField] CuttingRecipeSO[] cuttingRecipeSOArray;
    [SerializeField] KitchenObjectSO cuttingOjectSO;
  
    
  





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

   
public override void InteractAlter(NewPlayer newPlayer){
    if (!HasKitchenObject())
    {
      GetKitchenObject().OnDestroy();  
      Transform KitchenObjectTransfrom =Instantiate(cuttingOjectSO.counterObject);   
      KitchenObject kitchenObject = KitchenObjectTransfrom.GetComponent<KitchenObject>();  
      
      
      
      }

  
}
    
}
