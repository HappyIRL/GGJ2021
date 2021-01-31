using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
	[SerializeField] private ItemTexts _itemTexts;
	public void OnClick_CheckForGreeting()
	{
		PlayerNPCCollision._currentNpc.CheckForGreeting();
	}
	public void OnClick_StopTalking()
	{
		PlayerNPCCollision._currentNpc.ReturnToWanderingState();
	}

	public void OnClick_ClosePage()
	{
		_itemTexts._book.SetActive(false);
		_itemTexts.DisableAllTexts();
	}

	public void OnClick_Restart()
	{
		Application.Quit();
	}
}
