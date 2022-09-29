using UnityEngine;

public class TimedObject : MonoBehaviour
{
    [SerializeField] private float _timeLive;

    private void Update()
    {
        _timeLive -= Time.deltaTime;
        if (_timeLive <= 0)
        {
            Destroy(gameObject);
        }
    }
}
