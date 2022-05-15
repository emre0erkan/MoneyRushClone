using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public float money;
    public bool isGameOver = false;

    public GameObject coinMove;
    public GameObject failMenuUI;
    public GameObject startButton;
    [SerializeField] Text totalMoneyText;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        money = 0.5f;
        if (SceneManager.GetActiveScene().name == "Game")
            totalMoneyText.text = "Total Money: " + (PlayerPrefs.GetFloat("totalMoney") - 0.5f).ToString();
        else
            totalMoneyText.text = "Total Money: " + (PlayerPrefs.GetFloat("totalMoney")).ToString();

    }
    private void OnEnable()
    {
        instance = this;
    }

    public void StartGame()
    {
        coinMove.GetComponent<CoinMovement>().forwardMove = new Vector3(0f, 0f, 0.1f);
    }

    public void GameOver()
    {
        startButton.SetActive(false);
        failMenuUI.SetActive(enabled);
        coinMove.GetComponent<CoinMovement>().forwardMove = new Vector3(0, 0, 0);
    }

    public void Retry()
    {
        isGameOver = false;
        startButton.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
