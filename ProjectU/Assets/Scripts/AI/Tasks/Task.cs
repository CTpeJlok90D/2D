using UnityEngine;

[RequireComponent(typeof(AI))]
public abstract class Task : MonoBehaviour
{
	[SerializeField] private int _priority = 1;
	private AI _ai;

	public const int MaxPriority = 100;
	public const int MinPriority = -100;

	public int Priority => _priority;

	protected virtual void Awake()
	{
		_ai = GetComponent<AI>();
	}

	public abstract void DoIt();

	public void AddPriority(int value)
	{
		_priority = Mathf.Clamp(_priority + value, MinPriority, MaxPriority);
		_ai.GetNextTask();
	}
    private void OnValidate()
    {
		_priority = Mathf.Clamp(_priority, MinPriority, MaxPriority);
    }
}
