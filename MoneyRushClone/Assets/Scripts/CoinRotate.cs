using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    int rotateCoin = 2;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * rotateCoin);
    }
}
