using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIMove),typeof(AIShoot))]
public class AIPlaceHolder : MonoBehaviour
{
    private AIMove _aiMove;
    private AIShoot _aiShoot;
	
	private void Awake()
	{
		_aiMove = GetComponent<AIMove>();
		_aiShoot = GetComponent<AIShoot>();
	}
	void FixedUpdate()
    {
		_aiMove.GoToTarget();
		_aiShoot.Aim();
    }
}
