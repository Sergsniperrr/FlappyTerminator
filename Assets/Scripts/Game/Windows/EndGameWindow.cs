using System;
using UnityEngine.UI;
using UnityEngine;

public class EndGameWindow : Window
{
    [SerializeField] private Button _restartButton;

    public event Action<Window> RestartButtonClicked;

    protected override void OnEnable()
    {
        _restartButton.onClick.AddListener(OnRestartButtonClick);

        base.OnEnable();
    }

    protected override void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);

        base.OnDisable();
    }

    private void OnRestartButtonClick()
    {
        RestartButtonClicked?.Invoke(this);
    }
}
