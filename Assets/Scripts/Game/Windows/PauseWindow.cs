using System;
using UnityEngine.UI;
using UnityEngine;

public class PauseWindow : StartWindow
{
    [SerializeField] private Button _resumeButton;

    public event Action ResumeButtionClicked;

    protected override void OnEnable()
    {
        _resumeButton.onClick.AddListener(OnResumeButtonClick);

        base.OnEnable();
    }

    protected override void OnDisable()
    {
        _resumeButton.onClick.RemoveListener(OnResumeButtonClick);

        base.OnDisable();
    }

    private void OnResumeButtonClick()
    {
        ResumeButtionClicked?.Invoke();
    }
}
