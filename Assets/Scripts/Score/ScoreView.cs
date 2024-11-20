using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ScoreView : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void OnEnable()
    {
        _counter.ScoreChanged += ChangeText;
    }

    private void OnDisable()
    {
        _counter.ScoreChanged -= ChangeText;
    }

    private void ChangeText(int value)
    {
        _text.text = value.ToString();
    }
}
