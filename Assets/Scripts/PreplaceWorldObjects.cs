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
            //������Ʈ ����
            GameObject go = Instantiate(gameObjects[latLongs.IndexOf(gps) % gameObjects.Count]);

            //������ ������Ʈ�� ���� ����, �浵�� ���� ����
            posHelper.AddOrUpdateObject(go, gps.latitude, gps.longitude, 0, Quaternion.identity);

            //�����
            Debug.Log($"Added Object : {go.name} / Added Latitude : {gps.latitude} / Added Longitude : {gps.longitude}");


        }

        posManager.OnStatusChanged += OnStatusChanged;
    }

    // GPS ���� �ʼ�
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
