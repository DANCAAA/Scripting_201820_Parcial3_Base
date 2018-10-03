using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<ActorController> players = new List<ActorController>();

    [SerializeField]
    private float gameTime = 25F;

    public float CurrentGameTime { get; private set; }

    public delegate void OnGameStart();

    public OnGameStart onGameStart;

    public delegate void OnGameEnd();

    public OnGameEnd onGameEnd;

    // ***

    private bool startCountdown = false;

    // ***

    [HideInInspector]
    public ActorController lastPlayerTagged;
    [HideInInspector]
    public ActorController currenPlayerTagged;

    // Use this for initialization
    private IEnumerator Start()
    {
        CurrentGameTime = gameTime;

        yield return new WaitForSeconds(0.5F);

        CheckPlayers();
    }

    public string GetPlayerWinner()
    {
        int currentPlayerWinnerIndex = 0;

        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].taggedCount < players[currentPlayerWinnerIndex].taggedCount)
            {
                currentPlayerWinnerIndex = i;
            }
        }

        return string.Format("{0}: {1}", 
            players[currentPlayerWinnerIndex].name,
            players[currentPlayerWinnerIndex].taggedCount);
    }

    private void CheckPlayers()
    {
        ActorController[] actors = FindObjectsOfType<ActorController>();

        for (int i = 0; i < actors.Length; i++)
        {
            if (i <= 4)
                players.Add(actors[i]);
            else
                DestroyImmediate(actors[i]);
        }

        // Mark a player as tagged
        players[UnityEngine.Random.Range(0, players.Count)].onActorTagged(true);
    }

    private void Update()
    {
        if (startCountdown)
            CurrentGameTime -= Time.deltaTime;

        if (CurrentGameTime <= 0F)
        {
            if (onGameEnd != null)
                onGameEnd();

            startCountdown = false;
        }
    }

    public void SetCurrentPlayerTagged(ActorController actorController)
    {
        if (currenPlayerTagged != null)
            lastPlayerTagged = currenPlayerTagged;

        currenPlayerTagged = actorController;
    }

    public void StartGame()
    {
        if (onGameStart != null)
            onGameStart();

        startCountdown = true;
    }
}
