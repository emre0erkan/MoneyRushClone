using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    private float money;

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
        money = 0.50f;
    }
    private void OnEnable()
    {
        instance = this;
    }

    public float GetMoney()
    {
        return money;
    }
}
