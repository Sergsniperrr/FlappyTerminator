using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsHandler : MonoBehaviour
{
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private PauseWindow _pauseWindow;
    [SerializeField] private EndGameWindow _endGameWindow;

    [SerializeField] private ObjectsCleaner _cleaner;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Counter _score;

    private Dictionary<Type, Action> _buttons;

    public event Action StartGameButtonPressed;
    public event Action ExitGameButtonPressed;
    public event Action ResumeGameButtonPressed;
    public event Action RestartGameButtonPressed;

    private void OnEnable()
    {
        
    }

    private void OpenEndGameWindow()
    {
        StopTime();
        _endGameWindow.Open();
    }

    private void StopTime()
    {
        float zeroTimeSpeed = 0f;

        Time.timeScale = zeroTimeSpeed;
    }

    private void StartTime()
    {
        float normalTimeSpeed = 1f;

        Time.timeScale = normalTimeSpeed;
    }
    //private Button[] GetButtons(Window window)
    //{
    //    foreach ()
    //}
}
