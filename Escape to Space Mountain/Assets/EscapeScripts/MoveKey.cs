using UnityEngine;
using System.Collections;

public class MoveKey : MonoBehaviour //This Script Needs GrabKey script on player to link for the called player bools.

{

	//
    


	//

	public GameObject FindPlayer;
	public string ChangeFindPlayerTag = "MainPlayer";

	public string ObjectID = "";
	public string CheckRayhitID = "";
	public string CheckEqualID = "";

	//

	public bool PlayerGrabbed = false;
	private bool isPlayerGrabing = false;

	//

	public bool CorrectID = false;
	public bool isObjectHeld = false;
	public bool ObjectActivated = false;

	//

	public float SpeedH = 3.0f;// Delete all these axis inputs unless you would like to use them. change to what u want.
	public float SpeedV = 3.0f;
	public float MoveSpeed = 0.5f;
	public float Haxis = 0.0f;
	public float Vaxis = 0.0f;

	public float yaw = 0.0f;
	public float pitch = 0.0f;

	public Vector3 MoveDirection = new Vector3(0.0f, 0.0f, 0.0f); // some basic vectors to flash for movement when actived.
	public Vector3 ObjectRotation = new Vector3(0.0f, 0.0f, 0.0f);
	public Vector3 ObjectMove = new Vector3(0.0f, 0.0f, 0.0f);
	//

	// Use this for initialization
	void Start()

	{

		//FindPlayer code Below

		FindPlayer = GameObject.FindWithTag(ChangeFindPlayerTag);

		//Find Object ID Code Below

		ObjectID = this.transform.root.gameObject.name;

		//Object Location input

		ObjectMove = this.gameObject.transform.root.position;

		//Axis load code below

		yaw += SpeedH * Input.GetAxis("Mouse X");
		pitch -= SpeedV * Input.GetAxis("Mouse Y");
		Haxis = Input.GetAxis("Horizontal");
		Vaxis = Input.GetAxis("Vertical");


	}

	// Update is called once per frame
	void Update()


	{

		//Main Code Below Here



		//Some basic movement position grabs Below delete or change if not what you want.

		MoveDirection = FindPlayer.transform.position;


		ObjectRotation = FindPlayer.transform.rotation.eulerAngles;



		Vector3 MoveDirection2 = FindPlayer.transform.TransformDirection(MoveDirection);
		Vector3 ObjectRotaion2 = this.gameObject.transform.rotation.eulerAngles;
		Vector3 ZeroRotaion = new Vector3(0.0f, 0.0f, 0.0f);









		//IsPlayerGrabbing Code.

		{

			if (PlayerGrabbed == true)

                isPlayerGrabing = FindPlayer.GetComponent<GrabKey>().isGrabbed;

			else

				isPlayerGrabing = false;

		}

		//

		{

			if (isPlayerGrabing == false)

				PlayerGrabbed = false;

		};

		//

		{

			if (PlayerGrabbed == false)

				isPlayerGrabing = false;


		};

		//Code to Get the Ids the player has grabbed for its targetObject.

		{

			if (isPlayerGrabing == true)

				CheckRayhitID = FindPlayer.GetComponent<GrabKey>().ObjectRayID;

			else

				CheckRayhitID = null;

		};

		//

		{

			if (isPlayerGrabing == true)

				CheckEqualID = FindPlayer.GetComponent<GrabKey>().EqualID;

			else

				CheckEqualID = null;

		};

		//Input Code to activate isObjectHeld Below

		{

			if (isPlayerGrabing == true)
				if (CheckRayhitID == ObjectID)

				{

					CorrectID = true;
					isObjectHeld = true;
					isObjectHeld = FindPlayer.GetComponent<GrabKey>().ObjectHeld; ;

				}

		};

		//Code to reset isObjectHeld Below

		{

			if (FindPlayer.GetComponent<GrabKey>().ObjectHeld == false)

				isObjectHeld = false;

		};

		//Code to turn on the Id's while held Below 

		{

			if (isObjectHeld == true)

			{

				CheckEqualID = FindPlayer.GetComponent<GrabKey>().EqualID;
				CheckRayhitID = FindPlayer.GetComponent<GrabKey>().ObjectRayID;

			}

			else

			{

				CheckEqualID = null;
				CheckRayhitID = null;

			}

		};

		//Script check IDs


		{

			if (isObjectHeld == true)
				if (CheckEqualID == ObjectID)

					CorrectID = true;

				else

				{

					ObjectActivated = false;
					CorrectID = false;

				}

		};

		//Code to Check Rayhit ( might add in an extra condition to move object around in your view )

		{

			if (isObjectHeld == true)
				if (CheckRayhitID == ObjectID)

					CorrectID = true;

		};

		//Code to Reset Everything.

		{

			if (CorrectID == false)

			{

				ObjectActivated = false;
				isObjectHeld = false;
				isPlayerGrabing = false;
				PlayerGrabbed = false;

			}

		};

		//

		{

			if (isObjectHeld == false)

				CorrectID = false;

		};

		//Code to Move the object.

		{

			if (isObjectHeld == true)
				if (CorrectID == true)

					ObjectActivated = true;//add move script 

			//instead of this "Object actived" i was gonna use for when the
            //object was being moved
		}
		//Script Complete
	}
}
