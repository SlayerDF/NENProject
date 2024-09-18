using Cysharp.Threading.Tasks;
using Player;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Serialized Fields

    [SerializeField]
    private PlayerInput playerInput;

    [SerializeField]
    private PlayerAnimation playerAnimation;

    [SerializeField]
    private Transform visibilityChecker;

    [SerializeField]
    private BossBrain bossBrain;

    #endregion

    private bool killed;

    public Transform VisibilityChecker => visibilityChecker;

    #region Event Functions

    private void FixedUpdate()
    {
        playerInput.DashEnabled = bossBrain.CurrentState != BossBrain.State.FollowPlayer;
    }

    private void OnEnable()
    {
        LevelState.AlertChanged += OnAlertChanged;
    }

    private void OnDisable()
    {
        LevelState.AlertChanged -= OnAlertChanged;
    }

    #endregion

    private void OnAlertChanged(float value)
    {
        if (value >= 1)
        {
            Kill();
        }
    }

    public void Kill()
    {
        if (killed)
        {
            return;
        }

        killed = true;
        playerInput.MovementEnabled = false;
        playerAnimation.OnDeath();

        playerAnimation.WaitAnimationEnd(PlayerAnimation.Death, 0).ContinueWith(SceneLoader.RestartLevel);
    }
}
