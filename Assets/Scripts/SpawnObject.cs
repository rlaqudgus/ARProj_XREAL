using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;

    private ARRaycastManager arRaycastManager;
    private ARPlaneManager arPlaneManager;

    private void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        PlaceRandomObject();
    }

    public void PlaceRandomObject()
    {
        Debug.Log("Placing Object..");
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        if(arRaycastManager.Raycast(screenSize, hitInfos, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            Debug.Log("Found Plane");
            Pose pose = hitInfos[0].pose;
            int randint = Random.Range(0, prefabs.Length);
            GameObject go = Instantiate(prefabs[randint], pose.position, pose.rotation);
            Debug.Log("Placed Random Objects");
        }

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
