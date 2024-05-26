using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IkithchenObjectParent
{
    // Start is called before the first frame update

     [SerializeField] Transform objectHoldPoint;
    private KitchenObject kitchenObject;

   
    public virtual void Interact(NewPlayer newPlayer)
    {
        
    }

    public virtual void InteractAlter(NewPlayer newPlayer){
        
    }
public Transform GetKitchenObjectTransform(){
    return objectHoldPoint;
    }

     public void SetKitechenObject(KitchenObject kitchenObject){
         this.kitchenObject = kitchenObject;
     }

     public KitchenObject GetKitchenObject(){
         return kitchenObject;
     }

     public void ClearKitchenObject(){
         kitchenObject = null;
     }

     public bool  HasKitchenObject(){
         return kitchenObject != null;
     }





}
