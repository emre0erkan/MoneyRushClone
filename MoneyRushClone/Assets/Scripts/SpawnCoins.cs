using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoins : MonoBehaviour
{
    private double coinAmount;
    private double coinAmountToSpawn;
    private double deleteAmount;
    private double restMoney;
    private bool isDecreasing;

    [SerializeField] GameObject newCoin50;
    [SerializeField] GameObject newCoin25;
    [SerializeField] GameObject newCoin5;

    private List<GameObject> coin50List = new List<GameObject>();
    private List<GameObject> coin25List = new List<GameObject>();
    private List<GameObject> coin5List = new List<GameObject>();

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "x2")
        {
            isDecreasing = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            coinAmount = GameManager.Instance.money;
            GameManager.Instance.money = GameManager.Instance.money * 2;  //better system for multiplying gates
            coinAmountToSpawn = GameManager.Instance.money - coinAmount;
            Debug.Log("Spawnlanacak: " + coinAmountToSpawn);

            SpawnCoin();

            Debug.Log("Total Money: " + GameManager.Instance.money);
        }
        if (other.gameObject.tag == "x4")
        {
            isDecreasing = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            coinAmount = GameManager.Instance.money;
            GameManager.Instance.money = GameManager.Instance.money * 4;
            coinAmountToSpawn = GameManager.Instance.money - coinAmount;
            Debug.Log("Spawnlanacak: " + coinAmountToSpawn);

            SpawnCoin();

            Debug.Log("Total Money: " + GameManager.Instance.money);
        }
        if (other.gameObject.tag == "+2.4")
        {
            isDecreasing = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;  //system for multiplying gates is not neccessary here
            GameManager.Instance.money = GameManager.Instance.money + 2.4f;
            coinAmountToSpawn = 2.4f;
            Debug.Log("Spawnlanacak: " + coinAmountToSpawn);

            SpawnCoin();

            Debug.Log("Total Money: " + GameManager.Instance.money);
        }
        /////////////////////////////////////////////////////////////////////////////
        if (other.gameObject.tag == "-1")
        {
            isDecreasing = true;
            deleteAmount = 1 + 0.5f;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            coinAmount = GameManager.Instance.money;
            restMoney = GameManager.Instance.money - deleteAmount;
            GameManager.Instance.money = GameManager.Instance.money - 1;

            DestroyCoins();
            SpawnCoin();

            Debug.Log("Total Money: " + GameManager.Instance.money);
        }
        if (other.gameObject.tag == "divide2")
        {
            isDecreasing = true;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            deleteAmount = (GameManager.Instance.money / 2) + 0.5f;
            restMoney = GameManager.Instance.money - deleteAmount;
            GameManager.Instance.money = GameManager.Instance.money / 2;
            Debug.Log("Silinecek para: " + deleteAmount);

            DestroyCoins();
            SpawnCoin();

            Debug.Log("Total Money: " + GameManager.Instance.money);
        }
    }

    private void SpawnCoin()
    {
        if (isDecreasing)
            coinAmountToSpawn = restMoney;

        for (int j = 0; j < CoinSpawnCalculate50(coinAmountToSpawn); j++)
        {
            SpawnCoin50();
        }
        for (int t = 0; t < CoinSpawnCalculate25(coinAmountToSpawn); t++)
        {
            SpawnCoin25();
        }
        for (int k = 0; k < CoinSpawnCalculate5(coinAmountToSpawn); k++)
        {
            SpawnCoin5();
        }
    }

    private void DestroyCoins()
    {
        for (int i = coin50List.Count - 1; i >= 0; i--)
        {
            Destroy(coin50List[i]);
            coin50List.RemoveAt(i);
        }
        for (int i = coin25List.Count - 1; i >= 0; i--)
        {
            Destroy(coin25List[i]);
            coin25List.RemoveAt(i);
        }
        for (int i = coin5List.Count - 1; i >= 0; i--)
        {
            Destroy(coin5List[i]);
            coin5List.RemoveAt(i);
        }
    }

    private int CoinSpawnCalculate50(double coinAmountToSpawn)
    {
        double coin50ToSpawn;
        double temp = (int)coinAmountToSpawn;
        double decimalPart = (coinAmountToSpawn - temp) * 100;
        coin50ToSpawn = (coinAmountToSpawn / 0.5f) - (coinAmountToSpawn % 0.5f);
        Debug.Log("50 Cent: " + coin50ToSpawn);
        if (decimalPart > 50)
            coin50ToSpawn = coin50ToSpawn - 1;
        return (int)coin50ToSpawn;
    }

    private int CoinSpawnCalculate25(double coinAmountToSpawn)
    {
        double coin25ToSpawn;
        double temp = (int)coinAmountToSpawn;
        double decimalPart = (coinAmountToSpawn - temp) * 100;
        double temp3 = decimalPart / 25;
        coin25ToSpawn = temp3;
        Debug.Log("25 Cent:" + coin25ToSpawn);
        if (decimalPart == 50)
            coin25ToSpawn = 0;
        return (int)coin25ToSpawn;
    }

    private int CoinSpawnCalculate5(double coinAmountToSpawn)
    {
        double coin5ToSpawn;
        double temp = (int)coinAmountToSpawn;
        double decimalPart = (coinAmountToSpawn - temp) * 100;
        double temp2 = decimalPart % 25;
        coin5ToSpawn = temp2 / 5;
        Debug.Log("5 Cent:" + coin5ToSpawn);
        return (int)coin5ToSpawn;
    }

    private int CoinDeleteCalculate50(double coin50ToDelete)
    {
        double temp = (int)coin50ToDelete;
        double decimalPart = (deleteAmount - temp) * 100;
        coin50ToDelete = (deleteAmount / 0.5f) - (deleteAmount % 0.5f);  //2-
        Debug.Log("Silinen 50 Cent: " + coin50ToDelete);
        if (decimalPart > 50)
            coin50ToDelete = coin50ToDelete - 1;
        return (int)coin50ToDelete;
    }

    private int CoinDeleteCalculate25(double coin25ToDelete)
    {
        double temp = (int)coin25ToDelete;
        double decimalPart = (coin25ToDelete - temp) * 100;
        double temp3 = decimalPart / 25;
        coin25ToDelete = temp3;
        Debug.Log("Silinen 25 Cent:" + coin25ToDelete);
        if (decimalPart == 50)
            coin25ToDelete = 0;
        return (int)coin25ToDelete;
    }

    private int CoinDeleteCalculate5(double coin5ToDelete)
    {
        double temp = (int)coin5ToDelete;
        double decimalPart = (coin5ToDelete - temp) * 100;
        double temp2 = decimalPart % 25;
        coin5ToDelete = temp2 / 5;
        Debug.Log("Silinen 5 Cent:" + coin5ToDelete);
        return (int)coin5ToDelete;
    }

    private void SpawnCoin50()
    {
        newCoin50 = Instantiate(newCoin50);
        coin50List.Add(newCoin50);
        newCoin50.transform.parent = transform;
        newCoin50.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        newCoin50.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void SpawnCoin25()
    {
        newCoin25 = Instantiate(newCoin25);
        coin25List.Add(newCoin25);
        newCoin25.transform.parent = transform;
        newCoin25.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        newCoin25.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void SpawnCoin5()
    {
        newCoin5 = Instantiate(newCoin5);
        coin5List.Add(newCoin5);
        newCoin5.transform.parent = transform;
        newCoin5.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        newCoin5.transform.rotation = Quaternion.Euler(0, 0, 90);
    }


}
