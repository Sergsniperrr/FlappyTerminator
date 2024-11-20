using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private PauseWindow _pauseWindow;
    [SerializeField] private EndGameWindow _endGameWindow;

    [SerializeField] private ObjectsCleaner _cleaner;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Counter _score;

    private void Awake()
    {
        StopTime();
    }

    private void OnEnable()
    {
        _player.GameOver += OpenEndGameWindow;

        _startWindow.StartButtonClicked += StartGame;
        _startWindow.ExitButtonClicked += ExitGame;

        _pauseWindow.ResumeButtionClicked += ResumeGame;
        _pauseWindow.RestartButtionClicked += RestartGame;
        _pauseWindow.ExitButtonClicked += ExitGame;

        _endGameWindow.RestartButtonClicked += RestartGame;
        _endGameWindow.ExitButtonClicked += ExitGame;
    }

    private void OnDisable()
    {
        _player.GameOver -= OpenEndGameWindow;

        _startWindow.StartButtonClicked -= StartGame;
        _startWindow.ExitButtonClicked -= ExitGame;

        _pauseWindow.ResumeButtionClicked -= ResumeGame;
        _pauseWindow.RestartButtionClicked -= RestartGame;
        _pauseWindow.ExitButtonClicked -= ExitGame;

        _endGameWindow.RestartButtonClicked -= RestartGame;
        _endGameWindow.ExitButtonClicked -= ExitGame;
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

    private void ExitGame()
    {
        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false; // “ŒÀ‹ Œ ƒÀﬂ »Ã»“¿÷»» ¬€’Œƒ¿ »« »√–€ ¬ –≈ƒ¿ “Œ–≈!!!
    }

    private void ResumeGame()
    {
        _pauseWindow.Close();
        StartTime();
    }

    private void RestartGame(Window window)
    {
        ResetObjects();

        StartGame(window);
    }

    private void ResetObjects()
    {
        _cleaner.Clear();
        _player.AllReset();
        _score.ResetValue();
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
