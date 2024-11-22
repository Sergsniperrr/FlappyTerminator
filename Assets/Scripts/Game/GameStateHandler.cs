using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private PauseWindow _pauseWindow;
    [SerializeField] private EndGameWindow _endGameWindow;

    [SerializeField] private Reset _cleaner;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _input;

    private void Awake()
    {
        StopTime();
    }

    private void OnEnable()
    {
        _player.GameOver += OpenEndGameWindow;

        _startWindow.StartButtonClicked += StartGame;
        _startWindow.ExitButtonClicked += Exit;

        _pauseWindow.ResumeButtionClicked += Resume;
        _pauseWindow.RestartButtionClicked += Restart;
        _pauseWindow.ExitButtonClicked += Exit;

        _endGameWindow.RestartButtonClicked += Restart;
        _endGameWindow.ExitButtonClicked += Exit;
    }

    private void OnDisable()
    {
        _player.GameOver -= OpenEndGameWindow;

        _startWindow.StartButtonClicked -= StartGame;
        _startWindow.ExitButtonClicked -= Exit;

        _pauseWindow.ResumeButtionClicked -= Resume;
        _pauseWindow.RestartButtionClicked -= Restart;
        _pauseWindow.ExitButtonClicked -= Exit;

        _endGameWindow.RestartButtonClicked -= Restart;
        _endGameWindow.ExitButtonClicked -= Exit;
    }

    private void Update()
    {
        if (_input.IsPauseKeyPress)
            OpenPauseWindow();
    }

    private void StartGame(Window window)
    {
        window.Close();
        _player.Show();
        StartTime();
    }

    private void Exit()
    {
        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false; // “ŒÀ‹ Œ ƒÀﬂ »Ã»“¿÷»» ¬€’Œƒ¿ »« »√–€ ¬ –≈ƒ¿ “Œ–≈!!!
    }

    private void Resume()
    {
        _pauseWindow.Close();
        StartTime();
    }

    private void Restart(Window window)
    {
        ResetObjects();

        StartGame(window);
    }

    private void ResetObjects()
    {
        _cleaner.Clear();
        _player.AllReset();
    }

    private void OpenEndGameWindow()
    {
        StopTime();
        _endGameWindow.Open();
    }

    private void OpenPauseWindow()
    {
        StopTime();
        _pauseWindow.Open();
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
}
