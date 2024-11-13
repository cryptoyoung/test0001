using UnityEngine;


public class PlayerInput
{
	public Vector2 GetMouseVector()
	{
		return new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
	}


	public Vector2 GetMovementVector()
	{
		Vector2 movementVector = Vector2.zero;

		if (Input.GetKey(KeyCode.W))
			movementVector.y += 1f;
		if (Input.GetKey(KeyCode.S))
			movementVector.y -= 1f;
		if (Input.GetKey(KeyCode.D))
			movementVector.x += 1f;
		if (Input.GetKey(KeyCode.A))
			movementVector.x -= 1f;

		if (movementVector.magnitude > 0f)
			movementVector.Normalize();

		return movementVector;
	}


	public bool GetJump()
	{
		return Input.GetKeyDown(KeyCode.Space);
	}


	public bool GetUse()
	{
		return Input.GetKeyDown(KeyCode.E);
	}
}