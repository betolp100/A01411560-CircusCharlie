using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Vector3 offset;
    public Transform player;
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(player.position.x+offset.x, player.position.y+offset.y, offset.z);
	}
}
