using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingCounter : BaseCounter
{
    private enum State{


        Idle,
        Frying,
        Fried,
        Burnt,

    }

    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;
    [SerializeField] private BurningRecipeSO[] burningRecipeSOArray;
     private FryingRecipeSO fryingRecipeSO;
     private BurningRecipeSO burningRecipeSO;
    
    private State state;
     

private float fryingTime;
private float burningTime;

void Start()
{
    state = State.Idle;
    
}
void Update(){
    if(HasKitchenObject()){
    switch(state){
        case State.Idle:
        //do nothing
            break;
        case State.Frying:
        fryingTime += Time.deltaTime;
         if(fryingTime> fryingRecipeSO.fryingmaxTime){
            GetKitchenObject().OnDestroy();
             KitchenObject.SpwanKitchenObject(fryingRecipeSO.output, this);

            BurningRecipeSO burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            state = State.Fried;
            burningTime = 0;
            }
            // Ensure burningRecipeSO is not null
            break;
        case State.Fried:
        
        burningTime += Time.deltaTime;
        
        if(burningTime> burningRecipeSO.burningmaxTime){
            
            GetKitchenObject().OnDestroy();
            KitchenObject.SpwanKitchenObject(burningRecipeSO.output, this);
            state = State.Burnt;
            Debug.Log("Burnt");
        }
            break;
        case State.Burnt:
            break;
        }
    Debug.Log(state);
    }   
}


    public override void Interact(NewPlayer newPlayer){
        if (!HasKitchenObject())
        {
          if(newPlayer.HasKitchenObject()){
            if(HasReceipeWitgInput(newPlayer.GetKitchenObject().GetKitchenObjectSO())){
                //player has kitchen object
                newPlayer.GetKitchenObject().SetKitchenObjectParent(this);
                fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                state = State.Frying;
                fryingTime = 0;
               
            
             
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
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(input);
        
        return fryingRecipeSO != null;
    }

private KitchenObjectSO GetOutputforInput(KitchenObjectSO input){
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(input);

        if(fryingRecipeSO !=null){
            return fryingRecipeSO.output;
        }else{
            return null;
        }
     }
        private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO input){
            foreach(FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray){
                if(fryingRecipeSO.input == input){
                    return fryingRecipeSO;
                }
            }
            return null;
        }

         private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO input){
            foreach(BurningRecipeSO burningRecipeSO in burningRecipeSOArray){
                if(burningRecipeSO.input == input){
                    return burningRecipeSO;
                }
            }
            return null;
        }
 
 


}
