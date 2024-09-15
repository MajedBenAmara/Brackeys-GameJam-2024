using UnityEngine;

public class Node : MonoBehaviour
{
    public string Name;
    public string[] EnemiesType;
    public int[] EnemiesNumber;

    public bool Boss = false;

    public bool IsLocked = true;
    public bool IsCompleted = false;

}
