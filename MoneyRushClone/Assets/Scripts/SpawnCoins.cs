using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    private double coinAmount;
    private double spawnedCoin;
    private double coinAmountToSpawn;

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
            GameManager.Instance.money = GameManager.Instance.money + 3.65f;
            coinAmountToSpawn = GameManager.Instance.money - coinAmount;
            Debug.Log("Spawnlanacak: " + coinAmountToSpawn);


            for (int j = 0; j < CoinCalculate50(coinAmount); j++)
            {
                SpawnCoin50();
            }
            for (int t = 0; t < CoinCalculate25(coinAmount); t++)
            {
                SpawnCoin25();
            }
            for (int k = 0; k < CoinCalculate5(coinAmount); k++)
            {
                SpawnCoin5();
            }
            Debug.Log("Total Money: " + GameManager.Instance.money);
        }
    }

    private int CoinCalculate50(double coin50ToSpawn)
    {
        double temp = (int)coinAmountToSpawn;
        double decimalPart = (coinAmountToSpawn - temp) * 100;
        coin50ToSpawn = (coinAmountToSpawn / 0.5f) - (coinAmountToSpawn % 0.5f);
        Debug.Log("50 Cent: " + coin50ToSpawn);
        if (decimalPart > 50)
            coin50ToSpawn = coin50ToSpawn - 1;
        return (int)coin50ToSpawn;
    }

    private int CoinCalculate25(double coin25ToSpawn)
    {
        double temp = (int)coinAmountToSpawn;
        double decimalPart = (coinAmountToSpawn - temp) * 100;
        double temp3 = decimalPart / 25;
        coin25ToSpawn = temp3;
        Debug.Log("25 Cent:" + coin25ToSpawn);
        return (int)coin25ToSpawn;
    }

    private int CoinCalculate5(double coin5ToSpawn)
    {
        double temp = (int)coinAmountToSpawn;
        double decimalPart = (coinAmountToSpawn - temp) * 100;
        double temp2 = decimalPart % 25;
        coin5ToSpawn = temp2 / 5;
        Debug.Log("5 Cent:" + coin5ToSpawn);
        return (int)coin5ToSpawn;
    }

    private void SpawnCoin50()
    {
        newCoin50 = Instantiate(newCoin50);
        newCoin50.transform.parent = transform;
        newCoin50.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        newCoin50.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void SpawnCoin25()
    {
        newCoin25 = Instantiate(newCoin25);
        newCoin25.transform.parent = transform;
        newCoin25.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
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
