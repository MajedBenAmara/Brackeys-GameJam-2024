using UnityEngine;
using UnityEngine.UI;


public class StageSelection : MonoBehaviour
{
    public Node[] Stages;
    [SerializeField] EnemyBtn EnemyBtn;
    [SerializeField] Text StageText;

    [SerializeField] Text EnemyText;



    void Start()
    {
        foreach (Node node in Stages) 
        {
            Button button = node.gameObject.GetComponent<Button>();
            button.onClick.AddListener(() => CopyData(node));
        }
    }

    void CopyData(Node node)
    {
        EnemyText.text = null;
        StageText.text = null;
        StageText.text += $"{node.Name}";
        for (int i = 0; i < node.EnemiesType.Length; i++)
        {
            EnemyText.text += $"{node.EnemiesType[i]} X {node.EnemiesNumber[i]}\n";
        }
        EnemyBtn.EnemiesType = node.EnemiesType;
        EnemyBtn.EnemiesNumber = node.EnemiesNumber;
    }
}
