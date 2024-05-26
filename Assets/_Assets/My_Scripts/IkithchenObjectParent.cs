using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IkithchenObjectParent {



     
     public Transform GetKitchenObjectTransform();
     public void SetKitechenObject(KitchenObject kitchenObject);
     

     public KitchenObject GetKitchenObject();
        
     public void ClearKitchenObject();
         

     public bool  HasKitchenObject();



}
 
 
 
 
 
 
 
    // Start is called before the first frame update
