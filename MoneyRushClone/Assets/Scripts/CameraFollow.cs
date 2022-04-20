using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform mainCoin;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = new Vector3(0, mainCoin.position.y + 7.62f, mainCoin.position.z - 13);
    }
}
