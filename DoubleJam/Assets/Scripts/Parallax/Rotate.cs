using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	new public Camera camera;
	private Transform first;
    private Transform second;
	public float factor = 1;
	private Transform current;

	private Vector2 size;
    // Use this for initialization
    void Start () {
		var child = transform.GetChild(0);
		current = first = child;
		size = child.GetComponent<SpriteRenderer>().size;
		var copy = Instantiate(child, new Vector3(child.position.x + size.x, child.position.y, child.position.z), child.rotation);
		copy.parent = transform;
		second = copy;
    }
	
	// Update is called once per frame
	void Update () {

    }

	public void Move (Vector2 move) {
		if (move.x > 0) {
			// check right edge
			var rightEdge = camera.transform.position.x + size.x;
			var currentRight = first.transform.position.x + size.x;
			if (rightEdge > currentRight) {
				second.transform.position = new Vector2(currentRight, second.transform.position.y);
                Swap();
            }
		}
		else if (move.x < 0){
            var leftEdge = camera.transform.position.x;
            var currentLeft = first.transform.position.x;
            if (leftEdge < currentLeft)
            {
                second.transform.position = new Vector2(currentLeft - size.x, second.transform.position.y);
                Swap();
            }
		}
		first.transform.position = new Vector2(first.transform.position.x - move.x * factor, first.transform.position.y);
        second.transform.position = new Vector2(second.transform.position.x - move.x * factor, second.transform.position.y);
    }

	private void Swap() {
		var tmp = first;
        first = second;
        second = tmp;
	}
}
