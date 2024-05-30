using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class FryingRecipeSO : ScriptableObject
{
    [SerializeField] public KitchenObjectSO input;
    [SerializeField] public KitchenObjectSO output;
    public int fryingmaxTime;
    
}
