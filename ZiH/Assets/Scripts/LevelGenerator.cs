using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {
    public GameObject[] availableRooms;

    public List<GameObject> currentRooms;

    private float screenWidthInPoints;

	// Use this for initialization
	void Start () {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        GenerateRoomIfRequired();

	}

    void AddRoom(float farhtestRoomEndZ)
    {
        //1
        int randomRoomIndex = Random.Range(0, availableRooms.Length);

        //2
        GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);

        //3
        float roomWidth = room.transform.FindChild("floor").localScale.z;

        //4
        float roomCenter = farhtestRoomEndZ + roomWidth * 10f - 0.5f;

        //5
        room.transform.position = new Vector3(0, 0, roomCenter);

        //6
        currentRooms.Add(room);
    }

    void GenerateRoomIfRequired()
    {
        //1
        List<GameObject> roomsToRemove = new List<GameObject>();

        //2
        bool addRooms = true;

        //3
        float playerZ = transform.position.z;

        //4
        float removeRoomZ = playerZ - screenWidthInPoints;

        //5
        float addRoomZ = playerZ + screenWidthInPoints;

        //6
        float farthestRoomEndZ = 0;

        foreach (var room in currentRooms)
        {
            //7
            float roomWidth = room.transform.FindChild("floor").localScale.z;
            float roomStartZ = room.transform.position.z - (roomWidth * 0.5f);
            float roomEndZ = roomStartZ + roomWidth;

            //8
            if (roomStartZ > addRoomZ)
                addRooms = false;

            //9
            if (roomEndZ < removeRoomZ)
                roomsToRemove.Add(room);

            //10
            farthestRoomEndZ = Mathf.Max(farthestRoomEndZ, roomEndZ);
        }

        //11
        foreach (var room in roomsToRemove)
        {
            currentRooms.Remove(room);
            Destroy(room);
        }

        //12
        if (addRooms)
            AddRoom(farthestRoomEndZ);
    }
}
