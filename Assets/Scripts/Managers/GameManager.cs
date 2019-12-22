using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager GM;

    
    public float StartTimer = 30.0f;

    public GameObject GameOverTriggerText;

    public enum GameState
    {
        Playing,
        GameOver
    }

    public Text Score;
    public Text Timer;


    [Header ("Read-only")]

    [SerializeField]
    private GameState _currentState = GameState.Playing;
    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private float _timer = 0.0f;
    

    public GameState CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    public float TimerValue
    {
        get { return _timer; }
        set { _timer = value; }
    }

    private void Awake()
    {
        GM = this;

        GameOverTriggerText.SetActive(false);

        Score.text = _score.ToString();

        _timer = StartTimer;
    }

    private void Update()
    {
        _timer -= Time.deltaTime;
        Timer.text = _timer.ToString("F");
        if(_timer <= 0)
        {
            _currentState = GameState.GameOver;
            GameOverTriggerText.SetActive(true);
        }
    }

    public void AddScore(int amount)
    {
        _score += amount;
        Score.text = _score.ToString();
    }
}
