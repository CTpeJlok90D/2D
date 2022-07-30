using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Senseorgans))]
public class AI : MonoBehaviour
{
	[SerializeField] private Task[] _tasks;

	private Senseorgans _senseorgans;
	private Task _correctTask;

	public void GetNextTask()
	{
		System.Random random = new System.Random(Mathf.RoundToInt(Time.time));
		List<Task> pryorityTasks = GetMaxPryorityTasks();
		int randomValue = random.Next(0, pryorityTasks.Count);
		_correctTask = pryorityTasks[randomValue];
	}
	private void Awake()
	{
		GetNextTask();
		_senseorgans = GetComponent<Senseorgans>();
	}
	private void FixedUpdate()
	{
		_correctTask.DoIt();
	}

	private List<Task> GetMaxPryorityTasks()
	{
		int maxPryority = -101;
		foreach (Task task in _tasks)
		{
			maxPryority = Mathf.Max(maxPryority, task.Priority);
		}
		List<Task> result = new();
		foreach (Task task in _tasks)
		{
			if (task.Priority == maxPryority)
			{
				result.Add(task);
			}
		}
		return result;
	}
}
