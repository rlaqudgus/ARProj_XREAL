using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private bool hasSpawned;
    [SerializeField] private bool hasDetected;
    [SerializeField] private GameObject spawnUI;
    [SerializeField] private GameObject waitUI;
    [SerializeField] private GameObject TutoralPanel;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private Image backGroundImage;

    public GameObject spawnedObj;

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
        hasDetected = false;
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    public void PlaceRandomObject()
    {
        //enable camera
        backGroundImage.color = new Color(255,255,255,0);
        backGroundImage.sprite = null;
        //trackedPoseDriver.enabled = true;
        Debug.Log("Placing Object..");

        //1. if there is plane detected in screen center pos
        Vector2 screenSize = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        List<ARRaycastHit> hitInfos = new List<ARRaycastHit>();

        if (arRaycastManager.Raycast(screenSize, hitInfos, UnityEngine.XR.ARSubsystems.TrackableType.Planes))
        {
            Debug.Log("Found Plane");
            Pose pose = hitInfos[0].pose;
            GameObject centerGo = Instantiate(prefabs[0], pose.position, pose.rotation);
            spawnedObj = centerGo;
            Debug.Log("Placed Object in screen center position");

            //face object towards the main camera
            //RotateTowardsCamera(centerGo);
        }

        // 2. if failed to detect plane in screen center pos, get the latest updated or added plane center pos
        else
        {
            GameObject go = Instantiate(prefabs[0], spawnPos, Quaternion.identity);
            spawnedObj = go;
            Debug.Log("Placed Object in latest plane center position");

            //face object towards the main camera
            RotateTowardsCamera(go);
        }
    }

    private void RotateTowardsCamera(GameObject go)
    {
        Debug.Log(go.transform.rotation.eulerAngles);
        Vector3 position = go.transform.position;
        Vector3 cameraPosition = Camera.main.transform.position;
        Vector3 direction = position - cameraPosition;
        Vector3 lookRotationEuler = Quaternion.LookRotation(direction).eulerAngles;
        Debug.Log(lookRotationEuler);

        Vector3 scaledEuler = Vector3.Scale(lookRotationEuler, go.transform.up.normalized);
        Quaternion targetRotation = Quaternion.Euler(scaledEuler);
        go.transform.rotation = go.transform.rotation * targetRotation;
        Debug.Log(go.transform.rotation.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Events invoked when planes change - will be invoked multiple times 딱 한번만 불리게 해보자
    public void OnPlanesChanged(ARPlanesChangedEventArgs changes)
    {
        
        if(changes.added.Count==0)
        {
            //Debug.Log("List has no new plane. No planes added.");
            if(changes.updated.Count!=0)
            {
                //updated List 때문에 로직이 꼬임 새 plane 나올때까지 clear해놓고 기다리기
                //changes.updated.Clear();
                //waitUI.SetActive(false);
                //hasDetected = true;
                //spawnPos = changes.updated[0].center;
                //Debug.Log($"Found updated Plane - SpawnPos : {spawnPos}");
                //spawnUI.SetActive(true);
                int latest = changes.updated.Count;
                spawnPos = changes.updated[latest - 1].center;
                //Debug.Log($"New Plane updated - SpawnPos : {spawnPos}");
            }
            else
            {
                //Debug.Log("List has no updated plane. No planes updated.");
            }
        }
        else
        {
            int latest = changes.added.Count;
            spawnPos = changes.added[latest-1].center;
            //Debug.Log($"New Plane Added - SpawnPos : {spawnPos}");
        }

        if (hasDetected) return;
        hasDetected = true;
        waitUI.SetActive(false);
        spawnUI.SetActive(true);
        TutoralPanel.SetActive(true);
        ScreenCaptureAndShow();
        //ScreenCapture.CaptureScreenshot();
        //trackedPoseDriver.enabled = false;
    }

    void ScreenCaptureAndShow()
    {
        Texture2D text = ScreenCapture.CaptureScreenshotAsTexture();
        Sprite sprite = Sprite.Create(text, new Rect(0, 0, text.width, text.height), new Vector2(.5f,.5f));
        backGroundImage.sprite = sprite;
        backGroundImage.color = new Color(255, 255, 255, 255);
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }
}
