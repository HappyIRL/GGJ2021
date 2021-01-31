using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
	private Vector2 _moveDirection;
	private Vector2 _xBoarder = new Vector2(49, -49);
	private Vector2 _yBoarder = new Vector2(49, -49);

	private SpriteRenderer _spriteRenderer;
	[SerializeField] private Sprite _spriteLeft;
	[SerializeField] private Sprite _spriteRight;
	[SerializeField] private ParticleSystem _pt;

	public static bool InInteraction = false;

	private float _speed = 10f;

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		transform.position += new Vector3(_moveDirection.x, _moveDirection.y, 0) * Time.deltaTime  * _speed;

		transform.position = new Vector3(Mathf.Clamp(transform.position.x, _xBoarder.y, _xBoarder.x),
			Mathf.Clamp(transform.position.y, _yBoarder.y, _yBoarder.x), 0);
	}

	public void OnMove(InputValue inputValue)
	{
		if (InInteraction)
		{
			_moveDirection.x = 0;
			_moveDirection.y = 0;
			return;
		}

		_moveDirection = inputValue.Get<Vector2>();

		if (_moveDirection.x > 0)
		{
			_moveDirection.x = 1;
			_spriteRenderer.sprite = _spriteRight;
			_pt.transform.eulerAngles = new Vector3(0, 0, 90);
		}

		if (_moveDirection.x < 0)
		{
			_moveDirection.x = -1;
			_spriteRenderer.sprite = _spriteLeft;
			_pt.transform.eulerAngles = new Vector3(0, 0, -90);
		}

		if (_moveDirection.y > 0)
		{
			_moveDirection.y = 1;
		}

		if (_moveDirection.y < 0)
		{
			_moveDirection.y = -1;
		}
	}
}
