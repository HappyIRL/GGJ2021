using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerNPCCollision : MonoBehaviour
{
	[SerializeField] private float _playerRange;
	[SerializeField] private float _npcColliderRadius;

	private bool _isNearGhost;
	public static bool InInteraction;

	public static Action<NPC> OnNpcInteraction;

	public static NPC _currentNpc;

	private void Update()
	{
		if (NPC.Npcs.Count > 0)
		{
			foreach (NPC npc in NPC.Npcs)
			{
				if (Vector3.Distance(transform.position, npc.transform.position) < _playerRange + _npcColliderRadius)
				{
					_isNearGhost = true;
					_currentNpc = npc;
					break;
				}
				else
				{
					_isNearGhost = false;
				}
			}
		}
	}

	public void OnInteract()
	{
		if (_isNearGhost && !InInteraction)
		{
			OnNpcInteraction?.Invoke(_currentNpc);
			CharacterMovement.InInteraction = true;
			InInteraction = true;
		}
	}
}