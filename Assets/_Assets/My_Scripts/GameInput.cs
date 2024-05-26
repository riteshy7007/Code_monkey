using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInput : MonoBehaviour
{
    // Start is called before the first frame update
    
    public event EventHandler Oninteraction;
    public event EventHandler OninteractionAlter;
     private NewPlayerInput newPlayerInput;

     void Awake(){
         newPlayerInput = new NewPlayerInput();
         newPlayerInput.Enable();
         newPlayerInput.NewPlayer.Interaction.performed += intreact_performed;
         newPlayerInput.NewPlayer.InteractionAlter.performed += intreactAlter_performed;
     }


 public void intreactAlter_performed(UnityEngine.InputSystem.InputAction.CallbackContext context){
            OninteractionAlter?.Invoke(this, EventArgs.Empty);
     }
     public void intreact_performed(UnityEngine.InputSystem.InputAction.CallbackContext context){
            Oninteraction?.Invoke(this, EventArgs.Empty);
     }
    
    public Vector2 GetMovementVectorNormalize()
     
    {
        Vector2 inputVector = newPlayerInput.NewPlayer.Move.ReadValue<Vector2>();

       inputVector = inputVector.normalized;

        
        return inputVector;
    }
}
