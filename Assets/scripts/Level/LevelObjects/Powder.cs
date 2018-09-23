using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powder : MonoBehaviour {

	private bool inUse;							//check if the Powder is being used
	private float timer;						//timer to check for next drawing Interval
	private float drawingIntveral;              //time interval between updates of the drawn mesh
	private int counter;						//counter to check if first or second set of UV coordinates has to be used

	private Mesh powderMesh;					//holds the generated mesh
	private List<Vector3> verts;				//holds world coordinates of the vertices
	private List<int> faces;					//holds integers to generate the faces of the mesh
	private List<Vector2> uvs;					//holds uv coordinates for each vertex

	private GameObject powderObject;			//GameObject with the generated mesh
	private Rigidbody playerRB;					//reference to player rigidbody
	private Transform playerTransform;          //reference to player transform

	[SerializeField]
	private Material mat;

	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

		timer = 0;
		drawingIntveral = 0.25f;
		inUse = false;
		counter = 0;
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (inUse && timer >= drawingIntveral)		//if the powder is in use, draw a new line every 'drawingIntveral' seconds
		{
			if (Mathf.Abs(playerRB.velocity.x) > 0.1f || Mathf.Abs(playerRB.velocity.z) > 0.1f)		//do not draw, if player is not or barely moving
			{
				DrawLine();
				timer = 0;
			}
		}
	}

	//Initiates the powderMesh generation
	public void StartUse()
	{
		inUse = true;
		transform.Rotate(150, 0, 0);

		//create the gameObject which will hold the mesh
		powderMesh = new Mesh();
		powderObject = new GameObject();
		powderObject.name = "Powder";
		powderObject.AddComponent<MeshFilter>();
		powderObject.AddComponent<MeshRenderer>();
		powderObject.GetComponent<MeshFilter>().mesh = powderMesh;
		powderObject.GetComponent<Renderer>().material = mat;

		verts = new List<Vector3>();
		faces = new List<int>();
		uvs = new List<Vector2>();

		//first set of vertices and uv coordinates
		verts.Add(new Vector3(playerTransform.position.x, -11.65f, playerTransform.position.z + 0.25f));
		verts.Add(new Vector3(playerTransform.position.x, -11.65f, playerTransform.position.z - 0.25f));
		uvs.Add(new Vector2(0, 0));
		uvs.Add(new Vector2(1, 0));

		counter += 2;

	}

	//Called after completing the ritual, allows player to drop the object
	public void EndUse()
	{
		inUse = false;
		transform.Rotate(150, 0, 0);
		tag = "Untagged";
	}

	//Cancels the powderMesh generation and resets inUse state
	public void Terminate()
	{
		inUse = false;
		transform.Rotate(-150, 0, 0);

		counter = 0;
		Destroy(powderObject);
	}

	public bool checkUse()
	{
		return inUse;
	}

	//Generate vertices, faces and uv coordinates based on the player's position and add them to the mesh
	void DrawLine()
	{
		verts.Add(new Vector3(playerTransform.position.x, -11.65f, playerTransform.position.z + 0.25f));
		verts.Add(new Vector3(playerTransform.position.x, -11.65f, playerTransform.position.z - 0.25f));
	
		if (counter % 4 == 0)
		{
			uvs.Add(new Vector2(1, 1));
			uvs.Add(new Vector2(0, 1));
		}
		else
		{
			uvs.Add(new Vector2(1, 0));
			uvs.Add(new Vector2(0, 0));
		}

		faces.Add(counter - 2);
		faces.Add(counter - 1);
		faces.Add(counter);

		faces.Add(counter);
		faces.Add(counter - 1);
		faces.Add(counter + 1);

		faces.Add(counter - 2);
		faces.Add(counter);
		faces.Add(counter - 1);

		faces.Add(counter);
		faces.Add(counter + 1);
		faces.Add(counter - 1);

		counter += 2;

		powderMesh.vertices = verts.ToArray();
		powderMesh.triangles = faces.ToArray();
		powderMesh.uv = uvs.ToArray();
	}
}
