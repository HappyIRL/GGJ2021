using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Camera : Interactable
{
	protected override void OnItemPickup(GameObject go)
	{
		base.OnItemPickup(go);
		TextWriter.WriteText_Static($"She always took her camera with her, wherever she went. The thing was, though, that always being the photographer made that she never was to be seen in any photos herself. That’s why I, one day, convinced her to let me take a photo of her. I experimented a bit, to finally get a great close up shot of just her eyes. I will never forget their incredible {ItemTexts.ItemTextDictionary[Item]}.", 0.04f, _text);
	}
}
