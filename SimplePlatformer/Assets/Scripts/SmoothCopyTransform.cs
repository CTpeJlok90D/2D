using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCopyTransform : MonoBehaviour
{
	[SerializeField] protected Transform _target;
	[SerializeField] protected bool x = true;
	[SerializeField] protected bool y = true;
	[SerializeField] protected bool z = false;
	[SerializeField] protected float SmoothStrenth = 0.01f;
	private void Update()
	{
		Vector3 offcet = Vector3.MoveTowards(transform.position, _target.position, SmoothStrenth * Vector3.Distance(transform.position, _target.position));
		transform.position = new Vector3(
			x ? offcet.x : transform.position.x,
			y ? offcet.y : transform.position.y,
			z ? offcet.z : transform.position.z
			);
	}
}
