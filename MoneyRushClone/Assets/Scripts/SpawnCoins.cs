using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    float cashAmount = 0.5f;
    

    [SerializeField] GameObject mainCoin;
    [SerializeField] GameObject newCoin;

    private void SpawnCoin()
    {
        Quaternion newCoinRotate = Quaternion.Euler(0, 0, 90);
        Vector3 nextSpawnPoint = new Vector3(0, -4.22f, transform.position.z + 0.005f);
        newCoin = Instantiate(newCoin, nextSpawnPoint, newCoinRotate);
        newCoin.transform.SetParent(mainCoin.transform, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "BlueGate")
        {
            SpawnCoin();
        }
    }

}
