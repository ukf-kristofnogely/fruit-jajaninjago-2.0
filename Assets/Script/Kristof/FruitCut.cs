using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCut : MonoBehaviour
{
    public GameObject whole;
    public GameObject sliced;

    private Rigidbody fruitRigidbody;
    private Collider fruitCollider;

    private void onTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            Slice();
        }
    }

    private void Slice(/*Vector3 direction, Vector3 position, float force*/) {
        whole.SetActive(false);
        sliced.SetActive(true);
        fruitCollider.enabled = false;

        Rigidbody[] slices = sliced.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody slice in slices){
            slice.velocity = fruitRigidbody.velocity;

        }
    }
}
