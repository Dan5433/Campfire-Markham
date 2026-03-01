using EditorAttributes;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBodyParts : MonoBehaviour
{
    [SerializeField][MinMaxSlider(-1_000f, 1_000f)] Vector2 xExplodeForceRange;
    [SerializeField][MinMaxSlider(-1_000f, 1_000f)] Vector2 yExplodeForceRange;
    [SerializeField] float titleReturnDelay;
    [SerializeField] CinemachineCamera cinemachineCamera;
    [SerializeField] Rigidbody2D[] bodyParts;

    [Button(nameof(ExplodeLimbs), 36)]
    public void ExplodeLimbs()
    {
        cinemachineCamera.Follow = null;

        foreach (Rigidbody2D rigidbody in bodyParts)
        {
            if (rigidbody.TryGetComponent<HingeJoint2D>(out var hingeJoint))
                hingeJoint.enabled = false;

            Vector2 explodeForce = new(
                Random.Range(xExplodeForceRange.x, xExplodeForceRange.y),
                Random.Range(yExplodeForceRange.x, yExplodeForceRange.y));
            rigidbody.AddForce(explodeForce, ForceMode2D.Impulse);
        }

        Invoke(nameof(LoadTitleScreen), titleReturnDelay);
    }

    void LoadTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
}
