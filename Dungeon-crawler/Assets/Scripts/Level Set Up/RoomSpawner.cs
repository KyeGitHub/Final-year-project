﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomSpawner : MonoBehaviour
{
    // Could probably put this in an array
    public GameObject connectingRoom;
    public GameObject topLeftRoom;
    public GameObject bottomLeftRoom;
    public GameObject topRightRoom;
    public GameObject bottomRightRoom;
    public GameObject leftWall;
    public GameObject rightWall;
    public GameObject topWall;
    public GameObject bottomWall;
    public GameObject spawnRoom;
    public GameObject bossRoom;

    public int roomCount = 0;
    public int dungeonSize; // how many rows/collumns, e.g. 10 sets it to 10 by 10, 100 rooms.

    // a count of each type of room as we need to make sure there is a variety to make sure the floor is completable
    public int combatRooms = 0;
    public int resourceRooms = 0;
    public int demibossRooms = 0;
    public int demibossRoomsMax = 4;
    bool edgeRoom;
    public bool spawnRoomSpawned;
    public bool bossRoomSpawned;
    public NavMeshSurface surface;


    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        GenerateNavMesh();

    }

    // Update is called once per frame
    void Update()
    {

    }



    void GenerateLevel()
    {
        int bounds = ((dungeonSize) * 20) - 20;

        int bossRoomSide = Random.Range(1, 4);

        Debug.Log("Side: " + bossRoomSide);

        for (int i = -bounds; i < bounds + 40; i += 40)
        {
            for (int j = -bounds; j < bounds + 40; j += 40)
            {
                if (i == bounds & j == bounds)
                {
                    // Top right corner room
                    Debug.Log("Top right " + roomCount);
                    GameObject instance = Instantiate(topRightRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = true;
                    AssignRoomType(instance, edgeRoom);
                }
                else if (j == -bounds & i == bounds)
                {
                    // Bottom right corner room
                    Debug.Log("Bottom right " + roomCount);
                    GameObject instance = Instantiate(bottomRightRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = true;
                    AssignRoomType(instance, edgeRoom);
                }
                else if (i == -bounds & j == -bounds)
                {
                    // Bottom left corner room
                    Debug.Log("Bottom Left " + roomCount);
                    GameObject instance = Instantiate(bottomLeftRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = true;
                    AssignRoomType(instance, edgeRoom);
                }
                else if (i == -bounds & j == bounds)
                {
                    // Top left corner room
                    Debug.Log("Top Left " + roomCount);
                    GameObject instance = Instantiate(topLeftRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = true;
                    AssignRoomType(instance, edgeRoom);
                }
                else if (i == -bounds)
                {
                    // Edge room
                    GameObject instance = Instantiate(leftWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = true;
                    AssignRoomType(instance, edgeRoom);
                }
                else if (i == bounds)
                {
                    // Edge room
                    GameObject instance = Instantiate(rightWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = true;
                    AssignRoomType(instance, edgeRoom);
                }
                else if (j == -bounds)
                {
                    // Edge room
                    GameObject instance = Instantiate(bottomWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = true;
                    AssignRoomType(instance, edgeRoom);

                }
                else if (j == bounds)
                {
                    // Edge room
                    GameObject instance = Instantiate(topWall, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = true;
                    AssignRoomType(instance, edgeRoom);
                }
                else if (j == 0 & i == 0)
                {
                    // Spawn room
                    GameObject instance = Instantiate(spawnRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Spawn Room";
                    spawnRoomSpawned = true;
                }
                else if (j == 40 & i == 0 & bossRoomSide == 1)
                {
                    Debug.Log("Boss room " + bossRoomSide);
                    GameObject instance = Instantiate(bossRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Boss Room";
                    bossRoomSpawned = true;
                }
                else if (j == 0 & i == 40 & bossRoomSide == 2)
                {
                    Debug.Log("Boss room " + bossRoomSide);
                    GameObject instance = Instantiate(bossRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Boss Room";
                }
                else if (j == -40 & i == 0 & bossRoomSide == 3)
                {
                    Debug.Log("Boss room " + bossRoomSide);
                    GameObject instance = Instantiate(bossRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Boss Room";
                }
                else if (j == 0 & i == -40 & bossRoomSide == 4)
                {
                    Debug.Log("Boss room " + bossRoomSide);
                    GameObject instance = Instantiate(bossRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    instance.tag = "Boss Room";
                }
                else
                {
                    // Regular rooms
                    GameObject instance = Instantiate(connectingRoom, (gameObject.transform.position) + new Vector3(i, 0, j), Quaternion.identity) as GameObject;
                    edgeRoom = false;
                    AssignRoomType(instance, edgeRoom);
                }

                roomCount++;
            }
        }
    }

    void AssignRoomType(GameObject room, bool edgeRoom)
    {
        if (demibossRooms < demibossRoomsMax && edgeRoom) // if we have not reached the max cap of demiboss rooms and we're an edge room
        {
            int randomNumber = Random.Range(0, 101);
            Debug.Log(randomNumber);

            if (randomNumber < 50) // demi boss rooms have more weight so that the dungeon SHOULD include at least 1, later could loop through rooms if no demi boss rooms were spawned but it is statistically unlikely
            {
                room.tag = "Demi Boss Room";
                demibossRooms++;
                Debug.Log(room.tag);
            }

            else if (randomNumber > 49 && randomNumber < 70)
            {
                room.tag = "Resource Room";
                Debug.Log(room.tag);
            }
            else if (randomNumber > 69 && randomNumber < 90)
            {
                room.tag = "Combat Room";
                Debug.Log(room.tag);
            }
            else if (randomNumber > 89)
            {
                room.tag = "Mixed Room";
                Debug.Log(room.tag);
            }
            else
            {
                Debug.Log("Something went wrong in your room type assigner");
            }
        }

        else if (demibossRooms >= demibossRoomsMax && edgeRoom)// max amount of demiboss rooms, continue without checking for them
        {
            int randomNumber = Random.Range(0, 101);

            if (randomNumber < 40)
            {
                room.tag = "Resource Room";
                Debug.Log(room.tag);
            }
            else if (randomNumber > 39 && randomNumber < 80)
            {
                room.tag = "Combat Room";
                Debug.Log(room.tag);
            }
            else if (randomNumber > 79)
            {
                room.tag = "Mixed Room";
                Debug.Log(room.tag);
            }
            else
            {
                Debug.Log("Something went wrong in your room type assigner");
            }
        }

        else // this is a regular room
        {
            int randomNumber = Random.Range(0, 101);

            if (randomNumber < 40)
            {
                room.tag = "Resource Room";
                Debug.Log(room.tag);
            }
            else if (randomNumber > 39 && randomNumber < 80)
            {
                room.tag = "Combat Room";
                Debug.Log(room.tag);
            }
            else if (randomNumber > 79)
            {
                room.tag = "Mixed Room";
                Debug.Log(room.tag);
            }
            else
            {
                Debug.Log("Something went wrong in your room type assigner");
            }
        }
    }

    public void GenerateNavMesh()
    {
        surface.BuildNavMesh();
    }
}