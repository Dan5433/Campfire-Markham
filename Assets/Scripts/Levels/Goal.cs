using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    const string PLAYER_TAG = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.transform.CompareTag(PLAYER_TAG))
            return;

        Scene activeScene = SceneManager.GetActiveScene();
        int nextSceneIndex = activeScene.buildIndex + 1;
        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
            nextSceneIndex = 0;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
