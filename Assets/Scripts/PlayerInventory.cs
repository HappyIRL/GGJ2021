using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public enum Items
{
	SweaterGreen,
	SweaterPurple,
	SweaterRed,
	SweaterBlue,
	SweaterLightGreen,
	Sunflower,
	Rose,
	Lily,
	HighHeelsTall,
	HighHeelsSmall,
	LeafletSunshine,
	LeafletSweety,
	LeafletMuffin,
	LeafletCookie,
	LeafletAngel,
	LeafletMtheydy,
	HeartBook,
	PotterBook,
	SnailBook,
	FlowerBook,
	BallSport,
	BallNoSport,
	CameraBraun,
	CameraGreen,
	CameraBlue
}

public enum BaseItems
{
	Sweater,
	Flower,
	Shoes,
	Leaflet,
	Book,
	Ball,
	Camera
}
public class PlayerInventory : MonoBehaviour
{
	public static PlayerInventory Instance;
	private static bool _isInstanceSet = false;

	private List<Items> CollectedItems = new List<Items>();

	public void Awake()
	{
		if (!_isInstanceSet)
		{
			Instance = this;
			_isInstanceSet = true;
		}
		else
		{
			Destroy(this);
		}
	}

	public void AddItemToInventory(Items item)
	{
		CollectedItems.Add(item);
		Debug.Log($"Added {item} to List");
	}
}
