using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public Knife knife;
    private bool isHolding;
    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            isHolding = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            isHolding = false;
            knife.OnMouseButtonUp();
        }
    }
    public bool GetHoldingState() => isHolding;
}
