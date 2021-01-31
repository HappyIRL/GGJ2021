using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Leaflet : Interactable
{
	protected override void OnItemPickup(GameObject go)
	{
		base.OnItemPickup(go);
		TextWriter.WriteText_Static($"We regularly used to write each other letters. Postcards, when we were on vacation, yes, sure, but even if we just parted for so much as three days – a letter was almost guaranteed. I started addressing her with {ItemTexts.ItemTextDictionary[Item]} ironically, but it kind of stuck and at some point we adapted it in regular conversation.", 0.04f, _text);
	}
}
