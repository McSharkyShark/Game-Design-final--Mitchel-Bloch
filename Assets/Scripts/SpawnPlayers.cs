using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Cinemachine;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject cameraPrefab; //*

    public float minX, maxX;
    public float minZ, maxZ;

    void Start()
    {
        Vector3 randomPosition = new Vector3(Random.Range(minX, maxX), 1f, Random.Range(minZ, maxZ));
        //PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity);

        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, randomPosition, Quaternion.identity); //*
        Debug.Log("Yep1");
        GameObject cameraAndCanvas = Instantiate(cameraPrefab, player.transform);

        cameraAndCanvas.GetComponent<StarterAssets.UICanvasControllerInput>().starterAssetsInputs = player.GetComponentInChildren<StarterAssets.StarterAssetsInputs>();

        Debug.Log("Yep2");
        CinemachineVirtualCamera cam = cameraAndCanvas.GetComponentInChildren<CinemachineVirtualCamera>();
        cam.Follow = GameObject.FindGameObjectWithTag("CinemachineTarget").transform;
        cam.LookAt = cam.Follow; //both are the same, only need to go find once



       
    }


}
