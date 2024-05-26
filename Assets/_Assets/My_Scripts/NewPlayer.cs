using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor.Rendering;
using UnityEngine;

public class NewPlayer : MonoBehaviour, IkithchenObjectParent
{

     public static NewPlayer Instance { get; private set; }
    public event EventHandler<OnSlectedCounterChangedEventArgs>OnSlectedCounterChanged;
    public class OnSlectedCounterChangedEventArgs : EventArgs{
        public BaseCounter selectedClearCounter;
    }
    [SerializeField] private float speed = 5;
    [SerializeField] Transform kithchenObjectHoldPoint;
    [SerializeField] private KitchenObject kitchenObject;
    
     private bool isWalking;
     [SerializeField] private GameInput gameInput;
     [SerializeField] private LayerMask layerMask;

     private Vector3 lastinteractionPosition;
    private BaseCounter selectedClearCounter;
     void Start()
     {
        gameInput.Oninteraction += HandleInteraction;
        gameInput.OninteractionAlter += HandleInteractionAlter;
     }


     private void HandleInteraction(object sender, System.EventArgs e){
       if(selectedClearCounter != null){
           selectedClearCounter.Interact(this);
       }
     }

        private void HandleInteractionAlter(object sender, System.EventArgs e){
            if(selectedClearCounter != null){
                selectedClearCounter.InteractAlter(this);
            }
        }

     private void Awake(){
        if(Instance != null){
        Debug.LogError("There is more than one instanc e of NewPlayer in the scene");
        }

        Instance = this;
     }
   void Update(){
         HandleMovement();
         HandleInteraction();
    
   }
    public void HandleMovement(){
Vector2 inputVector = gameInput.GetMovementVectorNormalize();
Vector3 MoveDir = new Vector3(inputVector.x, 0, inputVector.y);

float moveDistance = speed * Time.deltaTime;
float height = 1.5f;
float radius = 0.3f;



bool CanMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * height, radius, MoveDir, moveDistance);


if (CanMove) {
    transform.position += MoveDir * moveDistance;
} else {
    Vector3 MoveDirX = new Vector3(MoveDir.x, 0, 0).normalized;
    CanMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * height, radius, MoveDirX, moveDistance);
    

    if (CanMove) {
        transform.position += MoveDirX * moveDistance;
    } else {
        Vector3 MoveDirZ = new Vector3(0, 0, MoveDir.z).normalized;
        CanMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * height, radius, MoveDirZ, moveDistance);
        

        if (CanMove) {
            transform.position += MoveDirZ * moveDistance;
        } else {
            MoveDir = Vector3.zero;
        }
    }
}

isWalking = MoveDir != Vector3.zero;
float rotationSpeed = 10;
transform.forward = Vector3.Slerp(transform.forward, MoveDir, Time.deltaTime * rotationSpeed);



    


    }
    
    public void HandleInteraction(){

        
        Vector2 inputVector = gameInput.GetMovementVectorNormalize();
         Vector3 MoveDir =  new Vector3(inputVector.x, 0, inputVector.y);
         if(MoveDir!= Vector3.zero){
             lastinteractionPosition = MoveDir;
         }
        float interactionDistance = 2f;
    if (Physics.Raycast(transform.position, lastinteractionPosition, out RaycastHit hit, interactionDistance))
    {
        if (hit.transform.TryGetComponent(out BaseCounter baseCounter))
        {
            if( baseCounter != selectedClearCounter){
                 SetSlectedCounter(baseCounter);
                                    
            }
        }else{
            SetSlectedCounter(null);    
        }
    }else{
        
       SetSlectedCounter(null);
        
        }
    
    }
     
     



     public bool IsWalking(){
         return isWalking;
     }

     private void SetSlectedCounter(BaseCounter selectedClearCounter){
         this.selectedClearCounter = selectedClearCounter;
         OnSlectedCounterChanged?.Invoke(this, new OnSlectedCounterChangedEventArgs{
        selectedClearCounter = selectedClearCounter});
     }

public Transform GetKitchenObjectTransform(){
    return kithchenObjectHoldPoint;
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

