using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour
{

	public Texture2D handIcon;
	public int iconSize = 50;
	public float velocity = 10;
	public float maxObjectMass = 10;
	public float maxDistance = 15;
	public CharacterControl playerControlScript;
	private GameObject currentObject;
	private Vector3 objPos;
	private Vector3 objRot;
	private float bodyDrag;
	private float bodyAngularDrag;
	private bool moveMode;

	void FixedUpdate()
	{
		if (currentObject)
		{
			currentObject.GetComponent<Rigidbody>().AddForce(objPos * currentObject.GetComponent<Rigidbody>().mass * velocity);
			currentObject.GetComponent<Rigidbody>().AddTorque(objRot * velocity);
		}
	}

	void CurrentObjectTorque(Vector3 vect)
	{
		if (Input.GetAxis("Mouse ScrollWheel") > 0) objRot = Camera.main.transform.TransformDirection(vect);
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) objRot = Camera.main.transform.TransformDirection(-vect); else objRot = Vector3.zero;
	}

	void ResetCurrentObject()
	{
		Cursor.visible = true;
		currentObject.GetComponent<Rigidbody>().drag = bodyDrag;
		currentObject.GetComponent<Rigidbody>().angularDrag = bodyAngularDrag;
		currentObject.GetComponent<Rigidbody>().useGravity = true;
		currentObject = null;
	}

	void OnGUI()
	{
		if (currentObject)
		{
			Cursor.visible = false;
			Vector3 iconPos = Camera.main.WorldToScreenPoint(currentObject.transform.position);
			iconPos.y = Screen.height - iconPos.y;
			GUI.depth = 9999;
			GUI.Label(new Rect(iconPos.x, iconPos.y, iconSize, iconSize), handIcon);
		}
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			playerControlScript.enabled = !playerControlScript.enabled;
			Cursor.visible = !Cursor.visible;
		}
		if (!playerControlScript.enabled)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (Input.GetMouseButton(1))
				{
					if (hit.distance < maxDistance && currentObject == null && hit.rigidbody && hit.rigidbody.mass < maxObjectMass)
					{
						moveMode = true;
						currentObject = hit.transform.gameObject;
						currentObject.transform.position += new Vector3(0, 0.1f, 0);
						currentObject.GetComponent<Rigidbody>().useGravity = false;
						bodyDrag = currentObject.GetComponent<Rigidbody>().drag;
						bodyAngularDrag = currentObject.GetComponent<Rigidbody>().angularDrag;
						currentObject.GetComponent<Rigidbody>().drag = velocity / 3;
						currentObject.GetComponent<Rigidbody>().angularDrag = velocity / 3;
						Debug.Log("Выбран объект: " + hit.transform.gameObject.name);
					}
				}
				else if (currentObject)
				{
					ResetCurrentObject();
				}
			}
			else if (!Input.GetMouseButton(1) && currentObject)
			{
				ResetCurrentObject();
			}
			if (Input.GetMouseButtonDown(0)) moveMode = !moveMode;
			if (moveMode)
			{
				CurrentObjectTorque(Vector3.forward);
				objPos = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0);
				objPos = Camera.main.transform.TransformDirection(objPos);
			}
			else
			{
				CurrentObjectTorque(Vector3.right);
				objPos = new Vector3(Input.GetAxis("Mouse X"), 0, Input.GetAxis("Mouse Y"));
				objPos = Camera.main.transform.TransformDirection(objPos);
				objPos = new Vector3(objPos.x, 0, objPos.z);
			}
		}
	}
}