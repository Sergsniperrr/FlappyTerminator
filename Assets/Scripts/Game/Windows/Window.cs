using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowGroup;
    [SerializeField] private Button _exitButton;

    public event Action ExitButtonClicked;

    protected virtual void OnEnable()
    {
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    protected virtual void OnDisable()
    {
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
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
}