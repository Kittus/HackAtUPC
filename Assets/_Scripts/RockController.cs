using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour
{
	public GameObject hazardRocks;
	public GameObject hazardTree;

	public Vector3 spawnValuesRocks;
	public Vector3 spawnValuesTree;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public int BaseMass;
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
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValuesRocks.x, spawnValuesRocks.x), spawnValuesRocks.y, spawnValuesRocks.z);

				float scale = Random.Range (1.0F, 5.0F);

				hazardRocks.transform.localScale = new Vector3(scale,scale,scale);
				Rigidbody rb = hazardRocks.GetComponent<Rigidbody>();
				rb.mass = BaseMass * scale;

				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazardRocks, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			Vector3 spawnPositionTree = new Vector3 (Random.Range (-spawnValuesTree.x, spawnValuesTree.x), spawnValuesTree.y, spawnValuesTree.z);
			Quaternion spawnRotationTree = Quaternion.AngleAxis (90.0F, Vector3.forward );
			Instantiate (hazardTree, spawnPositionTree, spawnRotationTree);
			yield return new WaitForSeconds (waveWait);
		}
	}
}