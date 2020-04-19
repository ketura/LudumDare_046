using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedExit : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		ExitHandler.Instance.GracefulExit(8.0f);
	}

	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
		{
			ExitHandler.Instance.InstantExit();
		}
	}
}