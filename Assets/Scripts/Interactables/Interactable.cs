using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
	public BaseItems BaseItem;
	public Items Item;
	public Text _text;
	public GameObject Book;
	public GameObject Icon;

	public virtual void Start()
	{
	}

	public virtual void OnEnable()
	{
		PlayerItemCollision.OnItemCollsion += OnItemPickup;
	}

	public virtual void OnDisable()
	{
		PlayerItemCollision.OnItemCollsion -= OnItemPickup;
	}

	protected virtual void OnItemPickup(GameObject go)
	{
		if (go.GetComponent<Interactable>().Item == Item)
		{ 
			Image image = Icon.GetComponent<Image>();
			image.sprite = ItemTexts.ItemIconDictionary[Item];
			_text.gameObject.SetActive(true);
			Book.gameObject.SetActive(true);
			PlayerInventory.Instance.AddItemToInventory(Item);
		}
	}
}
