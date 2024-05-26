using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter, IkithchenObjectParent
{
    //[SerializeField] CuttingRecipeSO[] cuttingRecipeSOArray;
    [SerializeField] KitchenObjectSO[] kitchenObjectSOArray;
  
    
  





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
         if(HasKitchenObject()){
                KitchenObjectSO outputKitchenObjectSO = GetOutPutForInput(GetKitchenObject().GetKitchenObjectSO());
                GetKitchenObject().OnDestroy();
                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO,this);

                 
            }
     }
   

    private KitchenObjectSO GetOutPutForInput(KitchenObjectSO inputKitchenObjectSO){
        foreach(CuttingRecipeSO cuttingRecipeSO in cutkitcheObjectSOArray){
            if(cuttingRecipeSO.input == inputKitchenObjectSO){
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }
}
//code is not completed yet