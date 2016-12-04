using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emitter : MonoBehaviour {

	public GameObject[] waves;

	private int currentWave;

	// Use this for initialization
	IEnumerator Start () {
		if (waves.Length == 0) {
			yield break;
		}

		while (true) {
			GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position, transform.rotation);
		
			// WaveをEmitterの子要素にする
			wave.transform.parent = transform;

			while (wave.transform.childCount != 0) {
				yield return new WaitForEndOfFrame ();
			}

			Destroy (wave);

			// 格納されているWaveを全て実行したらcurrentWaveを0にする（最初から -> ループ）
			if (waves.Length <= ++currentWave) {
				currentWave = 0;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
