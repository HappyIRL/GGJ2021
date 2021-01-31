using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Sweater : Interactable
{
	protected override void OnItemPickup(GameObject go)
	{
		base.OnItemPickup(go);
		TextWriter.WriteText_Static($"Whenever one of us was visiting the other, we’d leave something at their place, to remind them of us until we’d meet again. When I, one time, left my {ItemTexts.ItemTextDictionary[Item]} sweater for her, her smile could easily have brightened the entire world. Actually, to this day, she never gave it back.", 0.04f, _text);
	}
}
