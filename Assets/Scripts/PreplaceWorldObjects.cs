using Niantic.Lightship.AR.WorldPositioning;
using Niantic.Lightship.AR.XRSubsystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreplaceWorldObjects : MonoBehaviour
{
    [SerializeField] private List<Material> materials = new List<Material>();
    [SerializeField] private List<GameObject> gameObjects = new List<GameObject>();
    [SerializeField] private List<LatLong> latLongs = new List<LatLong>();
    [SerializeField] private ARWorldPositioningManager posManager;
    [SerializeField] private ARWorldPositioningObjectHelper posHelper;

    [SerializeField] List<GameObject> instantiatedObjs = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (var gps in latLongs)
        {
            //오브젝트 생성
            GameObject go = Instantiate(gameObjects[latLongs.IndexOf(gps) % gameObjects.Count]);

            //생성된 오브젝트를 실제 위도, 경도에 맞춰 띄우기
            posHelper.AddOrUpdateObject(go, gps.latitude, gps.longitude, 0, Quaternion.identity);

            //디버그
            Debug.Log($"Added Object : {go.name} / Added Latitude : {gps.latitude} / Added Longitude : {gps.longitude}");


        }

        posManager.OnStatusChanged += OnStatusChanged;
    }

    // GPS 연결 필수
    private void OnStatusChanged(WorldPositioningStatus status)
    {
        Debug.Log("Status Changed to " + status);
    }
    // Update is called once per frame
    void Update()
    {

    }

    [System.Serializable]
    public struct LatLong
    {
        public double latitude; 
        public double longitude;   
    }

}
