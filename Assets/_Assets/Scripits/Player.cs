using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }
    private void Update() 
     { 
           Vector2 inputVector=new Vector2(0,0);
        
        if (Input.GetKey(KeyCode.W))
        {
            inputVector.y =+1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            inputVector.y =-1;
        }
        if (Input.GetKey(KeyCode.A))
        {
        inputVector.x =+1;
        }
        if (Input.GetKey(KeyCode.D))
        {
        inputVector.x =-1;
        }
       
       
       
   }  
}
