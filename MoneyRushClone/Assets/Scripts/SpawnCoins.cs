using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    float cashAmount = 0.5f;

    [SerializeField] GameObject mainCoin;
    [SerializeField] GameObject cent50;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlueGate")
        {
            Instantiate(cent50, new Vector3(0,-4.22f, mainCoin.transform.position.z + 0.02f), Quaternion.identity);
            transform.SetParent(mainCoin.transform, true);
        }
    }

}
