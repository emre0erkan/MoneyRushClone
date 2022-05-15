using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CoinTrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyText;
    public float newMoney;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gate")
        {
            Debug.Log("Triggered");
            float desiredMoney = other.gameObject.GetComponent<Gates>().Calculate(GameManager.Instance.money);       //baþlýyorum
            gameObject.GetComponent<SpawnCoins>().coinAmountToSpawn = desiredMoney;
            if (desiredMoney != GameManager.Instance.money)
            {
                gameObject.GetComponent<SpawnCoins>().DestroyCoins();
                gameObject.GetComponent<SpawnCoins>().SpawnCoin();
            }
            GameManager.Instance.money = gameObject.GetComponent<SpawnCoins>().coinAmountToSpawn;
            moneyText.text = "$" + GameManager.Instance.money.ToString();
            Debug.Log("Total Money: " + GameManager.Instance.money);
            Debug.Log("playerprefs" + PlayerPrefs.GetFloat("totalMoney"));
            if (GameManager.Instance.money <= 0)
            {
                GameManager.Instance.isGameOver = true;
                GameManager.Instance.GameOver();
            }
        }
        else if (other.gameObject.tag == "PlatformEnd")
        {
            newMoney = PlayerPrefs.GetFloat("totalMoney") + GameManager.Instance.money;
            PlayerPrefs.SetFloat("totalMoney", newMoney);
            StartCoroutine(SceneDelay());
        }
    }

    IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
