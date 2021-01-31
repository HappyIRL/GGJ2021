using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class NPC : MonoBehaviour
{
	[SerializeField] private float _speed = 4f;
	private StateMachine _stateMachine = new StateMachine();
	private bool _hasWaypoint = false;
	private Vector3 _wayPoint;

	public bool _isLove = false;
	public string _correctGreeting = "";

	[SerializeField] private TMP_InputField _inputField;
	[SerializeField] private Text _textField;
	[SerializeField] private GameObject _textBubble;
	[SerializeField] private GameObject _answerButton;
	[SerializeField] private GameObject _leaveButton;
	[SerializeField] private GameObject _winningScreen;
	private SpriteRenderer _spriteRenderer;
	[SerializeField] private Sprite _spriteLeft;
	[SerializeField] private Sprite _spriteRight;
	[SerializeField] private ParticleSystem _pt;

	private List<string> _leaveStrings = new List<string>();

	public static List<NPC> Npcs = new List<NPC>();

	private void OnEnable()
	{
		PlayerNPCCollision.OnNpcInteraction += EnterTalkState;
	}

	private void OnDisable()
	{
		PlayerNPCCollision.OnNpcInteraction -= EnterTalkState;
	}

	private void Awake()
	{
		Npcs.Add(this);
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}
	private void Start()
    {
	    _stateMachine.CreateState("WanderingState", null, WanderingUpdate, null);
	    _stateMachine.CreateState("TalkingToPlayerState", TalkEnter, null, TalkExit);

		_leaveStrings.Add("I am sorry, what?");
		_leaveStrings.Add("I don't think we know each other.");
		_leaveStrings.Add("I don't know you!");
		_leaveStrings.Add("Excuse me?!");
		_leaveStrings.Add("Boo!");
	}

    private void Update()
    {
		_stateMachine.Update();
    }

    public void EnterTalkState(NPC npc)
    {
		if(npc == this)
			_stateMachine.TransitionTo("TalkingToPlayerState");
    }

    public void CheckForGreeting()
    {
		if (_inputField.text == _correctGreeting)
		{
			if (_isLove)
		    {
			    StopAllCoroutines();
				_answerButton.SetActive(false);
				_leaveButton.SetActive(false);
				_winningScreen.SetActive(true);
			}
		    else
		    {
			    DisplayRandomLeaveText();
		    }
		}
	    else
	    {
		    DisplayRandomLeaveText();
	    }
    }

    private void DisplayRandomLeaveText()
    {
	    _inputField.gameObject.SetActive(false);
	    _textField.gameObject.SetActive(true);
		TextWriter.WriteText_Static(_leaveStrings[Random.Range(0,_leaveStrings.Count)], 0.05f, _textField);
	    _answerButton.SetActive(false);
	    ReturnToWanderingAfterDelay(3);
    }

	private void TalkEnter()
	{
		DisplayEnterBubble();
		StartCoroutine(ReturnToWanderingAfterDelay(10f));
	}

	private IEnumerator ReturnToWanderingAfterDelay(float seconds)
	{
		yield return new WaitForSeconds(seconds);
		_stateMachine.TransitionTo("WanderingState");
	}

	public void ReturnToWanderingState()
	{
		_stateMachine.TransitionTo("WanderingState");
	}

	private void TalkExit()
	{
		_inputField.text = "";
		CharacterMovement.InInteraction = false;
		PlayerNPCCollision.InInteraction = false;
		StopAllCoroutines();
	    DisableEnterBubble();
    }

    private void DisplayEnterBubble()
    {
	    _inputField.gameObject.SetActive(true);
	    _answerButton.SetActive(true);
	    _leaveButton.SetActive(true);
	    _textField.gameObject.SetActive(false);
	    _textBubble.SetActive(true);
	}

    private void DisableEnterBubble()
    {
	    _textBubble.SetActive(false);
    }
	private void WanderingUpdate()
	{

		if (!_hasWaypoint)
		{
			_wayPoint = GetNextWaypoint();
			_hasWaypoint = true;
		}

		Vector3 waypointDirection = _wayPoint - transform.position;

		transform.Translate(waypointDirection.normalized * _speed * Time.deltaTime, Space.World);

		if (waypointDirection.normalized.x > 0)
		{
			_spriteRenderer.sprite = _spriteRight;
			_pt.transform.eulerAngles = new Vector3(0, 0, 90);
		}
		else
		{
			_spriteRenderer.sprite = _spriteLeft;
			_pt.transform.eulerAngles = new Vector3(0, 0, -90);
		}

	    if (Vector3.Distance(_wayPoint, transform.position) < 0.2)
	    {
		    _hasWaypoint = false;
	    }
	}

    private Vector3 GetNextWaypoint()
    {
	    return new Vector3(Random.Range(-49, 49), Random.Range(-49, 49), 0);
	}
}
