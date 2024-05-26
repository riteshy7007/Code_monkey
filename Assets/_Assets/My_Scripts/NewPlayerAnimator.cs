using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    [SerializeField] private NewPlayer newPlayer;

    void Awake()
    {
        animator = GetComponent<Animator>();

    }
      void Update() {
      if(newPlayer.IsWalking()){
          animator.SetBool("IsWalking", true);
    }
    else{
        animator.SetBool("IsWalking", false);
        }
    }

}
