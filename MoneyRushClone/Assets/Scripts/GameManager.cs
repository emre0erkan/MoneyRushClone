using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public float money;
    public bool isGameOver = false;

    public GameObject coinMove;
    public GameObject failMenuUI;
    [SerializeField] Text totalMoneyText;


    private void Update()
    {
        if (GameManager.Instance.money <= 0) 
        { 
            isGameOver = true;
            GameOver();
        }
        totalMoneyText.text = "Total Money: " + (PlayerPrefs.GetFloat("totalMoney") - 0.5f).ToString();
    }
    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new GameObject("GameManager").AddComponent<GameManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        money = 0.5f;
    }
    private void OnEnable()
    {
        instance = this;
    }

    public void GameOver()
    {
        failMenuUI.SetActive(enabled);
        coinMove.GetComponent<CoinMovement>().forwardMove = new Vector3(0, 0, 0);
    }
}
