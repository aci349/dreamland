using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour {

	private GameObject constructor;
	private GameObject circleObject;

	private Mesh powderMesh;
	private List<Vector3> verts;
	private List<int> faces;
	
	private int counter;

	void Start ()
	{
		counter = 0;

		powderMesh = new Mesh();
		circleObject = new GameObject();
		circleObject.name = "Circle";
		circleObject.AddComponent<MeshFilter>();
		circleObject.AddComponent<MeshRenderer>();

		verts = new List<Vector3>();
		faces = new List<int>();

		circleObject.GetComponent<MeshFilter>().mesh = powderMesh;
		
		constructor = new GameObject();

		DrawCircle();
	}

	void DrawCircle()
	{
		DrawLine();
		DrawLine();
		DrawLine();
		DrawLine();
		DrawLine();
	}

	void DrawLine()
	{
		verts.Insert(counter, constructor.transform.position + constructor.transform.right * 0.25f);
		verts.Insert(counter + 1, constructor.transform.position - constructor.transform.right * 0.25f);

		constructor.transform.Translate(1, 0, 0);

		verts.Insert(counter, constructor.transform.position + constructor.transform.right * 0.25f);
		verts.Insert(counter + 1, constructor.transform.position - constructor.transform.right * 0.25f);

		faces.Add(counter + 0);
		faces.Add(counter + 1);
		faces.Add(counter + 2);

		faces.Add(counter + 2);
		faces.Add(counter + 1);
		faces.Add(counter + 3);

		faces.Add(counter + 0);
		faces.Add(counter + 2);
		faces.Add(counter + 1);

		faces.Add(counter + 2);
		faces.Add(counter + 3);
		faces.Add(counter + 1);

		counter += 4;

		powderMesh.vertices = verts.ToArray();
		powderMesh.triangles = faces.ToArray();
	}
}
