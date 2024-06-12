using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum GamePhases
{
    Play, BallMoving
}
public class GameController : MonoBehaviour
{
    public GamePhases gamePhase = GamePhases.Play;
    public static GameController instance;
    public TouchScreen touchScreen;
    public PlayerMove playerMove;

    public UnityEvent OnMouseDrag;

    public delegate void GamePhaseChanged(GamePhases gamePhase);
    public event GamePhaseChanged OnGamePhaseChanged;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetGamePhase(GamePhases phase)
    {
        gamePhase = phase;
        OnGamePhaseChanged?.Invoke(phase);
    }
}
