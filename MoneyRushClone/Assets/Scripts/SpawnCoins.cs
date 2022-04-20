using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    //float cashAmount = 0.5f;
    float newCoinDistance = 0.02f;
    private float moneyAmount;
    private float tempMoney;

    
    [SerializeField] GameObject newCoin;

    private void SpawnCoin()
    {
        newCoin = Instantiate(newCoin);
        newCoin.transform.parent = transform;
        //newCoin.transform.localPosition = new Vector3(transform.position.x + newCoinDistance, 0, 0);
        newCoin.transform.localPosition = new Vector3(Random.Range(-0.4f, -2f) + Random.Range(0.4f, 2f), 0, Random.Range(-0.5f, -2f) + Random.Range(0.5f, 2f));
        //newCoinDistance++;
        newCoin.transform.rotation = Quaternion.Euler(0, 0, 90);
        //if (this.GetComponent<CapsuleCollider>().bounds.Intersects(newCoin.GetComponent<CapsuleCollider>().bounds))
        //{

        //}
        do
        {          //tüm childlarýn birbiriyle deðip deðmediði kontrol edilmeli
          newCoin.transform.localPosition = new Vector3(Random.Range(-0.4f, -2f) + Random.Range(0.4f, 2f), 0, Random.Range(-0.5f, -2f) + Random.Range(0.5f, 2f));
        } while (this.GetComponentInChildren<CapsuleCollider>().bounds.Intersects(newCoin.GetComponent<CapsuleCollider>().bounds));

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlueGate")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            SpawnCoin();
            tempMoney = GameManager.Instance.GetMoney();
            tempMoney++;
            Debug.Log(tempMoney);    //her triggerda gamemanagerdeki moneyi arttýr. her seferinde 0.5i arttýrýyor düzelt
        }
    }

}
