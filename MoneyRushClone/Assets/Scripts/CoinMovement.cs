using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    //public static int rotateCoin = 2;
    [SerializeField] float swerveSpeed;
    [SerializeField] float maxSwerveAmount;

    SwerveInputSystem swerveInput;

    private void Awake()
    {
        swerveInput = GetComponent<SwerveInputSystem>();
    }

    void Update()
    {
        //transform.Rotate(Vector3.left * rotateCoin);
        transform.position = transform.position + new Vector3(0, 0, 0.1f);
        Vector3 sideMove = -transform.right * swerveSpeed * swerveInput.MoveFactorX * Time.deltaTime;
        transform.position = transform.position + sideMove;

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -2.3f, 2.3f), transform.position.y, transform.position.z);
    }
}
