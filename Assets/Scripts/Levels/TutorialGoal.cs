using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialGoal : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.transform.CompareTag(PLAYER_TAG))
            return;

        SceneManager.LoadScene(0);
    }
}
