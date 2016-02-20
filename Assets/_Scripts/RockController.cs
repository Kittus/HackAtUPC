using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int BaseMass;
	public Vector3 initialSpeed;
	public Vector3 initialSpeedVariance;
	void Start ()
	{
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);

				float scale = Random.Range (1.0F, 5.0F);

				hazard.transform.localScale = new Vector3(scale,scale,scale);
				Rigidbody rb = hazard.GetComponent<Rigidbody>();
				rb.mass = BaseMass * scale;

				Quaternion spawnRotation = Quaternion.identity;
				GameObject instantiated = (GameObject) Instantiate (hazard, spawnPosition, spawnRotation);
				instantiated.GetComponentInChildren<Rigidbody> ().velocity = new Vector3 (
					initialSpeed.x+Random.Range (-1,1)*initialSpeedVariance.x,
					initialSpeed.y+Random.Range (-1,1)*initialSpeedVariance.y,
					initialSpeed.z+Random.Range (-1,1)*initialSpeedVariance.z);
				instantiated.GetComponentInChildren<MeshRenderer> ().enabled = false;
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}