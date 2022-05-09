using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Gate")
        {
            Debug.Log("Triggered");
            float desiredMoney = other.gameObject.GetComponent<Gates>().Calculate(GameManager.Instance.money);
            gameObject.GetComponent<SpawnCoins>().coinAmountToSpawn = desiredMoney;
            GameManager.Instance.money = gameObject.GetComponent<SpawnCoins>().coinAmountToSpawn;
            moneyText.text = "$" + GameManager.Instance.money.ToString();
            gameObject.GetComponent<SpawnCoins>().DestroyCoins();
            gameObject.GetComponent<SpawnCoins>().SpawnCoin();

            Debug.Log("Total Money: " + GameManager.Instance.money);
        }
        else if (other.gameObject.tag == "PlatformEnd")
        {
            PlayerPrefs.SetFloat("totalMoney", PlayerPrefs.GetFloat("totalMoney") + GameManager.Instance.money);
            StartCoroutine(SceneDelay());
        }

    }

    IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
