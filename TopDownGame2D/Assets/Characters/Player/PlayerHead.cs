using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{ 
    private void Update()
    {
        LookAtMouse();
    }

    private void LookAt(Vector2 position)
    {
        transform.up = position - (Vector2)transform.position;
    }
    private void LookAtMouse()
    {
        LookAt(WorldMouse.Position);
    }
}
