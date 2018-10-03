using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text timerText;
    [SerializeField]
    private Text playerWinner;
    [SerializeField]
    private GameObject endScreen;

    private GameController gameController;

    private void Awake()
    {
        gameController = FindObjectOfType<GameController>();

        gameController.onGameEnd += SetupWinnerPlayer;

        gameController.onGameEnd += SetupEndScreen;
    }

    private void SetupWinnerPlayer()
    {
        playerWinner.text = gameController.GetPlayerWinner();
    }

    // Use this for initialization
    private void Start()
    {
        if (timerText == null)
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        timerText.text = FormatSeconds(gameController.CurrentGameTime);
    }

    private string FormatSeconds(float elapsed)
    {
        int d = (int)(elapsed * 100.0f);

        int minutes = d / (60 * 100);
        int seconds = (d % (60 * 100)) / 100;
        int hundredths = d % 100;

        minutes = (minutes < 0) ? 0 : minutes;
        seconds = (seconds < 0) ? 0 : seconds;
        hundredths = (hundredths < 0) ? 0 : hundredths;

        return String.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }

    private void SetupEndScreen()
    {
        endScreen.SetActive(true);
    }
}