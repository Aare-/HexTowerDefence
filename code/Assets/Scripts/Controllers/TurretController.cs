using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class TurretController:MonoBehaviour{

    public GameObject turretPrefab;
    private Transform CurrentHex;
    private Transform TargetHex;
    private Camera mainCamera;

    void Start(){
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Debug.Log(mainCamera.name);
    }

    void Update(){
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            if (TargetHex && TargetHex != CurrentHex) {
                if (hit.transform != TargetHex) {
                    //TargetHex.GetComponent<Renderer>().material.color = Color.white;
                }
                TargetHex = hit.transform;
                //TargetHex.GetComponent<Renderer>().material.color = Color.red;
            }

            if (hit.transform != CurrentHex) {
                TargetHex = hit.transform;
            }

            if (Input.GetMouseButtonDown(0)) {
                if (CurrentHex) {
                    //CurrentHex.GetComponent<Renderer>().material.color = Color.white;
                }
                CurrentHex = hit.transform;
                //CurrentHex.GetComponent<Renderer>().material.color = Color.green;
            }

            if (Input.GetMouseButtonDown(1)) {
                if (CurrentHex) {
                    var dupa = new Vector3(CurrentHex.transform.position.x, CurrentHex.transform.position.y + (CurrentHex.localScale.y/2) + (turretPrefab.transform.localScale.y/2),
                        CurrentHex.transform.position.z);
                    Instantiate(turretPrefab, dupa, Quaternion.identity);
                }
            }
        }
        //Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit, 1000)) {
        //    if (TargetHex && TargetHex != CurrentHex) {
        //        if (hit.transform != TargetHex) {
        //            TargetHex.GetComponent<Renderer>().material.color = Color.cyan;
        //        }
        //        TargetHex = hit.transform;
        //        TargetHex.GetComponent<Renderer>().material.color = Color.red;
        //    }
        //    if (hit.transform != CurrentHex) {
        //        TargetHex = hit.transform;
        //    }

        //    if (Input.GetMouseButtonDown(0)) {
        //        Debug.Log("Button Down 0");
        //        if (CurrentHex) {
        //            CurrentHex.GetComponent<Renderer>().material.color = Color.cyan;
        //        }
        //        CurrentHex = hit.transform;
        //        CurrentHex.GetComponent<Renderer>().material.color = Color.green;
        //    }

        //    if (Input.GetMouseButtonDown(1)) {
        //        Debug.Log("Button Down 1");
        //        if (CurrentHex) {
        //            Instantiate(turretPrefab, CurrentHex.transform.position, Quaternion.identity);
        //        }
        //    }
        //}
    }

    public void RedTurret(){
        
    }
    public void BlueTurret() {

    }
    public void BlackTurret() {

    }
    public void YellowTurret() {

    }

}

