using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {
		
	public Transform packet;
	public int numPackets;
	public int radius = 1;
	//public Transform[] packets;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = new Vector3 (transform.position.x,,transform.position.z);
		if (transform.childCount != numPackets) {
			Transform[] children = transform.GetComponentsInChildren<Transform>();
			foreach (Transform ch in children){
				if(ch != transform){
					Destroy(ch.gameObject);
				}
			}
			//packets = new Transform[numPackets];

			for (int i = 0; i < numPackets; i++) {
				float angle = i * Mathf.PI * 2 / numPackets;
				Vector3 pos = new Vector3 (Mathf.Cos (angle), 0, Mathf.Sin (angle)) * radius + transform.position;
				Transform t = Instantiate (packet, pos, Quaternion.identity) as Transform;
				t.parent = transform;

				Debug.Log ("DOT");
				//t.gameObject.AddComponent<OrbiterMove>().center = this.transform;
				//packets[i].gameObject.AddComponent<OrbiterMove>().rotationSpeed = 0;
			}
		}
	}
}
