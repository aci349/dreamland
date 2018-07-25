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

	void Start ()
	{
		rowLength = 10;
		rowAmount = 10;

		constructor = new GameObject();
		constructor.name = "Level Mesh";
		constructor.tag = "Ground";

		//Create a new Mesh
		levelMesh = new Mesh();
		verts = new List<Vector3>();
		faces = new List<int>();

		//Create the level architecture
		BaseLevel();

		//apply levelMesh to the MeshFilter
		GetComponent<MeshFilter>().mesh = levelMesh;
		GetComponent<MeshCollider>().sharedMesh = levelMesh;
	}

	void DrawVert(Vector3 pos)
	{
		verts.Add(pos);
	}

	void BaseLevel()
	{
		for (int i = 0; i < rowAmount; i++)
		{
			for (int k = 0; k < rowLength; k++)
            {
                float rand = Random.Range(-1f, 1f);
                constructor.transform.position = new Vector3(i, rand, k);

                /*GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				cube.transform.position = constructor.transform.position;*/

				verts.Add(constructor.transform.position);
			}
		}

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
		levelMesh.RecalculateNormals();
	}
}
