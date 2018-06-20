using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter)), RequireComponent(typeof(MeshRenderer))]
public class LevelBaseMesh : MonoBehaviour {

	private Mesh levelMesh;
	private List<Vector3> verts;
	private List<int> faces;

	void Start ()
	{
		//Create a new Mesh
		levelMesh = new Mesh();

		//Create the level architecture
		BaseLevel();

		//apply levelMesh to the MeshFilter
		GetComponent<MeshFilter>().mesh = levelMesh;
	}

	void DrawVert(Vector3 pos)
	{
		verts.Add(pos);
	}

	void BaseLevel()
	{

		levelMesh.vertices = verts.ToArray();
		levelMesh.triangles = faces.ToArray();
	}
}
