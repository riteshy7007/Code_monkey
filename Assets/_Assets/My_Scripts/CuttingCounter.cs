using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CuttingCounter : BaseCounter, IkithchenObjectParent
{
     public event EventHandler OnCutObject;
     public event EventHandler<CuttingProgressChangeEventArgs> OnCuttingProgressChange;
     public class CuttingProgressChangeEventArgs : EventArgs{
         public float progressNormalized;
     }


    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
  
    
  



     int cuttingProgress;

     public override void Interact(NewPlayer newPlayer){
        if (!HasKitchenObject())
        {
          if(newPlayer.HasKitchenObject()){
            if(HasReceipeWitgInput(newPlayer.GetKitchenObject().GetKitchenObjectSO())){
                //player has kitchen object
                newPlayer.GetKitchenObject().SetKitchenObjectParent(this);
               
            
             CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
              cuttingProgress = 0;
              OnCuttingProgressChange?.Invoke(this, new CuttingProgressChangeEventArgs{
                progressNormalized = (float)cuttingProgress/cuttingRecipeSO.cuttingTime});
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

    private bool HasReceipeWitgInput(KitchenObjectSO input){
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(input);
        
        return cuttingRecipeSO != null;
    }



     public override void InteractAlter(NewPlayer newPlayer){
         if(HasKitchenObject()&& HasReceipeWitgInput(GetKitchenObject().GetKitchenObjectSO())){
               cuttingProgress++;
                OnCutObject?.Invoke(this, EventArgs.Empty);
               CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                
                OnCuttingProgressChange?.Invoke(this, new CuttingProgressChangeEventArgs{
                progressNormalized = (float)cuttingProgress/cuttingRecipeSO.cuttingTime
                });

              if(cuttingProgress >= cuttingRecipeSO.cuttingTime)
              {KitchenObjectSO outputKithcenObjectSO = GetOutputforInput(GetKitchenObject().GetKitchenObjectSO()); 
                
                GetKitchenObject().OnDestroy();
               KitchenObject.SpwanKitchenObject(outputKithcenObjectSO, this);
               

                } 

                 
            }
     }

     private KitchenObjectSO GetOutputforInput(KitchenObjectSO input){
        CuttingRecipeSO cuttingRecipeSO = GetCuttingRecipeSOWithInput(input);

        if(cuttingRecipeSO !=null){
            return cuttingRecipeSO.output;
        }else{
            return null;
        }
     }
        private CuttingRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO input){
            foreach(CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray){
                if(cuttingRecipeSO.input == input){
                    return cuttingRecipeSO;
                }
            }
            return null;
        }

        
   

    
}
