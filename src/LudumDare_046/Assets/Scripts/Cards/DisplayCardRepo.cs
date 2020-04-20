using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class DisplayCardRepo : Singleton<DisplayCardRepo>
{
	public Sprite GeneIcon;
	public Sprite PartIcon;
	public Sprite BlessingIcon;

	public float GeneTextSize = 36;
	public float PartTextSize = 20;
	public float BlessingTextSize = 20;
}
