using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public static int rotateCoin = 2;

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.left * rotateCoin);
        transform.position = transform.position + new Vector3(0, 0, 0.1f);
    }
}
