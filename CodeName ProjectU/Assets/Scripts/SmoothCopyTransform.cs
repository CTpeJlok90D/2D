using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCopyTransform : CopyTransform
{
	[SerializeField] protected float SmoothStrenth = 0.01f;
	protected override void Update()
	{
		transform.position = new Vector3(
			x ? Vector3.MoveTowards(transform.position, _target.position, SmoothStrenth * Vector3.Distance(transform.position, _target.position)).x : transform.position.x,
			y ? Vector3.MoveTowards(transform.position, _target.position, SmoothStrenth * Vector3.Distance(transform.position, _target.position)).y : transform.position.y,
			z ? Vector3.MoveTowards(transform.position, _target.position, SmoothStrenth * Vector3.Distance(transform.position, _target.position)).z : transform.position.z
			);
	}
}
