using EditorAttributes;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTimer;
    [SerializeField] TMP_Text timerText;
    [SerializeField] PlayerBodyParts playerBodyParts;
    float timer;
    bool didRunOutOfTime = false;

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
        if (timer <= 0 && !didRunOutOfTime)
        {
            didRunOutOfTime = true;
            timer = 0;
            timerText.color = Color.firebrick;
            playerBodyParts.ExplodeLimbs();
        }
        else
            timer -= Time.deltaTime;

        timerText.text = $"{timer:F3} s";
    }
}
