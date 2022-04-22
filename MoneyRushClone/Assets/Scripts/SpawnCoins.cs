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
        if (other.gameObject.tag == "+1.25")
        {
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            coinAmount = GameManager.Instance.money;
            GameManager.Instance.money = GameManager.Instance.money + 3.80f;
            coinAmountToSpawn = GameManager.Instance.money - coinAmount;
            Debug.Log("Spawnlanacak: " + coinAmountToSpawn);

            coin50ToSpawn = (coinAmountToSpawn / 0.5f) - (coinAmountToSpawn % 0.5f);
            int coin50ToSpawn2 = (int)coin50ToSpawn;
            Debug.Log("50 Cent: " + coin50ToSpawn2);

            double temp = (int)coinAmountToSpawn;
            double decimalPart = (coinAmountToSpawn - temp) * 100;
            Debug.Log("bu ne dec: " + decimalPart);
            double temp2 = decimalPart % 25;

            double temp3 = decimalPart / 25;
            Debug.Log("bu ne: " + temp3);

            coin5ToSpawn = temp2 / 5;
            //double decimalPart2 = (coinAmountToSpawn - temp) * 100;
            //coin5ToSpawn = decimalPart2 / 5;
            coin5ToSpawn = (int)coin5ToSpawn;
            Debug.Log("5 Cent:" + coin5ToSpawn);
            coin25ToSpawn = temp3;
            coin25ToSpawn = (int)coin25ToSpawn;
            Debug.Log("25 Cent:" + coin25ToSpawn);




            Debug.Log("Total Money: " + GameManager.Instance.money);
            for (int j = 0; j < coin50ToSpawn2; j++)
            {
                SpawnCoin50();
            }
            for (int t = 0; t < coin25ToSpawn; t++)
            {
                SpawnCoin25();
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

        newCoin25.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));

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
