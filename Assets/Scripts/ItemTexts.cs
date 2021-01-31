using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ItemTexts : MonoBehaviour
{
	public static Dictionary<Items, string> ItemTextDictionary = new Dictionary<Items, string>()
	{
		{Items.SweaterGreen,"green"},
		{Items.SweaterPurple,"purple"},
		{Items.SweaterRed,"red"},
		{Items.SweaterBlue,"blue"},
		{Items.SweaterLightGreen,"light green"},
		{Items.Sunflower,"sunflowers"},
		{Items.Rose,"roses"},
		{Items.Lily,"lilys"},
		{Items.HighHeelsTall,"I remember it clearly now. She was taller than me. She refused wearing heels, actually. I think she would have even wanted to be just a little bit smaller than she was. She always complained about getting neck aches because she had to bend downwards to kiss me, though I think most of that was just joking. I hope."},
		{Items.HighHeelsSmall,"I remember it clearly now: she was smaller than me. That’s why she loved wearing heels, I guess. But even then, she never was quite as tall as me. Once, she fell and broke her ankle quite badly. That day, she swore off high heels forever. That only lasted until my next mocking remark about how small she was, though. I couldn’t help it, she was just too adorable when she was pretending to be mad at me."},
		{Items.LeafletSunshine,"Sunshine"},
		{Items.LeafletSweety,"Sweety"},
		{Items.LeafletMuffin,"Muffin"},
		{Items.LeafletCookie,"Cookie"},
		{Items.LeafletAngel,"Angel"},
		{Items.LeafletMtheydy,"M\'theydy"},
		{Items.HeartBook,"tragic lovers in a misapproving world"},
		{Items.PotterBook,"a wizard or something "},
		{Items.SnailBook,"snails and how to keep them from eating your garden plants"},
		{Items.FlowerBook,"how to best care for your houseplants"},
		{Items.BallSport,"Opposite of me, she loved sports. She played basket ball in our local sports club and always tried to convince me to join too. I would have, for her sake, but I was terrible at sports, which she, eventually, understood. I always went to see her play though. Her incredibly swift movements gave her a great advantage, even against more experienced players."},
		{Items.BallNoSport,"She wasn’t very fond of sports. No, that’s an understatement. She hated it, actually. She told me once that, as a kid, she used to love it, despite never being quite good at it. A lack of encouragement from her later teachers, though, kind of took he fun of it away from her. I can recall now, that I always slowed down my walking pace for her."},
		{Items.CameraBraun,"warm brown"},
		{Items.CameraGreen,"bright green"},
		{Items.CameraBlue,"deep blue"},
	};

	[SerializeField] private Text _flowerText;
	[SerializeField] private Text _leafletText;
	[SerializeField] private Text _ballText;
	[SerializeField] private Text _cameraText;
	[SerializeField] private Text _bookText;
	[SerializeField] private Text _sweaterText;
	[SerializeField] private Text _shoesText;
	[SerializeField] public GameObject _book;
	[SerializeField] private Sprite _ball;
	[SerializeField] private Sprite _bookFlower;
	[SerializeField] private Sprite _bookHeart;
	[SerializeField] private Sprite _bookPotter;
	[SerializeField] private Sprite _bookSnail;
	[SerializeField] private Sprite _camera;
	[SerializeField] private Sprite _lily;
	[SerializeField] private Sprite _rose;
	[SerializeField] private Sprite _sunflower;
	[SerializeField] private Sprite _letter;
	[SerializeField] private Sprite _shoes;
	[SerializeField] private Sprite _blueSweater;
	[SerializeField] private Sprite _greenSweater;
	[SerializeField] private Sprite _lightGreenSweater;
	[SerializeField] private Sprite _purpleSweater;
	[SerializeField] private Sprite _redSweater;
	[SerializeField] private GameObject _sweaterIcon;
	[SerializeField] private GameObject _leafletIcon;
	[SerializeField] private GameObject _cameraIcon;
	[SerializeField] private GameObject _ballIcon;
	[SerializeField] private GameObject _flowerIcon;
	[SerializeField] private GameObject _bookIcon;
	[SerializeField] private GameObject _shoesIcon;

	public static Dictionary<Items, Sprite> ItemIconDictionary = new Dictionary<Items, Sprite>();

	private List<GhostData> _ghostDatas = new List<GhostData>();

	

	public void DisableAllTexts()
	{
		_flowerText.gameObject.SetActive(false);
		_leafletText.gameObject.SetActive(false);
		_ballText.gameObject.SetActive(false);
		_cameraText.gameObject.SetActive(false);
		_bookText.gameObject.SetActive(false);
		_sweaterText.gameObject.SetActive(false);
		_shoesText.gameObject.SetActive(false);
		
	}

	public void Start()
	{
		_ghostDatas.Add(new GhostData(Items.LeafletSunshine, Items.BallNoSport, Items.CameraBlue, Items.HighHeelsTall, Items.SweaterLightGreen, Items.PotterBook, Items.Sunflower));
		_ghostDatas.Add(new GhostData(Items.LeafletSweety, Items.BallSport, Items.CameraGreen, Items.HighHeelsSmall, Items.SweaterPurple, Items.FlowerBook, Items.Sunflower));
		_ghostDatas.Add(new GhostData(Items.LeafletMuffin, Items.BallNoSport, Items.CameraBraun, Items.HighHeelsTall, Items.SweaterRed, Items.SnailBook, Items.Rose));
		_ghostDatas.Add(new GhostData(Items.LeafletCookie, Items.BallSport, Items.CameraBlue, Items.HighHeelsSmall, Items.CameraGreen, Items.HeartBook, Items.Rose));
		_ghostDatas.Add(new GhostData(Items.LeafletAngel, Items.BallNoSport, Items.CameraGreen, Items.HighHeelsTall, Items.SweaterBlue, Items.HeartBook, Items.Rose));
		_ghostDatas.Add(new GhostData(Items.LeafletMtheydy, Items.BallSport, Items.CameraBraun, Items.HighHeelsSmall, Items.SweaterBlue, Items.PotterBook, Items.Lily));
		_ghostDatas.Add(new GhostData(Items.LeafletSunshine, Items.BallNoSport, Items.CameraGreen, Items.HighHeelsTall, Items.SweaterPurple, Items.HeartBook, Items.Sunflower));
		_ghostDatas.Add(new GhostData(Items.LeafletSweety, Items.BallSport, Items.CameraBraun, Items.HighHeelsSmall, Items.SweaterGreen, Items.FlowerBook, Items.Sunflower));
		_ghostDatas.Add(new GhostData(Items.LeafletMuffin, Items.BallNoSport, Items.CameraBlue, Items.HighHeelsTall, Items.SweaterBlue, Items.SnailBook, Items.Sunflower));
		_ghostDatas.Add(new GhostData(Items.LeafletCookie, Items.BallSport, Items.CameraBlue, Items.HighHeelsSmall, Items.SweaterBlue, Items.SnailBook, Items.Rose));
		_ghostDatas.Add(new GhostData(Items.LeafletAngel, Items.BallNoSport, Items.CameraBraun, Items.HighHeelsTall, Items.SweaterLightGreen, Items.FlowerBook, Items.Rose));
		_ghostDatas.Add(new GhostData(Items.LeafletMtheydy, Items.BallSport, Items.CameraBlue, Items.HighHeelsSmall, Items.SweaterPurple, Items.HeartBook, Items.Lily));
		_ghostDatas.Add(new GhostData(Items.LeafletSunshine, Items.BallNoSport, Items.CameraBraun, Items.HighHeelsTall, Items.SweaterGreen, Items.PotterBook, Items.Lily));
		_ghostDatas.Add(new GhostData(Items.LeafletSweety, Items.BallSport, Items.CameraGreen, Items.HighHeelsSmall, Items.SweaterBlue, Items.SnailBook, Items.Lily));
		_ghostDatas.Add(new GhostData(Items.LeafletMuffin, Items.BallNoSport, Items.CameraGreen, Items.HighHeelsTall, Items.SweaterGreen, Items.FlowerBook, Items.Lily));

		ItemIconDictionary.Add(Items.SweaterGreen, _greenSweater);
		ItemIconDictionary.Add(Items.SweaterBlue, _blueSweater);
		ItemIconDictionary.Add(Items.SweaterLightGreen, _lightGreenSweater);
		ItemIconDictionary.Add(Items.SweaterPurple, _purpleSweater);
		ItemIconDictionary.Add(Items.SweaterRed, _redSweater);
		ItemIconDictionary.Add(Items.HighHeelsSmall, _shoes);
		ItemIconDictionary.Add(Items.HighHeelsTall, _shoes);
		ItemIconDictionary.Add(Items.BallNoSport, _ball);
		ItemIconDictionary.Add(Items.BallSport, _ball);
		ItemIconDictionary.Add(Items.FlowerBook, _bookFlower);
		ItemIconDictionary.Add(Items.HeartBook, _bookHeart);
		ItemIconDictionary.Add(Items.SnailBook, _bookSnail);
		ItemIconDictionary.Add(Items.PotterBook, _bookPotter);
		ItemIconDictionary.Add(Items.Lily, _lily);
		ItemIconDictionary.Add(Items.Rose, _rose);
		ItemIconDictionary.Add(Items.Sunflower, _sunflower);
		ItemIconDictionary.Add(Items.LeafletAngel, _letter);
		ItemIconDictionary.Add(Items.LeafletCookie, _letter);
		ItemIconDictionary.Add(Items.LeafletMtheydy, _letter);
		ItemIconDictionary.Add(Items.LeafletMuffin, _letter);
		ItemIconDictionary.Add(Items.LeafletSweety, _letter);
		ItemIconDictionary.Add(Items.LeafletSunshine, _letter);
		ItemIconDictionary.Add(Items.CameraGreen, _camera);
		ItemIconDictionary.Add(Items.CameraBlue, _camera);
		ItemIconDictionary.Add(Items.CameraBraun, _camera);

		int index = Random.Range(0, 15);

		foreach (GameObject go in ItemManager.Items)
		{
			Interactable interactable = go.GetComponent<Interactable>();

			interactable.Book = _book;

			switch (interactable.BaseItem)
			{
				case BaseItems.Leaflet:
					interactable.Item = _ghostDatas[index]._leaflet;
					interactable._text = _leafletText;
					interactable.Icon = _leafletIcon;
					break;
				case BaseItems.Ball:
					interactable.Item = _ghostDatas[index]._ball;
					interactable._text = _ballText;
					interactable.Icon = _ballIcon;
					break;
				case BaseItems.Camera:
					interactable.Item = _ghostDatas[index]._camera;
					interactable._text = _cameraText;
					interactable.Icon = _cameraIcon;
					break;
				case BaseItems.Shoes:
					interactable.Item = _ghostDatas[index]._shoes;
					interactable._text = _shoesText;
					interactable.Icon = _shoesIcon;
					break;
				case BaseItems.Sweater:
					interactable.Item = _ghostDatas[index]._sweater;
					interactable._text = _sweaterText;
					interactable.Icon = _sweaterIcon;
					break;
				case BaseItems.Book:
					interactable.Item = _ghostDatas[index]._book;
					interactable._text = _bookText;
					interactable.Icon = _bookIcon;
					break;
				case BaseItems.Flower:
					interactable.Item = _ghostDatas[index]._flower;
					interactable._text = _flowerText;
					interactable.Icon = _flowerIcon;
					break;
			}
		}
	}

	public class GhostData
	{
		public Items _leaflet;
		public Items _ball;
		public Items _camera;
		public Items _shoes;
		public Items _sweater;
		public Items _book;
		public Items _flower;
		public GhostData(Items leaflet, Items ball, Items camera, Items shoes, Items sweater, Items book, Items flower)
		{
			_leaflet = leaflet;
			_ball = ball;
			_camera = camera;
			_shoes = shoes;
			_sweater = sweater;
			_book = book;
			_flower = flower;
		}
	}
}
