using UnityEngine;

[CreateAssetMenu(fileName = "DungeonGenerationData.asset", menuName = "DungeonGenerationData/Dungeon Data")]

public class DungeonGenerationData : ScriptableObject
{
    public int numberofCrawlers;
    public int iterationMin;
    public int iterationMax;
}
