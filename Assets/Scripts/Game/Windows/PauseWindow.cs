using System;
using UnityEngine.UI;
using UnityEngine;

public class PauseWindow : Window
{
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _restartButton;

    public event Action ResumeButtionClicked;
    public event Action<Window> RestartButtionClicked;

    protected override void OnEnable()
    {
        _resumeButton.onClick.AddListener(OnResumeButtonClick);
        _restartButton.onClick.AddListener(OnRestartButtonClick);

        base.OnEnable();
    }

    protected override void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(OnResumeButtonClick);
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);

        base.OnDisable();
    }

    private void OnResumeButtonClick()
    {
        ResumeButtionClicked?.Invoke();
    }

    private void OnRestartButtonClick()
    {
        RestartButtionClicked?.Invoke(this);
    }
}
