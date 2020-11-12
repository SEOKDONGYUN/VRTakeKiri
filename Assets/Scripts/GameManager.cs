using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance;

    public bool isGameover = false;
            
    public Text scoreText;
    public GameObject clearText;

    public int score;
    public int combo;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }
        
    void Update()
    {
        if (score >= 30)
        {
            clearText.SetActive(true);
            isGameover = true;
        }
    }

    public void AddScore(int newScore)
    {
        if (!isGameover)
        {
            score += newScore;
            scoreText.text = "Score : " + score;
            
            if(newScore > 0)
            {
                combo += 1;
            }
            else
            {
                combo = 0;
            }
        }
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
