using UnityEngine;

[RequireComponent(typeof(AIMove))]
public class Patrol : Task
{
	[SerializeField] private Transform[] _points;
	[SerializeField] private float _timeBetweenPoints = 3f;

	private AIMove _aiMove;
	private int _correctPointIndex = 0;
	private float _correctPointTime;

	public override void DoIt()
	{
		_aiMove.GoTo(_points[_correctPointIndex]);
	}
	protected override void Awake()
	{
		base.Awake();
		_aiMove = GetComponent<AIMove>();
		_aiMove.OnPoint.AddListener(NextPoint);
	}
	private void NextPoint()
	{
		if (_correctPointTime < _timeBetweenPoints)
		{
			_correctPointTime += Time.fixedDeltaTime;
			return;
		}
		_correctPointTime = 0;

		if (_correctPointIndex + 1 >= _points.Length)
		{
			_correctPointIndex = 0;
			return;
		}
		_correctPointIndex++;
	}
}
