using EditorAttributes;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTimer;
    [SerializeField] TMP_Text timerText;
    float timer;

    private void Awake()
    {
        timer = startTimer;
    }

    [Button("Test Timer", 36)]
    void SetTimer(float time)
    {
        timer = time;
    }

    void Update()
    {
        if (timer <= 0)
            return;

        timer -= Time.deltaTime;
        timerText.text = $"{timer:F3} s";
    }
}
