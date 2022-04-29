using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    public float money;
    public bool isGameOver = false;

    public GameObject coinMove;
    public GameObject failMenuUI;


    private void Update()
    {
        if (GameManager.Instance.money <= 0) 
        { 
            isGameOver = true;
            GameOver();
        }
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
        Time.timeScale = 0f;
        coinMove.GetComponent<CoinMovement>().forwardMove = new Vector3(0, 0, 0);
    }
}
