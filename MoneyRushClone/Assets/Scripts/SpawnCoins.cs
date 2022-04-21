using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    private double coinAmount;
    private double coinAmountToSpawn;
    private float coinAmountToSpawnFloat;
    private double coin50ToSpawn;
    private double coin5ToSpawn;
    private double coin25ToSpawn;

    
    [SerializeField] GameObject newCoin50;
    [SerializeField] GameObject newCoin25;
    [SerializeField] GameObject newCoin5;


    private void SpawnCoin()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "BlueGate")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            coinAmountToSpawn = 3 / 0.5f;
            Debug.Log(GameManager.Instance.money);
            for (int i = 0; i < coinAmountToSpawn; i++)
            {
                SpawnCoin50();
            }
        }
        if(other.gameObject.tag == "+1.25")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            coinAmount = GameManager.Instance.money;
            GameManager.Instance.money = GameManager.Instance.money + 1.25f;
            coinAmountToSpawn = GameManager.Instance.money - coinAmount;
            Debug.Log("Spawnlanacak: " + coinAmountToSpawn);
            coin50ToSpawn = (coinAmountToSpawn / 0.5f) - (coinAmountToSpawn % 0.5f);
            int coin50ToSpawn2 = (int)coin50ToSpawn;
            Debug.Log("50 Cent: " + coin50ToSpawn2);

            double temp = (int)coinAmountToSpawn;
            coin5ToSpawn = ((coinAmountToSpawn - temp) * 100) / 5;
            Debug.Log("5 Cent:" + coin5ToSpawn);

            Debug.Log("Total Money: " + GameManager.Instance.money);
            for (int j = 0; j < coin50ToSpawn2; j++)
            {
                SpawnCoin50();
            }
            for (int k = 0; k < coin5ToSpawn; k++)
            {
                SpawnCoin5();
            }
        }
    }

    private void SpawnCoin50()
    {
        newCoin50 = Instantiate(newCoin50);
        newCoin50.transform.parent = transform;
        //newCoin.transform.localPosition = new Vector3(transform.position.x + newCoinDistance, 0, 0);

        //do
        //{          //ana parayla deðil, tüm childlarýn birbiriyle deðip deðmediði kontrol edilmeli
        //    newCoin.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        //} while (this.GetComponentInChildren<CapsuleCollider>().bounds.Intersects(newCoin.GetComponent<CapsuleCollider>().bounds));

        newCoin50.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));

        //newCoinDistance++;
        newCoin50.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void SpawnCoin25()
    {
        newCoin25 = Instantiate(newCoin25);
        newCoin25.transform.parent = transform;
        //newCoin.transform.localPosition = new Vector3(transform.position.x + newCoinDistance, 0, 0);

        //do
        //{          //ana parayla deðil, tüm childlarýn birbiriyle deðip deðmediði kontrol edilmeli
        //    newCoin.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        //} while (this.GetComponentInChildren<CapsuleCollider>().bounds.Intersects(newCoin.GetComponent<CapsuleCollider>().bounds));

        newCoin25.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), transform.localPosition.y-0.27f, Random.Range(-1.5f, 1.5f));

        //newCoinDistance++;
        newCoin25.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void SpawnCoin5()
    {
        newCoin5 = Instantiate(newCoin5);
        newCoin5.transform.parent = transform;
        //newCoin.transform.localPosition = new Vector3(transform.position.x + newCoinDistance, 0, 0);

        //do
        //{          //ana parayla deðil, tüm childlarýn birbiriyle deðip deðmediði kontrol edilmeli
        //    newCoin.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        //} while (this.GetComponentInChildren<CapsuleCollider>().bounds.Intersects(newCoin.GetComponent<CapsuleCollider>().bounds));

        newCoin5.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));

        //newCoinDistance++;
        newCoin5.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

}
