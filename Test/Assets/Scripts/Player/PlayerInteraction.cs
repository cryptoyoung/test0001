using UnityEngine;
using UnityEngine.TextCore.Text;


public class PlayerInteraction
{
	private PlayerCharacter _character = null;


	private Transform _takedPropTransform = null;


	public PlayerInteraction(PlayerCharacter character)
	{
		_character = character;
	}


	public void Update()
	{
		if (_character.Input.GetUse())
		{
			if (_takedPropTransform == null)
			{
				if (Physics.Raycast(_character.HeadTransform.position, _character.HeadTransform.forward, out RaycastHit hitInfo, 1.5f))
				{
					if (hitInfo.collider.CompareTag("PickableProp"))
					{
						_takedPropTransform = hitInfo.transform;
						_takedPropTransform.GetComponent<Rigidbody>().isKinematic = true;
					}
				}
			}
			else
			{
				_takedPropTransform.GetComponent<Rigidbody>().isKinematic = false;
				_takedPropTransform = null;
			}
		}


		if (_takedPropTransform != null)
		{
			_takedPropTransform.position = Vector3.Lerp(_takedPropTransform.position, _character.HeadTransform.position + _character.HeadTransform.forward, Time.deltaTime * 40f);
			_takedPropTransform.rotation = _character.HeadTransform.rotation;
		}


		Debug.Log($"{_takedPropTransform}");
	}
}