using System;
using UnityEngine;

public class FryingCounter : BaseCounter
{
    public event EventHandler OnCutObject;

    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;
    [SerializeField] private BurningRecipeSO[] burningRecipeSOArray;

    private FryingRecipeSO fryingRecipeSO;
    private BurningRecipeSO burningRecipeSO;

    private enum State
    {
        Idle,
        Frying,
        Fried,
        Burnt
    }

    private State state;
    private float fryingTimer;
    private float burningTimer;

    void Start()
    {
        state = State.Idle;
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                // Do nothing
                break;
            case State.Frying:
                UpdateFrying();
                break;
            case State.Fried:
                UpdateFried();
                break;
            case State.Burnt:
                // Do something here if needed
                break;
        }
    }

    private void UpdateFrying()
    {
        if (HasKitchenObject())
        {
            fryingTimer += Time.deltaTime;
            if (fryingTimer >= fryingRecipeSO.fryingmaxTime)
            {
                GetKitchenObject().OnDestroy();
                KitchenObject.SpwanKitchenObject(fryingRecipeSO.output, this);
                Debug.Log("Frying RecipeSO output: " + fryingRecipeSO.output.name);

                state = State.Fried; // Transition to Fried state

                burningTimer = 0f;
                burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            }
        }
    }

    private void UpdateFried()
    {
        if (HasKitchenObject())
        {
            burningTimer += Time.deltaTime;
            if (burningTimer >= burningRecipeSO.buringmaxTime)
            {
                GetKitchenObject().OnDestroy();
                KitchenObject.SpwanKitchenObject(burningRecipeSO.output, this);
                Debug.Log("Burning RecipeSO output: " + burningRecipeSO.output.name);

                state = State.Burnt; // Transition to Burnt state
            }
        }
    }

    public override void Interact(NewPlayer newPlayer)
    {
        if (!HasKitchenObject())
        {
            if (newPlayer.HasKitchenObject())
            {
                if (HasRecipeWithInput(newPlayer.GetKitchenObject().GetKitchenObjectSO()))
                {
                    // Player has kitchen object
                    newPlayer.GetKitchenObject().SetKitchenObjectParent(this);

                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    state = State.Frying; // Set to Frying state
                    fryingTimer = 0f;

                    Debug.Log("Transition to Frying state with " + GetKitchenObject().GetKitchenObjectSO().name);
                }
                else
                {
                    Debug.LogError("No valid recipe for the provided kitchen object");
                }
            }
        }
        else
        {
            if (!newPlayer.HasKitchenObject())
            {
                // Player has no kitchen object
                GetKitchenObject().SetKitchenObjectParent(newPlayer);
                state = State.Idle; // Reset state to Idle

                Debug.Log("Transition back to Idle state");
            }
        }
    }

    private bool HasRecipeWithInput(KitchenObjectSO input)
    {
        return GetFryingRecipeSOWithInput(input) != null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == input)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }

    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO input)
    {
        foreach (BurningRecipeSO burningRecipeSO in burningRecipeSOArray)
        {
            if (burningRecipeSO.input == input)
            {
                return burningRecipeSO;
            }
        }
        return null;
    }
}
