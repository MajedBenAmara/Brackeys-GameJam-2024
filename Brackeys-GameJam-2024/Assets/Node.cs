using UnityEngine;

public class Node : MonoBehaviour
{
    public string Name;
    public string[] EnemiesType;
    public int[] EnemiesNumber;

    [SerializeField] GameObject Next;

    private void Start()
    {
        if (Next != null)
        {
            Debug.Log("Hello");
        }
    }





}
