using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningRecipeSO : ScriptableObject
{
    // Start is called before the first frame update
    
    [SerializeField] public KitchenObjectSO input;
    [SerializeField] public KitchenObjectSO output;
    public int burningmaxTime;
}
