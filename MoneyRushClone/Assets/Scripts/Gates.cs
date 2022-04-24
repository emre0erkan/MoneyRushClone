using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] Operation operationType;
    [SerializeField] float value;

    public float Calculate(float moneyAmount)
    {
        if (operationType == Operation.addition)
        {
            return moneyAmount + value;
        }
        else if (operationType == Operation.multiply)
        {
            return moneyAmount * value;
        }
        else if (operationType == Operation.divide)
        {
            return moneyAmount / value;
        }
        else if (operationType == Operation.substract)
        {
            return moneyAmount - value;
        }
        return -1;
    }

    public enum Operation
    {
        addition,
        multiply,
        divide,
        substract,
    }
}
