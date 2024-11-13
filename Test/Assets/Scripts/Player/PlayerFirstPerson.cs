using UnityEngine;


public class PlayerFirstPerson
{
	private PlayerCharacter _character = null;


	public Vector3 HeadPosition => _headPosition;
	private Vector3 _headPosition = Vector3.zero;

	public Vector2 HeadRotation => _headRotation;
	private Vector2 _headRotation = Vector2.zero;

	public Vector3 ViewRotation => _viewRotation;
	private Vector3 _viewRotation = Vector3.zero;


	public PlayerFirstPerson(PlayerCharacter character)
	{
		_character = character;
	}


	public Vector3 GetHeadPosition()
	{
		_headPosition = new Vector3
		(
			_character.transform.position.x,
			_character.transform.position.y + _character.CharacterController.height - _character.CharacterController.radius,
			_character.transform.position.z
		);

		return _headPosition;
	}


	public Vector3 GetHeadEulerAngles()
	{
		_headRotation += _character.Input.GetMouseVector() * 2f;
		_headRotation.x %= 360f;
		_headRotation.y = Mathf.Clamp(_headRotation.y, -90f, 90f);

		return new Vector3(-_headRotation.y, _headRotation.x, 0f);
	}


	public Vector3 GetViewPosition()
	{
		return _headPosition;
	}


	public Vector3 GetViewLocalEulerAngles()
	{
		float playerHorizontalSpeed = new Vector2(_character.CharacterController.velocity.x, _character.CharacterController.velocity.z).magnitude;

		if (!_character.CharacterController.isGrounded)
		{
			playerHorizontalSpeed *= 0f;
		}


		Vector3 targetViewRotation = Vector3.zero;
		targetViewRotation.y += Mathf.Sin(Time.time * 10f) * Mathf.Clamp01(playerHorizontalSpeed) * 0.5f;
		targetViewRotation.z += Mathf.Sin(Time.time * 5f) * Mathf.Clamp01(playerHorizontalSpeed) * 0.5f;
		_viewRotation = Vector3.Lerp(_viewRotation, targetViewRotation, 10f * Time.deltaTime);

		return new Vector3(-_viewRotation.y, _viewRotation.x, _viewRotation.z);
	}
}