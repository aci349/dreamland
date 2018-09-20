using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
public class LevelBaseMesh : MonoBehaviour {
	
	private int rowLength;
	private int rowAmount;

	private GameObject constructor;

	private Mesh levelMesh;
	private List<Vector3> verts;
	private List<int> faces;
	private List<Vector2> uvs;

	void Start ()
	{
		//Dimension of the LevelMesh
		rowLength = 10;
		rowAmount = 10;

		constructor = new GameObject();
		constructor.name = "Level Mesh Constructor";
		constructor.tag = "Ground";

		//Create a new Mesh
		levelMesh = new Mesh();
		verts = new List<Vector3>();
		faces = new List<int>();
		uvs = new List<Vector2>();

		//Create the level architecture
		BaseLevel();

		//apply levelMesh to the MeshFilter
		GetComponent<MeshFilter>().mesh = levelMesh;
		GetComponent<MeshCollider>().sharedMesh = levelMesh;
	}

	void BaseLevel()
	{
		//Holds the offset for y position of vertices
		float offset = 0;

		for (int i = 0; i < rowAmount; i++)
		{
			for (int k = 0; k < rowLength; k++)
            {
				//create trench by increasing flat offset value
				if (i >= 7 && i < 8)
					offset = i / 3;
				else if (i >= 8)
					offset = 3;

				//randomly determine y position of vertex and decrease by offset value
                float rand = Random.Range(-1f, 1f);
                constructor.transform.position = new Vector3(i, rand - offset, k);

				uvs.Add(new Vector2(i, k));
				verts.Add(constructor.transform.position);
			}
		}

		//Create Faces from vertices
        for (int i = 0; i < rowAmount -1; i++)
        {
            for (int k = 0; k < rowLength - 1; k++)
            {
                faces.Add(i * 10 + k);
                faces.Add(i * 10 + k + 1);
                faces.Add(i * 10 + 10 + k);

                faces.Add(i * 10 + k + 1);
                faces.Add(i * 10 + 10 + k + 1);
                faces.Add(i * 10 + 10 + k);
            }
        }

        levelMesh.vertices = verts.ToArray();
		levelMesh.triangles = faces.ToArray();
		levelMesh.uv = uvs.ToArray();
		levelMesh.RecalculateNormals();
	}
}
