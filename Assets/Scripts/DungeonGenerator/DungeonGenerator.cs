using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    public DungeonGenerationData dungeonGenerationData;
    private List<Vector2Int> dungeonRooms;

    private void Start()
    {
        dungeonRooms = DungeonCrawlerController.GenerateDungeon(dungeonGenerationData);
        SpawnRooms(dungeonRooms);
    }

    private void SpawnRooms(IEnumerable<Vector2Int> rooms)
    {
        RoomController.instance.LoadRoom("Start", 0, 0);
        foreach(Vector2Int roomLocation in rooms)
        {
            int rand = Random.Range(1, 17);
            Debug.Log(rand);
            switch (rand)
            {
                case 1:
                    RoomController.instance.LoadRoom("Empty", roomLocation.x, roomLocation.y);
                break;

                case 2:
                    RoomController.instance.LoadRoom("Room01", roomLocation.x, roomLocation.y);
                break;

                case 3:
                    RoomController.instance.LoadRoom("Room02", roomLocation.x, roomLocation.y);
                    break;

                case 4:
                    RoomController.instance.LoadRoom("Room03", roomLocation.x, roomLocation.y);
                    break;

                case 5:
                    RoomController.instance.LoadRoom("Room04", roomLocation.x, roomLocation.y);
                    break;

                case 6:
                    RoomController.instance.LoadRoom("Room05", roomLocation.x, roomLocation.y);
                    break;

                case 7:
                    RoomController.instance.LoadRoom("Room06", roomLocation.x, roomLocation.y);
                    break;

                case 8:
                    RoomController.instance.LoadRoom("Room07", roomLocation.x, roomLocation.y);
                    break;

                case 9:
                    RoomController.instance.LoadRoom("Room08", roomLocation.x, roomLocation.y);
                    break;

                case 10:
                    RoomController.instance.LoadRoom("Room09", roomLocation.x, roomLocation.y);
                    break;

                case 11:
                    RoomController.instance.LoadRoom("Room10", roomLocation.x, roomLocation.y);
                    break;

                case 12:
                    RoomController.instance.LoadRoom("Room11", roomLocation.x, roomLocation.y);
                    break;

                case 13:
                    RoomController.instance.LoadRoom("Room12", roomLocation.x, roomLocation.y);
                    break;

                case 14:
                    RoomController.instance.LoadRoom("Room13", roomLocation.x, roomLocation.y);
                    break;

                case 15:
                    RoomController.instance.LoadRoom("Room14", roomLocation.x, roomLocation.y);
                    break;

                case 16:
                    RoomController.instance.LoadRoom("Room15", roomLocation.x, roomLocation.y);
                    break;
            }
                
                
        }
    }
}
