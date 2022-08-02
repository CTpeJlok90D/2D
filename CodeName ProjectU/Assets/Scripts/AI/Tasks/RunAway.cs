using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AIMove))]
public class RunAway : Task
{
	[SerializeField] private Transform _shelter;
	private AIMove _aiMove;

	public override void DoIt()
	{
		_aiMove.GoTo(_shelter);
	}
	public void SetShelter(Transform shelter)
    {
		_shelter = shelter;
	}
	protected override void Awake()
	{
		base.Awake();
		_aiMove = GetComponent<AIMove>();
	}
}
