using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCoins : MonoBehaviour
{
    private float coinAmountToSpawn;

    [SerializeField] GameObject newCoin50Prefab;
    [SerializeField] GameObject newCoin25Prefab;
    [SerializeField] GameObject newCoin5Prefab;
    private Text moneyText;     // devam

    private List<GameObject> coin50List = new List<GameObject>();    //$ ¢
    private List<GameObject> coin25List = new List<GameObject>();
    private List<GameObject> coin5List = new List<GameObject>();

    private void Start()
    {
        GameObject newCoin50 = Instantiate(newCoin50Prefab);
        coin50List.Add(newCoin50);
        //newCoin50.GetComponent<CapsuleCollider>().enabled = true;
        newCoin50.transform.parent = gameObject.transform;
        newCoin50.transform.localPosition = new Vector3(0, 0, 0);
        newCoin50.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Gate")
        {
            Debug.Log("Triggered");
            float desiredMoney = other.gameObject.GetComponent<Gates>().Calculate(GameManager.Instance.money);
            coinAmountToSpawn = desiredMoney;
            GameManager.Instance.money = coinAmountToSpawn;

            DestroyCoins();
            SpawnCoin();
            Debug.Log("Total Money: " + GameManager.Instance.money);
        }

    }

    private void SpawnCoin()
    {
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

    private int CoinSpawnCalculate50(float coinAmountToSpawn)
    {
        float coin50ToSpawn;
        int temp = (int)coinAmountToSpawn;
        float decimalPart = (coinAmountToSpawn - temp) * 100;
        coin50ToSpawn = (coinAmountToSpawn / 0.5f) - (coinAmountToSpawn % 0.5f);
        if (decimalPart >= 50)
            coin50ToSpawn = coin50ToSpawn - 1;
        Debug.Log("50 Cent: " + (int)coin50ToSpawn);
        return (int)coin50ToSpawn;
    }

    private int CoinSpawnCalculate25(float coinAmountToSpawn)
    {
        float coin25ToSpawn;
        int temp = (int)coinAmountToSpawn;
        float decimalPart = (coinAmountToSpawn - temp) * 100;
        float temp3 = decimalPart / 25;
        coin25ToSpawn = temp3;
        Debug.Log("25 Cent:" + (int)coin25ToSpawn);
        return (int)coin25ToSpawn;
    }

    private int CoinSpawnCalculate5(float coinAmountToSpawn)
    {
        float coin5ToSpawn;
        int intPart = (int)coinAmountToSpawn;
        float decimalPart = (coinAmountToSpawn - intPart) * 100;
        coin5ToSpawn = Mathf.Round((decimalPart % 25) / 5);
        Debug.Log("5 Cent:" + coin5ToSpawn);
        return (int)coin5ToSpawn;
    }

    //private int CoinDeleteCalculate50(float coin50ToDelete)
    //{
    //    int intPart = (int)coin50ToDelete;
    //    float decimalPart = (deleteAmount - intPart) * 100;
    //    coin50ToDelete = (deleteAmount / 0.5f) - (deleteAmount % 0.5f);  //2-
    //    Debug.Log("Silinen 50 Cent: " + coin50ToDelete);
    //    if (decimalPart > 50)
    //        coin50ToDelete = coin50ToDelete - 1;
    //    return (int)coin50ToDelete;
    //}

    //private int CoinDeleteCalculate25(float coin25ToDelete)
    //{
    //    int intPart = (int)coin25ToDelete;
    //    //int temp = Mathf.FloorToInt(coin25ToDelete);
    //    float decimalPart = (coin25ToDelete - intPart) * 100;                    // we delete everything, these are not needed//
    //    float temp3 = decimalPart / 25;                                          // when we want to delete needed amount of coins
    //    coin25ToDelete = temp3;                                                  // we need to delete more coins than we already have
    //    Debug.Log("Silinen 25 Cent:" + coin25ToDelete);
    //    if (decimalPart == 50)
    //        coin25ToDelete = 0;
    //    return (int)coin25ToDelete;
    //}

    //private int CoinDeleteCalculate5(float coin5ToDelete)
    //{
    //    int temp = (int)coin5ToDelete;
    //    float decimalPart = (coin5ToDelete - temp) * 100;
    //    float temp2 = decimalPart % 25;
    //    coin5ToDelete = temp2 / 5;
    //    Debug.Log("Silinen 5 Cent:" + coin5ToDelete);
    //    return (int)coin5ToDelete;
    //}

    private void SpawnCoin50()
    {
        GameObject newCoin50 = Instantiate(newCoin50Prefab);
        coin50List.Add(newCoin50);
        newCoin50.transform.parent = gameObject.transform;
        newCoin50.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        newCoin50.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void SpawnCoin25()
    {
        GameObject newCoin25 = Instantiate(newCoin25Prefab);
        coin25List.Add(newCoin25);
        newCoin25.transform.parent = transform;
        newCoin25.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        newCoin25.transform.rotation = Quaternion.Euler(0, 0, 90);
    }

    private void SpawnCoin5()
    {
        GameObject newCoin5 = Instantiate(newCoin5Prefab);
        coin5List.Add(newCoin5);
        newCoin5.transform.parent = transform;
        newCoin5.transform.localPosition = new Vector3(Random.Range(-1.2f, 1.2f), 0, Random.Range(-1.5f, 1.5f));
        newCoin5.transform.rotation = Quaternion.Euler(0, 0, 90);
    }



}
