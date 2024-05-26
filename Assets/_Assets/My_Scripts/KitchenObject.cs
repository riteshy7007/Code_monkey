using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{

private IkithchenObjectParent kitchenObjectParent;
   [SerializeField] KitchenObjectSO kitchenObjectSO;
      
      // this function is for the fethcing prefab from scriptable object
      public KitchenObjectSO GetKitchenObjectSO(){
           
            return kitchenObjectSO;
      }
      // below code is regarding the setter and getter of the kitchen object parent wh
   public void SetKitchenObjectParent(IkithchenObjectParent kitchenObjectParent){
       if(this.kitchenObjectParent != null){
           this.kitchenObjectParent.ClearKitchenObject(); // need to verfiy it should get missed
       }
       
       
       
       this.kitchenObjectParent = kitchenObjectParent;
       if(kitchenObjectParent.HasKitchenObject()){
           Debug.LogError("KitchenObjectParent already has a kitchen object");
       }
       kitchenObjectParent.SetKitechenObject(this);


       transform.parent=kitchenObjectParent.GetKitchenObjectTransform();
       transform.localPosition = Vector3.zero;
   }
   public IkithchenObjectParent GetIkithchenObjectParent(){
       return kitchenObjectParent;
   }

     public void OnDestroy()
     {
        
            kitchenObjectParent.ClearKitchenObject();
            Destroy(gameObject);
           
        
     }
       
       public static KitchenObject SpwanKitchenObject(KitchenObjectSO kitchenObjectSO, IkithchenObjectParent kitchenObjectParent){
           Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.counterObject);
           KitchenObject kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
           
           kitchenObject.SetKitchenObjectParent(kitchenObjectParent);
           return kitchenObject;
       }


}


