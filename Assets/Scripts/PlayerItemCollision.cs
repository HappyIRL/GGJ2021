using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerItemCollision : MonoBehaviour
{
	[SerializeField] private Transform _playerTransform;
	[SerializeField] private float _playerRange;
	[SerializeField] private float _itemColliderRadius;

	public static Action<GameObject> OnItemCollsion;

	private void Update()
	{
		if (ItemManager.Items.Count > 0)
		{
			foreach (GameObject item in ItemManager.Items)
			{
				if (Vector3.Distance(_playerTransform.position, item.transform.position) < _playerRange + _itemColliderRadius)
				{
					OnItemCollsion?.Invoke(item);
					ItemManager.Items.Remove(item);
					Destroy(item);
					break;
				}
			}
		}
	}
}
