using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    private Animator animator;
     [SerializeField]private ContainerCounter containerCounter;

   void Awake()
    {
        animator = GetComponent<Animator>();
    }

  void Start()
 {
   containerCounter.OnGrabingObject += ContainerCounter_OnGrabingObject; 
 }
 private void ContainerCounter_OnGrabingObject(object sender, System.EventArgs e)
 {
     animator.SetTrigger("OpenClose");
 }


}
