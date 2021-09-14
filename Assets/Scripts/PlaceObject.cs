using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlaceObject : MonoBehaviour
{
    public GameObject AR_Car;
    public Camera AR_Camera;
    public ARRaycastManager raycastManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public GameObject ui;
    public Image brakeIcon;
    bool notPlaced = true;

    // Start is called before the first frame update
    void Start()
    {
        AR_Car.SetActive(false);
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && notPlaced)
        {
            Ray ray = AR_Camera.ScreenPointToRay(Input.mousePosition);
            if (raycastManager.Raycast(ray, hits) && notPlaced)
            {
                Pose pose = hits[0].pose;
                AR_Car.SetActive(true);
                AR_Car.transform.position = new Vector3(pose.position.x, pose.position.y, pose.position.z);
                notPlaced = false;
                ui.SetActive(true);
            }
        }

        if(AR_Car.transform.position.y < -100)
        {
            SceneController.SceneNew("Menu");
            SceneController.isEntry = false;
        }

    }
}