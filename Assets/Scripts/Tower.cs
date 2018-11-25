using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour {

    [SerializeField] List<Transform> objectToPan = new List<Transform>();
    [SerializeField] Transform targetEnemy;

	// Update is called once per frame
	void Update () {
        foreach (Transform transform in objectToPan)
        {
            transform.LookAt(targetEnemy);
        }
	}
}
