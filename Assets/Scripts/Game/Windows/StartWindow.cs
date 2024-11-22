using System;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _exitButton;

    public event Action<StartWindow> StartButtonClicked;
    public event Action ExitButtonClicked;

    protected virtual void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
        _startButton.onClick.AddListener(OnStartButtonClick);
    }

    protected virtual void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
        _startButton.onClick.RemoveListener(OnStartButtonClick);
    }

    public void Open()
    {
        float maxAlfa = 1f;

        _windowGroup.alpha = maxAlfa;
        _windowGroup.interactable = true;
        _windowGroup.blocksRaycasts = true;
    }

    public void Close()
    {
        float minAlfa = 0f;

        _windowGroup.alpha = minAlfa;
        _windowGroup.interactable = false;
        _windowGroup.blocksRaycasts = false;
    }

    private void OnExitButtonClick()
    {
        ExitButtonClicked?.Invoke();
    }

    private void OnStartButtonClick()
    {
        StartButtonClicked?.Invoke(this);
    }
}
