using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    int rotateCoin = 6;
    void Update()
    {
        transform.Rotate(Vector3.down * rotateCoin);
    }
}
