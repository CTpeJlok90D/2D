using UnityEngine;

public class GroundCheker : MonoBehaviour
{
    private bool _onGround = true;
    public bool OnGround => _onGround;

    private void OnTriggerStay2D(Collider2D other) 
    {
        _onGround = true;   
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _onGround = false;
    }
}
