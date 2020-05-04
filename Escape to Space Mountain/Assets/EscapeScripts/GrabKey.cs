using UnityEngine;
using System.Collections;

public class GrabKey : MonoBehaviour // This Scrip Needs MoveKey Script on all "moveable Objects".

{
    
	//

	private RaycastHit ObjectHit;
	private int Layermask = (1 << 9) + (1 << 0);
	private int LayervalueInt1;
	private int LayervalueInt2;
	private Camera RaycastOrigin;

	//Change layers to hit below new ones can be add using same format.

	public string ChangeRayHitLayer1 = "MoveableObjects";
	public string ChangeRayHitLayer2 = "Default";

	//Change Find the player tag refference below

	public GameObject FindPlayer;
	public string ChangeFindPlayerSearchTag = "MainPlayer";

	// change raycast origin headcam tag below

	public GameObject HeadCam;
	public string ChangeHeadCamSearchTag = "HeadCam";

	// control system for MoveObject Below

	private float Timer1 = 0.0f;
	private float Timer2 = 0.0f;

	//

	public GameObject Targetfloat;
	public bool CorrectObject = false;
	public bool CorrectReply = false;
	public string ObjectReplyID = "";
	public string ObjectRayID = "";
	public string EqualID = "";
	public float ObjectDistance = 0.0f;

	//

	private bool Timer1Done = false;
	private bool Timer2Done = false;
	private bool ToggleObjectON = false;
	//

	public bool Rayhit = false;
	public bool Grab = false;
	public bool isGrabbed = false;
	public bool GrabToggle = false;
	public bool ObjectHeld = false;
	public bool inCameraView = false;
	public bool inCameraViewOveride = false;
	public bool WithinRange = false;
	public bool WithinRangeOveride = false;

	//

	public float Raylength = 500.0f;
	public float MaxGrabDistance = 5.0f;
	public float TimeToWait = 0.05f;

	public Vector3 ScreenPoint = new Vector3(0.0f, 0.0f, 0.0f);


	// Change Controls Below at = keycode.Newkey;

	public KeyCode BindGrabToggle = KeyCode.F;


	// Use this for initialization
	void Start()

	{

		//Find the Player Code Below

		FindPlayer = GameObject.FindGameObjectWithTag(ChangeFindPlayerSearchTag);

		this.transform.parent = FindPlayer.transform;

		// Layers you can add more here

		LayervalueInt1 = LayerMask.NameToLayer(ChangeRayHitLayer1);


		LayervalueInt2 = LayerMask.NameToLayer(ChangeRayHitLayer2);

		// Binary adding of layers. just add another + sign and ( same format )

		Layermask = (1 << LayervalueInt1) + (1 << LayervalueInt2);

		//Headcam Location

		HeadCam = GameObject.FindGameObjectWithTag(ChangeHeadCamSearchTag);

		RaycastOrigin = HeadCam.GetComponent<Camera>();

	}

	// Update is called once per frame
	void Update()

