using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class BurningRecipeSO : ScriptableObject
{
    [SerializeField] public KitchenObjectSO input;
    [SerializeField] public KitchenObjectSO output;
    public int buringmaxTime;
    
}
