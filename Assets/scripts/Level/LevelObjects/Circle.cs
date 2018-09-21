using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
public class Circle : MonoBehaviour {

	private GameObject constructor;

	private Mesh circleMesh;
	private List<Vector3> verts;
	private List<int> faces;
	private List<Vector2> uvs;

	private int counter;

	void Start ()
	{
		counter = 0;

		circleMesh = new Mesh();
		circleMesh.name = "PowderMesh";

		verts = new List<Vector3>();
		faces = new List<int>();
		uvs = new List<Vector2>();

		GetComponent<MeshFilter>().mesh = circleMesh;

		constructor = new GameObject();
		constructor.name = "Circle Mesh Constructor";

		DrawCircle(5);
	}

	//draw a circle by creating new squares with each step, rotating the next square by deg degrees
	void DrawCircle(int deg)
	{
		int cycles = (360 / deg);

		for (int i = 0; i < cycles; i++)
		{
			DrawLine();
			Turn(deg);
		}
	}

	void Turn(float angle)
	{
		constructor.transform.Rotate(new Vector3(0, angle, 0));
	}

	void DrawLine()
	{
		verts.Add(constructor.transform.position + constructor.transform.forward * 0.25f);
		verts.Add(constructor.transform.position - constructor.transform.forward * 0.25f);
		uvs.Add(new Vector2(0, 0));
		uvs.Add(new Vector2(1, 0));

		constructor.transform.Translate(0.5f, 0, 0);

		verts.Add(constructor.transform.position + constructor.transform.forward * 0.25f);
		verts.Add(constructor.transform.position - constructor.transform.forward * 0.25f);
		uvs.Add(new Vector2(0, 1));
		uvs.Add(new Vector2(1, 1));

		faces.Add(counter + 0);
		faces.Add(counter + 2);
		faces.Add(counter + 1);

		faces.Add(counter + 2);
		faces.Add(counter + 3);
		faces.Add(counter + 1);

		counter += 4;

		circleMesh.vertices = verts.ToArray();
		circleMesh.triangles = faces.ToArray();
		circleMesh.uv = uvs.ToArray();
		circleMesh.RecalculateNormals();
	}
}
