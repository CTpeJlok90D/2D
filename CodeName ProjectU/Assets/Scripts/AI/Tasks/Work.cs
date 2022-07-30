using UnityEngine;

[RequireComponent(typeof(AIMove))]
public class Work : Task
{
	[SerializeField] private Transform _workPosition;
	[SerializeField] private GameObject _visualWork;

	private AIMove _aiMove;
	public override void DoIt()
	{
		_aiMove.SetTarget(_workPosition);
		_visualWork.SetActive(_aiMove.IsOnPosition);

		if (_aiMove.IsOnPosition)
		{
			return;
		}
		_aiMove.GoTo();
	}
	protected override void Awake()
	{
		base.Awake();
		_aiMove = GetComponent<AIMove>();
	}
}
