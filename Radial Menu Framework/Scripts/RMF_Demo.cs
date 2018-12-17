using UnityEngine;
using System.Collections;

public class RMF_Demo : MonoBehaviour {

    public ParticleSystem ps;
    public RMF_RadialMenu rm;
    public GameObject child1;
	// Use this for initialization
	void Start () {
	   child1.SetActive(false);
       rm.useLazySelection = false;
	}

    // Update is called once per frame
    void Update() {


        // if (Input.GetKeyDown(KeyCode.S) && rm.useLazySelection) {
       if (Input.GetKeyDown(KeyCode.S)) {

            rm.useSelectionFollower = !rm.useSelectionFollower;
            rm.selectionFollowerContainer.gameObject.SetActive(rm.useSelectionFollower);


        }


        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Application.LoadLevel(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Application.LoadLevel(1);
        }


    }

    public void emitButton(int count) {

        ps.Emit(count);
        child1.SetActive(true);
        print(rm.useLazySelection);

    }


}
