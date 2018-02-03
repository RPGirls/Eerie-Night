using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakObjects : MonoBehaviour {

	public Sprite BrokenObject;
	public float Radius = 10.0f;

	private PlayerController _player;

	// Use this for initialization
	void Start () {

		_player = PlayerController.Instance;
	}
	// Interactive

	// Objetos quebram e soltam uma particula em direção ao player

	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown (KeyCode.Space)){
			Collider col = FindObject ();
			Debug.Log (col.name);
		}

	}

	Collider FindObject (){
		
		Collider[] colliders = Physics.OverlapSphere(_player.GetPosition(), Radius);

		Debug.Log (_player.GetPosition () + " posicao player");

		Collider nearestCollider = null;
		float minSqrDistance = Mathf.Infinity;

		for (int i = 0; i < colliders.Length; i++)
		{
			float sqrDistanceToCenter = (_player.GetPosition() - colliders[i].transform.position).sqrMagnitude;

			if (sqrDistanceToCenter < minSqrDistance)
			{
				minSqrDistance = sqrDistanceToCenter;
				nearestCollider = colliders[i];
			}
		}

		Debug.Log (minSqrDistance + " Distancia");
		return nearestCollider;
	}


	void OnValidate() {
		Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere (_player.GetPosition(), Radius);
	}
}
