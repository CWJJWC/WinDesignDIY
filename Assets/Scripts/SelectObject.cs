using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cakeslice;

public class SelectObject : MonoBehaviour {
	GameObject temp ;


	void Update(){
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			LayerMask mask = ~(1<<LayerMask.NameToLayer ("Floor"));
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit, 100f, mask.value)) {
//				print ("hhhhhhh");
//				if (hit.collider.gameObject.GetComponent<Outline> ()) {
//					hit.collider.gameObject.GetComponent<Outline> ().enabled = true;
//					temp = hit.collider.gameObject;
//				}
				DelTemp();
				AddTemp (hit);
			} else {
//				if (temp&&temp.GetComponent<Outline> ()) {
//					temp.GetComponent<Outline> ().enabled = false;
//				}
				DelTemp();
			}

		}
	}

	void AddTemp(RaycastHit hit){
		
		temp = hit.collider.gameObject;
		Renderer[] allChild = temp.GetComponentsInChildren<Renderer> ();
		foreach (Renderer child in allChild) {
			if (child.gameObject.GetComponent<Outline> ()) {
				child.gameObject.GetComponent<Outline> ().enabled = true;
			}
		}
	}

	void DelTemp(){
		if (temp == null) {
			return;
		}
		Renderer[] allChild = temp.GetComponentsInChildren<Renderer> ();
		foreach (Renderer child in allChild) {
			if (child.gameObject.GetComponent<Outline> ()) {
				child.gameObject.GetComponent<Outline> ().enabled = false;
			}
		}
		temp = null;
	}
}
