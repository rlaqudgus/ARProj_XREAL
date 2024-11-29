using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private bool hasSpawned;
    [SerializeField] private bool hasDetected;
    [SerializeField] private GameObject spawnUI;
    [SerializeField] private GameObject waitUI;
    [SerializeField] private Vector3 spawnPos;

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
        Debug.Log("Placing Object..");
        GameObject go = Instantiate(prefabs[0], spawnPos, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Events invoked when planes change - will be invoked multiple times 딱 한번만 불리게 해보자
    public void OnPlanesChanged(ARPlanesChangedEventArgs changes)
    {
        if (hasDetected) return;
        
        

        if(changes.added.Count==0)
        {
            Debug.Log("List has no new plane. No planes added.");
            if(changes.updated.Count!=0)
            {
                //updated List 때문에 로직이 꼬임 새 plane 나올때까지 clear해놓고 기다리기
                changes.updated.Clear();
                //waitUI.SetActive(false);
                //hasDetected = true;
                //spawnPos = changes.updated[0].center;
                //Debug.Log($"Found updated Plane - SpawnPos : {spawnPos}");
                //spawnUI.SetActive(true);
            }
            else
            {
                Debug.Log("List has no updated plane. No planes updated.");
            }
        }
        else
        {
            waitUI.SetActive(false);
            hasDetected = true;
            int latest = changes.added.Count;
            spawnPos = changes.added[latest-1].center;
            Debug.Log($"New Plane Added - SpawnPos : {spawnPos}");
            spawnUI.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed");
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }
}
