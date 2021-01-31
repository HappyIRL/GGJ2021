using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Book : Interactable
{
	protected override void OnItemPickup(GameObject go)
	{
		base.OnItemPickup(go);
		TextWriter.WriteText_Static($"I can recall that, one day, when it was raining outside, we cuddled up under a blanket together and she read me her favorite book. I must admit, I can’t remember much of the story, but it was something about {ItemTexts.ItemTextDictionary[Item]}. That was the day I started loving rain.", 0.04f, _text);
	}
}
