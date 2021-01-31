
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextWriter : MonoBehaviour
{
	public static TextWriter Instance;

	private List<TextWriterSingle> _textWriterSingle = new List<TextWriterSingle>();

	private void Awake()
	{
		Instance = this;
		
	}

	public static void WriteText_Static(string msg, float delayPerChar, Text uiText)
	{
		
		Instance.WriteText(msg, delayPerChar, uiText);
	}
	private void WriteText(string msg, float delayPerChar, Text uiText)
	{
		_textWriterSingle.Add(new TextWriterSingle(msg, delayPerChar, uiText));
	}

	private void Update()
	{
		for (int i = 0; i < _textWriterSingle.Count; i++)
		{
			bool destroyInstance = _textWriterSingle[i].Update();
			if (destroyInstance)
			{
				_textWriterSingle.RemoveAt(i);
				i--;
			}
		}
	}

	public class TextWriterSingle
	{

		private Text _uiText = null;
		private string _msg;
		private int _characterIndex;
		private float _delayPerChar;
		private float timer;

		public TextWriterSingle(string msg, float delayPerChar, Text uiText)
		{
			_msg = msg;
			_delayPerChar = delayPerChar;
			_uiText = uiText;
			_characterIndex = 0;
		}

		public bool Update()
		{
			timer -= Time.deltaTime;
			while (timer <= 0f)
			{
				timer += _delayPerChar;
				_characterIndex++;
				_uiText.text = _msg.Substring(0, _characterIndex);
				_uiText.text += "<color=#00000000>" + _msg.Substring(_characterIndex) + "</color>";

				if (_characterIndex < _msg.Length) continue;
				_uiText = null;
				_characterIndex = 0;
				return true;
			}

			return false;
		}
	}
}
