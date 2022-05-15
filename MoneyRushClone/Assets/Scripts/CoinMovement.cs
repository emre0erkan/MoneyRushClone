using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] float swerveSpeed;
    public Vector3 forwardMove;
    SwerveInputSystem swerveInput;

    private void Start()
    {
        swerveInput = GetComponent<SwerveInputSystem>();
        forwardMove = new Vector3(0f, 0f, 0f);

    }

    void Update()
    {
        transform.position = transform.position + forwardMove;
        Vector3 sideMove = transform.right * swerveSpeed * swerveInput.MoveFactorX * Time.deltaTime;
        transform.position = transform.position + sideMove;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.70f, 2.70f), transform.position.y, transform.position.z);

        //Debug.Log("factor: " + swerveInput.MoveFactorX);
    }



}
