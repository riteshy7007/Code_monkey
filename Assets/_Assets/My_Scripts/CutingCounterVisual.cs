using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private Animator animator;
     [SerializeField]private CuttingCounter cuttingCounter;

   void Awake()
    {
        animator = GetComponent<Animator>();
    }

  void Start()
 {
   cuttingCounter.OnCutObject += ContainerCounter_OnGrabingObject; 
 }
 private void ContainerCounter_OnGrabingObject(object sender, System.EventArgs e)
 {
     animator.SetTrigger("Cut");
 }


}
