using UnityEngine;
using System.Collections;

/**
 * Cette classe permet de créer un rayon partant de la caméra en direction de la position du curseur dans l'environnement 3D.
 * L'objet portant se script peut saisir des objets, les manipuler et les déplacer grace au clique gauche de la souris.
 * Trois curseurs sont implémentés :
 * Un curseur cursorOff lorsqu'aucun objet manipulable (tag "Draggable") n'est détecté par le rayon.
 * Un curseur cursorDraggable lorsqu'un objet manipulable est détécté mais non saisi
 * Un curseur cursorDragged lorsqu'un obhet est saisi
**/
public class RayCasting : MonoBehaviour
{

	private float distanceToObj;	// Distance entre le personnage et l'objet saisi
	private Rigidbody attachedObject;	// Objet saisi, null si aucun objet saisi

	public const int RAYCASTLENGTH = 100;	// Longueur du rayon issu de la caméra


	public CursorMode cursorMode = CursorMode.Auto;
	public Vector2 hotSpot = new Vector2(16, 16);	// Offset du centre du curseur
	public Texture2D cursorOff, cursorDragged, cursorDraggable;	// Textures à appliquer aux curseurs

	void Start ()
	{
		distanceToObj = -1;
		Cursor.SetCursor (cursorOff, hotSpot, cursorMode);
		Cursor.visible = true;
	}

	void Update ()
	{
		// Le raycast attache un objet cliqué
		RaycastHit hitInfo;
		Ray ray = GetComponentInChildren<Camera>().ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay (ray.origin, ray.direction * RAYCASTLENGTH, Color.blue);
		bool rayCasted = Physics.Raycast (ray, out hitInfo, RAYCASTLENGTH);
        bool isDraggable = false;

        // If an object is hit.
		if (rayCasted)
		{
            // Draggable object.
            if (hitInfo.transform.CompareTag("Draggable"))
            {
                isDraggable = true;
            }

			if (Input.GetMouseButtonDown(0))    // L'utilisateur vient de cliquer
            {
                if (isDraggable)
                {
                    attachedObject = hitInfo.rigidbody;
                    attachedObject.isKinematic = true;
                    distanceToObj = hitInfo.distance;
                    Cursor.SetCursor(cursorDragged, hotSpot, cursorMode);
                }

                // Simulate the watering.
                if (hitInfo.transform.CompareTag("Soil"))
                {
                    // TODO: Changer ça pour vérifier qu'on tient bien un arrosoir par exemple.
                    hitInfo.collider.gameObject.GetComponent<SoilScript>().Water(0.1f);
                }
            }

            else if (Input.GetMouseButtonUp(0) && attachedObject != null)   // L'utilisateur relache un objet saisi
            {
                attachedObject.isKinematic = false;
                attachedObject = null;

                if (isDraggable)
                {
                    Cursor.SetCursor(cursorDraggable, hotSpot, cursorMode);
                }
                else
                {
                    Cursor.SetCursor(cursorOff, hotSpot, cursorMode);
                }
            }

            else if (Input.GetMouseButton(0) && attachedObject != null) // L'utilisateur continue la saisie d'un objet
            {
                attachedObject.MovePosition(ray.origin + (ray.direction * distanceToObj));

				if (Input.GetKeyDown (KeyCode.P)) {
					attachedObject.gameObject.transform.Rotate(new Vector3 (0, 2, 0));
				}
				if (Input.GetKeyDown (KeyCode.O)) {
					attachedObject.gameObject.transform.Rotate(new Vector3 (0, -5, 0));
				}
				if (Input.GetKeyDown (KeyCode.M)) {
					attachedObject.gameObject.transform.Rotate(new Vector3 (0, 0, 10));
				}
				if (Input.GetKeyDown (KeyCode.L)) {
					attachedObject.gameObject.transform.Rotate(new Vector3 (0, 0, -10));
				}
            }

            else  // L'utilisateur bouge la souris sans cliquer
            {
                if (isDraggable)
                {
                    Cursor.SetCursor(cursorDraggable, hotSpot, cursorMode);
                }
                else
                {
                    Cursor.SetCursor(cursorOff, hotSpot, cursorMode);
                }
            }
        }
	}
}
