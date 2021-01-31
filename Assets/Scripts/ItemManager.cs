using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemManager : MonoBehaviour
{
	[SerializeField] private List<GameObject> _prefabItems = new List<GameObject>();

	private List<Vector2> _quadrantsA = new List<Vector2>() {new Vector2(-49,18), new Vector2(-16, 18), new Vector2(18, 18), new Vector2(-49, -16), new Vector2(17, -16), new Vector2(-49, -49), new Vector2(-17, -49), new Vector2(17, -49) };
	private List<Vector2> _quadrantsB = new List<Vector2>() { new Vector2(-18, 49), new Vector2(17, 49), new Vector2(49, 49), new Vector2(-17, 16), new Vector2(49, 17), new Vector2(-17, -18), new Vector2(16, -17), new Vector2(49, -17) };

	public static List<GameObject> Items = new List<GameObject>();



	private void Awake()
	{
		SpawnItems();
	}

	private void SpawnItems()
	{
		foreach (GameObject prefab in _prefabItems)
		{
			int index = Random.Range(0, _quadrantsA.Count);
			Vector2 quadrantA = _quadrantsA[index];
			Vector2 quadrantB = _quadrantsB[index];
			_quadrantsA.RemoveAt(index);
			_quadrantsB.RemoveAt(index);

			Items.Add(Instantiate(prefab, new Vector3(Random.Range(quadrantA.x, quadrantB.x), Random.Range(quadrantA.y, quadrantB.y), 0), Quaternion.identity));
		}
	}
}
