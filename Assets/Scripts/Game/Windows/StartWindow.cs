using System;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : Window
{
    [SerializeField] private Button _startButton;

    public event Action<Window> StartButtonClicked;

    protected override void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartButtonClick);

        base.OnEnable();
    }

    protected override void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartButtonClick);

        base.OnDisable();
    }

    private void OnStartButtonClick()
    {
        StartButtonClicked?.Invoke(this);
    }
}
