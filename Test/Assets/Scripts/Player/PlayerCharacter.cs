using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerCharacter : MonoBehaviour
{
	public CharacterController CharacterController => _characterController;
	private CharacterController _characterController = null;

	public Transform HeadTransform => _headTransform;
	private Transform _headTransform = null;

	public Transform ViewTransform => _viewTransform;
	private Transform _viewTransform = null;


	public PlayerInput Input => _input;
	private PlayerInput _input = null;

	public PlayerMovement Movement => _movement;
	private PlayerMovement _movement = null;

	public PlayerFirstPerson FirstPerson => _firstPerson;
	private PlayerFirstPerson _firstPerson = null;

	public PlayerInteraction Interaction => _interaction;
	private PlayerInteraction _interaction = null;


	private void Start()
	{
		_characterController = GetComponent<CharacterController>();
		_headTransform = transform.Find("Head").GetComponent<Transform>();
		_viewTransform = _headTransform.Find("View").GetComponent<Transform>();

		_input = new PlayerInput();
		_movement = new PlayerMovement(this);
		_firstPerson = new PlayerFirstPerson(this);
		_interaction = new PlayerInteraction(this);
	}


	private void Update()
	{
		_characterController.Move(_movement.GetMoveVector() * Time.deltaTime);

		_headTransform.position = _firstPerson.GetHeadPosition();
		_headTransform.eulerAngles = _firstPerson.GetHeadEulerAngles();

		_viewTransform.position = _firstPerson.GetViewPosition();
		_viewTransform.localEulerAngles = _firstPerson.GetViewLocalEulerAngles();


		_interaction.Update();
	}
}