using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Flower : Interactable
{
	protected override void OnItemPickup(GameObject go)
	{
		base.OnItemPickup(go);
		TextWriter.WriteText_Static(
			$"I remember {ItemTexts.ItemTextDictionary[Item]} being her favorite. I never quite understood why, but she liked them, so I did too. I bought them for her birthday every year. They never lived longer than a few days though; I guess we both weren’t the best at keeping things alive. Pathetic, isn’t it?",
			0.04f, _text);
	}
}