	{

		//Code to log Ray ID to EqualID and set to Targetfloat

		{

			if (Grab == true)

				EqualID = ObjectRayID;
			Targetfloat = GameObject.Find(EqualID);
		};

		//Code for Correct Object Check.

		{

			if (Targetfloat == null);
            else

			{

				if (EqualID == ObjectRayID)

					CorrectObject = true;

				else

					CorrectObject = false;

			}

		};

		//Code for Correct Reply Check

		{

			if (Targetfloat == null)

				CorrectReply = false;

			else

			{

				if (EqualID == ObjectReplyID)

					CorrectReply = true;

				else

					CorrectReply = false;

			}

		};

		//Code to call the Object ID below 

		{

			if (isGrabbed == true)

			{

				if (CorrectObject == true)

					ObjectReplyID = Targetfloat.GetComponent<MoveKey>().ObjectID;


			}

		}

		//

		{

			if (GrabToggle == false)
				if (isGrabbed == false)

					ObjectReplyID = null;

		};

		//AdjView input code below

		{

			if (Input.GetKey(BindGrabToggle))

				Grab = true;

		};

		//

		{

			if (Input.GetKeyUp(BindGrabToggle))

				Grab = false;

		};

		//isGrabbed Input code Below

		{

			if (Grab == true)
				if (Rayhit == true)
					if (CorrectReply == CorrectObject)

						isGrabbed = true;
		};

		//

		{

			if (Grab == false)

				isGrabbed = false;

		};

		//Code to Trigger Object to interact when Object isgrabbed. 

		{

			if (isGrabbed == true)


			{

				EqualID = ObjectRayID;
				Targetfloat = GameObject.Find(EqualID);
				ToggleObjectON = (Targetfloat.GetComponent<MoveKey>().PlayerGrabbed = true);

			}

			else

				ToggleObjectON = false;

		};

		//Code to know if Object is Held

		{

			if (EqualID == null)

				ObjectHeld = false;

			else

			{

				if (CorrectReply == true)
					if (GrabToggle == true)

						ObjectHeld = true;

			}

		};

		//Raycast and Rayhit Code Below

		{
			if (Grab == true)

			{

				RaycastOrigin = HeadCam.GetComponent<Camera>();


				Debug.DrawRay(RaycastOrigin.transform.position, RaycastOrigin.transform.forward * Raylength, Color.green, 0.5f);

				if (Physics.Raycast(RaycastOrigin.transform.position, RaycastOrigin.transform.forward, out ObjectHit, Raylength, Layermask))

				{

					Rayhit = true;

					ObjectRayID = (ObjectHit.collider.name);

					ObjectDistance = (ObjectHit.distance);

					Debug.DrawRay(RaycastOrigin.transform.position, RaycastOrigin.transform.forward * Raylength, Color.red, 0.5f);


				}

				else

				{

					if (GrabToggle == false)

						Rayhit = false;

				}

			}
		};


		//Raycast Check Distance when toggled Code below

		{

			if (GrabToggle == true)


			{

				RaycastOrigin = HeadCam.GetComponent<Camera>();


				Debug.DrawRay(RaycastOrigin.transform.position, RaycastOrigin.transform.forward * Raylength, Color.green, 0.5f);

				{

					if (Physics.Raycast(RaycastOrigin.transform.position, RaycastOrigin.transform.forward, out ObjectHit, Raylength, Layermask))

					{

						ObjectDistance = (ObjectHit.distance);

						ObjectRayID = (ObjectHit.collider.name);

						Debug.DrawRay(RaycastOrigin.transform.position, RaycastOrigin.transform.forward * Raylength, Color.red, 0.5f);

						{

							if (ObjectRayID == EqualID)

								Rayhit = true;

							else

								Rayhit = false;

						}

					}

					else

						if (Grab == false)

						Rayhit = false;

				}

			}

		};

		//

		{

			if (GrabToggle == false)
				if (Grab == false)

					Rayhit = false;

		};

		//Code to reset distance Below

		{

			if (Rayhit == false)

				ObjectDistance = 0.0f;

		};

		//Within Range Input Code below

		{

			if (ObjectDistance <= MaxGrabDistance)

				WithinRange = true;

		};

		//

		{

			if (ObjectDistance >= MaxGrabDistance)

				WithinRange = false;

		};

		//Code to tell WithinRange false at 0 Below

		{

			if (ObjectDistance <= 0.0f)

				WithinRange = false;

		};

		//Code to Check if Object in camera View Below

		{

			if (Targetfloat == null);

			else

			if (GrabToggle == true)

			{

				if (ObjectHeld == true)

				{

					ScreenPoint = Camera.current.WorldToViewportPoint(Targetfloat.gameObject.transform.position);

					if (ScreenPoint.z > 0 && ScreenPoint.x > 0 && ScreenPoint.x < 1 && ScreenPoint.y > 0 && ScreenPoint.y < 1)

						inCameraView = true;

					else

						inCameraView = false;

				}

				else

					ScreenPoint = new Vector3(0.0f, 0.0f, 0.0f);

			}

			else

				ScreenPoint = new Vector3(0.0f, 0.0f, 0.0f);

		};

		//GrabToggle On Input code Below

		{

			if (GrabToggle == false)
				if (Grab == true)
					if (Timer2Done == false)

						Timer1 += Time.deltaTime;

		};

		//

		{

			if (Timer1 >= TimeToWait)
				if (Rayhit == true)

				{

					GrabToggle = true;

					Timer1Done = true;

				}

		};

		//GrabToggle Off code Below

		{

			if (Grab == true)
				if (GrabToggle == true)
					if (Timer1Done == false)

						Timer2 += Time.deltaTime;

		};

		//

		{

			if (Timer2 >= TimeToWait)

			{

				GrabToggle = false;

				Timer2Done = true;

			}

		};

		//GrabToggle Reset Timer's Code Below

		{

			if (Grab == false)

			{

				Timer1Done = false;

				Timer2Done = false;

				Timer1 = 0.0f;

				Timer2 = 0.0f;

			}

		};

        
		//Code to Reset ID's below
        
		{

			if (GrabToggle == false)
				if (Grab == false)
				{

					EqualID = null;
					ObjectRayID = null;
					ObjectReplyID = null;
					Targetfloat = null;
					WithinRange = false;
					ObjectHeld = false;
					CorrectReply = false;
					CorrectObject = false;
					Rayhit = false;
					inCameraView = false;

				}

		};

		//More Resets

		{

			if (ObjectHeld == true)
				if (CorrectReply == false)

					GrabToggle = false;


		};

		//

		{

			if (ObjectHeld == true)
				if (CorrectReply == false)

					GrabToggle = false;


		};

		//Code to reset object held if targetfloat null

		{

			if (ObjectHeld == true)
				if (EqualID == null)

					ObjectHeld = false;

		};

		//Code to Reset Grabtoggle if leaves CameraView unless its overidden

		{

			if (inCameraViewOveride == false)
				if (ObjectHeld == true)
					if (inCameraView == false)

						GrabToggle = false;

		};

		//Code to reset Grabtoggle if it is in view but leaves maxdistance unless its overiden

		{

			if (WithinRangeOveride == false)
				if (ObjectHeld == true)
					if (inCameraView == true)
						if (WithinRange == false)

							GrabToggle = false;

		};

		//Code to Stop Incorrect Rayhit from logging to Targetfloat and staying after looking away.

		{

			if (GrabToggle == true)
				if (CorrectReply == false)
					if (isGrabbed == false)
						if (ObjectHeld == false)
							if (WithinRange == false)
								if (inCameraView == false)

									GrabToggle = false;

		};

		//Code to Reset when Rayhit Overshoots while holding button continuously down and Values Get triggered on, below.

		{

			if (isGrabbed == true)

			{

				if (EqualID == null)

				{

					EqualID = ObjectRayID;
					Targetfloat = GameObject.Find(EqualID);

				}

				else

				{

					if (CorrectReply == false)

					{

						Targetfloat = null;
						GrabToggle = false;
						CorrectReply = false;
						CorrectObject = false;
						ObjectHeld = false;
						ObjectReplyID = null;
						ObjectRayID = null;
						Rayhit = false;

					}

				}

			}

		};

		//Code to Keep flashing Object ID from the object.

		{

			if (GrabToggle == true)

			{

				if (CorrectObject == true)

					ObjectReplyID = Targetfloat.GetComponent<MoveKey>().ObjectID;

				else

				{

					if (isGrabbed == false)

						ObjectReplyID = null;

				}

			}

		};

		//

		{

			if (GrabToggle == false)
				if (Grab == false)

					ObjectReplyID = null;

		};

		//Script Complete .Hare Krsna enjoy.




	}
}
