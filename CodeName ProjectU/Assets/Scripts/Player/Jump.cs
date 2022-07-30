using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private AnimationCurve _hightAnimation;
    [SerializeField] private AnimationCurve _timeAmimation;
    [SerializeField] private float _length;
    [SerializeField] private float _duraction;

    public void PlayAnimation(Transform player, float duraction)
    {
        DoAnimation(player, duraction);
    }
    
    private void Jumping()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            PlayAnimation(transform, _duraction);
        }
    }

    private void DoAnimation(Transform player, float during)
    {
        float correctTime = 0;
        float progress = 0;

        Vector2 StartPosition = player.position;

        while (progress < 1)
        {
            correctTime += Time.deltaTime;
            progress = correctTime / during;

            player.position = StartPosition + new Vector2(0, _hightAnimation.Evaluate(progress));

            player.localScale = new Vector2(0, _timeAmimation.Evaluate(progress));
        }
    }
}
