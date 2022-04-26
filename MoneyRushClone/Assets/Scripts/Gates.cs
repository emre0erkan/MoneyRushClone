using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] Operation operationType;
    [SerializeField] float value;
    private float horizontalMoveSpeed = 0.04f;
    private bool movingGate;

    private void Start()
    {
        if (transform.position.x == 0)       //checking if the gate is supposed to move
            movingGate = true;
    }
    private void Update()
    {
        GateMovement();
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

    private void GateMovement()
    {
        if(movingGate)
        {
            transform.position = transform.position + new Vector3(horizontalMoveSpeed, 0, 0);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.1f, 2.1f), transform.position.y, transform.position.z);
            if (transform.position.x == 2.1f || transform.position.x == -2.1f)
                horizontalMoveSpeed = -horizontalMoveSpeed;      //change direction if reached the edge
        }
    }

    public enum Operation
    {
        addition,
        multiply,       //selecting gate operation from the editor
        divide,
        substract,
    }
}
