using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIMove),typeof(AIShoot))]
public class AIPlaceHolder : MonoBehaviour
{
	[SerializeField] private bool Shooting;
	[SerializeField] private bool Moving;
	[SerializeField] private Transform _targetToMove;
	[SerializeField] private Transform _targetToShoot;

    private AIMove _aiMove;
    private AIShoot _aiShoot;

	public void SetShoot(bool value)
	{
		Shooting = value;
	}
	
	private void Awake()
	{
		_aiMove = GetComponent<AIMove>();
		_aiShoot = GetComponent<AIShoot>();
	}
	void FixedUpdate()
    {
		if (Moving) 
		{
			_aiMove.GoTo(_targetToMove); 
		}
		if (Shooting)
		{
			_aiShoot.Attack(_targetToShoot); 
		}
    }
}
