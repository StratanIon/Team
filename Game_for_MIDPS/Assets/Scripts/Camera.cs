using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

     private Vector2 veloncity;

     public float smoothTimeY;
     public float smoothTimeX;
     public GameObject car;

	// Use this for initialization
	void Start () {
          car = GameObject.FindGameObjectWithTag("car");
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

          float posX = Mathf.SmoothDamp(transform.position.x, car.transform.position.x, ref veloncity.x, smoothTimeX);
          float posY = Mathf.SmoothDamp(transform.position.y, car.transform.position.y, ref veloncity.y, smoothTimeY);

          transform.position = new Vector3(posX, posY, transform.position.z);
     }
}
