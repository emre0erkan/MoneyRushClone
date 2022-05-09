using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Gates : MonoBehaviour
{
    [SerializeField] Operation operationType;
    [SerializeField] float value;
    private float horizontalMoveSpeed = 0.04f;
    [SerializeField] bool movingGate;

    [SerializeField] Renderer _renderer;
    [SerializeField] Text gateText;

    private void Start()
    {
        if (movingGate)
            transform.DOMoveX(-transform.position.x, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        if (operationType == Operation.substract || operationType == Operation.divide)
        {
            _renderer.material.color = new Color(1f, 0f, 0f, 0.4f);
        }
        else
        {
            _renderer.material.color = new Color(0f, 255f / 138f, 255f, 0.10f);
        }

        switch (operationType)
        {
            case Operation.addition:
                gateText.text = "+" + value + "$";
                break;
            case Operation.multiply:
                gateText.text = "*" + value + "$";
                break;
            case Operation.substract:
                gateText.text = "-" + value + "$";
                break;
        }
    }
    private void Update()
    {
        Debug.Log(horizontalMoveSpeed);
    }
    public float Calculate(float moneyAmount)
    {
        if (operationType == Operation.addition)
        {
            return moneyAmount + value;
        }
        else if (operationType == Operation.multiply)          //increasing or decreasing money
        {
            return moneyAmount * value;
        }
        else if (operationType == Operation.substract)
        {
            return moneyAmount - value;
        }
        else if (operationType == Operation.divide)
        {
            return moneyAmount / value;
        }
        return -1;
    }

    public enum Operation
    {
        addition,
        multiply,       //selecting gate operation from the editor
        substract,
        divide,
    }
}
