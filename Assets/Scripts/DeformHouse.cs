using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class DeformHouse : MonoBehaviour
{

	#region Editable properties

	[SerializeField] float _explodeRate = 1f;

	#endregion

	public float explodeRate
	{
		get { return _explodeRate; }
		set { _explodeRate = value; }
	}


	public float springForce = 20f;
	public float damping = 5f;

	Mesh deformingMesh;
	Vector3[] originalVertices, displacedVertices;
	Vector3[] vertexVelocities;

	float uniformScale = 1f;

	void Start()
	{
		deformingMesh = GetComponent<MeshFilter>().mesh;
		originalVertices = deformingMesh.vertices;
		displacedVertices = new Vector3[originalVertices.Length];
		for (int i = 0; i < originalVertices.Length; i++)
		{
			displacedVertices[i] = originalVertices[i];
		}
		vertexVelocities = new Vector3[originalVertices.Length];
	}

	void Update()
	{
		uniformScale = transform.localScale.x;
		for (int i = 0; i < displacedVertices.Length; i++)
		{
			UpdateVertex(i);
		}
		deformingMesh.vertices = displacedVertices;
		deformingMesh.RecalculateNormals();
	}

	void UpdateVertex(int i)
	{
		Vector3 velocity = vertexVelocities[i];
		Vector3 displacement = displacedVertices[i] - originalVertices[i];
		displacement *= uniformScale;
		velocity -= displacement * springForce * Time.deltaTime;
		velocity *= 1f - damping * Time.deltaTime;
		vertexVelocities[i] = velocity;
		displacedVertices[i] += velocity * (Time.deltaTime / uniformScale);
	}

	public void AddDeformingForce(Vector3 point, float force)
	{
		point = transform.InverseTransformPoint(point);
		for (int i = 0; i < displacedVertices.Length; i++)
		{
			AddForceToVertex(i, point, force);
		}
	}

	public float force = 10f;
	public float forceOffset = 0.1f;

	public void ExplodeMesh()
	{
		Vector3 x = new Vector3(0.5f, 0.5f, 0.5f);
		AddDeformingForce(x, explodeRate);
	}

	void AddForceToVertex(int i, Vector3 point, float force)
	{
		Vector3 pointToVertex = displacedVertices[i] - point;
		pointToVertex *= uniformScale;
		float attenuatedForce = force / (1f + pointToVertex.sqrMagnitude);
		float velocity = attenuatedForce * Time.deltaTime;
		vertexVelocities[i] += pointToVertex.normalized * velocity;
	}
}