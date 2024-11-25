using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private PauseWindow _pauseWindow;

    [SerializeField] private Reset _cleaner;
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _input;

    private void Awake()
    {
        StopTime();
    }

    private void OnEnable()
    {
        _player.Died += OpenEndGameWindow;

        _startWindow.StartButtonClicked += StartGame;
        _startWindow.ExitButtonClicked += Exit;

        _pauseWindow.ResumeButtionClicked += Resume;
        _pauseWindow.StartButtonClicked += StartGame;
        _pauseWindow.ExitButtonClicked += Exit;
    }

    private void OnDisable()
    {
        _player.Died -= OpenEndGameWindow;

        _startWindow.StartButtonClicked -= StartGame;
        _startWindow.ExitButtonClicked -= Exit;

        _pauseWindow.ResumeButtionClicked -= Resume;
        _pauseWindow.StartButtonClicked -= StartGame;
        _pauseWindow.ExitButtonClicked -= Exit;
    }

    private void Update()
    {
        if (_input.IsPauseKeyPress)
            OpenPauseWindow();
    }

    private void StartGame(StartWindow window)
    {
        ResetObjects();

        window.Close();
        _player.Show();
        StartTime();
    }

    private void Exit()
    {
        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false; // ������ ��� �������� ������ �� ���� � ���������!!!
    }

    private void Resume()
    {
        _pauseWindow.Close();
        StartTime();
    }

    private void ResetObjects()
    {
        _cleaner.Clear();
        _player.AllReset();
    }

    private void OpenEndGameWindow()
    {
        StopTime();
        _startWindow.Open();
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
