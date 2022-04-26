using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    [SerializeField] float swerveSpeed;

    SwerveInputSystem swerveInput;

    private void Awake()
    {
        swerveInput = GetComponent<SwerveInputSystem>();
    }

    void Update()
    {
        //transform.Rotate(Vector3.left * rotateCoin);
        transform.position = transform.position + new Vector3(0, 0, 0.1f);
        Vector3 sideMove = transform.right * swerveSpeed * swerveInput.MoveFactorX * Time.deltaTime;
        transform.position = transform.position + sideMove;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.70f, 2.70f), transform.position.y, transform.position.z);
    }
}
