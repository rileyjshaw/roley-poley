using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public const int NUM_PICKUPS = 40;
	public GameObject pickup;
	public GameObject ball;

	private const float NUM_STACKS = 30;
	private const float PICKUP_RADIUS = 0.7f;
	private const float STACK_RADIUS = 9f;

	void Start () {
		for (int ring = 1; ring < 9; ring++) {
			int NUM_PICKUPS_IN_RING = NUM_PICKUPS * ring / 8;
			float RADIUS_IN_RING = PICKUP_RADIUS * ring;
			for (int i = 0; i < NUM_PICKUPS_IN_RING; i++) {
				float FREQUENCY = 2 * Mathf.PI / NUM_PICKUPS_IN_RING;

				float r = Mathf.Sin (FREQUENCY * i) / 2 + 0.5f;
				float g = Mathf.Sin (FREQUENCY * i + 2f / 3f * Mathf.PI) / 2 + 0.5f;
				float b = Mathf.Sin (FREQUENCY * i + 4f / 3f * Mathf.PI) / 2 + 0.5f;

				float angle = i * Mathf.PI * 2 / NUM_PICKUPS_IN_RING;
				Vector3 position = new Vector3 (Mathf.Cos (angle), (float) (ring / 4 + i / NUM_PICKUPS_IN_RING) / 3 / RADIUS_IN_RING, Mathf.Sin (angle)) * RADIUS_IN_RING;
				GameObject pickupClone = (GameObject) Instantiate (pickup, position, Quaternion.identity);
				pickupClone.GetComponent<Renderer>().material.color = new Color (r, g, b);
			}
		}

		for (int stack = 0; stack < NUM_STACKS; stack++) {
			float angle = Mathf.PI * (0.5f + stack * 2f / NUM_STACKS);
			float x = Mathf.Cos (angle);
			float z = Mathf.Sin (angle);

			for (int height = 0; height < stack; height++) {
				Instantiate (ball, new Vector3 (x, (height + 0.5f) / STACK_RADIUS, z) * STACK_RADIUS, Quaternion.identity);
			}
		}
	}
}
