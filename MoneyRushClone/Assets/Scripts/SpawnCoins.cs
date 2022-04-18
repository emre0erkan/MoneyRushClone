using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    //float cashAmount = 0.5f;
    float newCoinDistance = 0.02f;
    

    
    [SerializeField] GameObject newCoin;

    private void SpawnCoin()
    {
        newCoin = Instantiate(newCoin);
        newCoin.transform.parent = transform;
        newCoin.transform.localPosition = new Vector3(transform.position.x + newCoinDistance, 0, 0);
        newCoinDistance++;
        newCoin.transform.rotation = Quaternion.Euler(0, 0, 90);
        //Quaternion newCoinRotate = Quaternion.Euler(0, 0, 90);
        //Vector3 nextSpawnPoint = new Vector3(transform.position.x + newCoinDistance, -4.22f, 0);
        //newCoin = Instantiate(newCoin, nextSpawnPoint, newCoinRotate);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlueGate")
        {
            SpawnCoin();
        }
    }

}
