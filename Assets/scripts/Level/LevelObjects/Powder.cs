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

	private GameObject powderObject;
	private Rigidbody playerRB;
	private Transform playerTransform;

	void Start ()
	{
		playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
		playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();

		timer = 0;
		drawingIntveral = 0.25f;
		inUse = true;
		counter = 0;

		powderMesh = new Mesh();
		powderObject = new GameObject();
		powderObject.name = "Powder";
		powderObject.AddComponent<MeshFilter>();
		powderObject.AddComponent<MeshRenderer>();

		verts = new List<Vector3>();
		faces = new List<int>();

		powderObject.GetComponent<MeshFilter>().mesh = powderMesh;

		verts.Insert(counter, new Vector3(playerTransform.position.x, -11.65f, playerRB.transform.position.z) + playerTransform.right * 0.25f);
		verts.Insert(counter + 1, new Vector3(playerTransform.position.x, -11.65f, playerRB.transform.position.z) - playerTransform.right * 0.25f);

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
	}

	public void EndUse()
	{
		inUse = false;
	}

	void DrawLine()
	{
		Debug.Log("TESTDRAW");

		verts.Insert(counter, new Vector3 (playerTransform.position.x, -11.65f, playerRB.transform.position.z) + playerTransform.right * 0.25f);
		verts.Insert(counter + 1, new Vector3(playerTransform.position.x, -11.65f, playerRB.transform.position.z) - playerTransform.right * 0.25f);

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
	}
}
