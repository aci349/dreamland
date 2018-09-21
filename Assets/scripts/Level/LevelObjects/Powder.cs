using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powder : MonoBehaviour {

	private bool inUse;
	private float timer;						//timer to check for next drawing Interval
	private float drawingIntveral;              //time interval between updates of the drawn mesh
	private int counter;

	private Mesh powderMesh;
	private List<Vector3> verts;
	private List<int> faces;
	private List<Vector2> uvs;

	private GameObject powderObject;
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
		inUse = true;
		counter = 0;

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
		verts.Insert(counter, new Vector3(playerTransform.position.x, -11.65f, playerRB.transform.position.z) + playerTransform.right * 0.25f);
		verts.Insert(counter + 1, new Vector3(playerTransform.position.x, -11.65f, playerRB.transform.position.z) - playerTransform.right * 0.25f);
		uvs.Add(new Vector2(0, 0));
		uvs.Add(new Vector2(1, 0));

		counter += 2; 
	}

	void Update()
	{
		timer += Time.deltaTime;
		if (inUse && timer >= drawingIntveral)
		{
			if (Mathf.Abs(playerRB.velocity.x) > 0.1f || Mathf.Abs(playerRB.velocity.z) > 0.1f)
			{
				DrawLine();
				timer = 0;
			}
		}
	}

	public void StartUse()
	{
		inUse = true;

		//create the gameObject which will hold the mesh
		powderMesh = new Mesh();
		powderObject = new GameObject();
		powderObject.name = "Powder";
		powderObject.AddComponent<MeshFilter>();
		powderObject.AddComponent<MeshRenderer>();
		powderObject.GetComponent<MeshFilter>().mesh = powderMesh;
		powderObject.GetComponent<Renderer>().material = mat;

		//first set of vertices and uv coordinates
		verts.Add(new Vector3(playerTransform.position.x, -11.65f, playerTransform.position.z + 0.25f));
		verts.Add(new Vector3(playerTransform.position.x, -11.65f, playerTransform.position.z - 0.25f));
		uvs.Add(new Vector2(0, 0));
		uvs.Add(new Vector2(1, 0));

		counter += 2;

	}

	public void EndUse()
	{
		inUse = false;
	}

	public void Terminate()
	{
		inUse = false;
		counter = 0;
		Destroy(powderObject);
	}

	public bool checkUse()
	{
		return inUse;
	}

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
