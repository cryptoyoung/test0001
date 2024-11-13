using UnityEngine;


public class PlayerMovement
{
	private PlayerCharacter _character = null;


	public float WalkSpeed = 2f;
	public float JumpHeight = 4f;
	public float LocalGravity = -9.81f;

	public float VerticalVector => _verticalVector;
	private float _verticalVector = 0f;

	public Vector2 TargetHorizontalVector => _targetHorizontalVector;
	private Vector2 _targetHorizontalVector = Vector2.zero;

	public Vector2 HorizontalVector => _horizontalVector;
	private Vector2 _horizontalVector = Vector2.zero;


	public PlayerMovement(PlayerCharacter character)
	{
		_character = character;
	}


	public Vector3 GetMoveVector()
	{
		if (_character.CharacterController.isGrounded)
		{
			_verticalVector = LocalGravity;

			if (_character.Input.GetJump())
			{
				_verticalVector = JumpHeight;
			}

			_targetHorizontalVector = Quaternion.Euler(x: 0f, y: 0f, z: -_character.FirstPerson.HeadRotation.x) * _character.Input.GetMovementVector() * WalkSpeed;
		}
		else
		{
			_verticalVector += LocalGravity * Time.deltaTime;
		}


		_horizontalVector = Vector2.MoveTowards(_horizontalVector, _targetHorizontalVector, Time.deltaTime * 40f);

		return new Vector3(_horizontalVector.x, _verticalVector, _horizontalVector.y);
	}
}