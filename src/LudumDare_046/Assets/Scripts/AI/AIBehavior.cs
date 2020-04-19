using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehavior : MonoBehaviour
{

	protected WorldMap Map;

	// Start is called before the first frame update
	protected virtual void Start()
	{
		Map = WorldMap.Instance;
	}

	// Update is called once per frame
	void Update()
	{

	}

	public virtual void Behave(Creature creature)
	{

	}
}
