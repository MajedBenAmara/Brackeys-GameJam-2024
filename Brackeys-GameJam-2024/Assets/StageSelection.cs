using UnityEngine;
using UnityEngine.UI;


public class StageSelection : MonoBehaviour
{
    public Node[] Stages;
    public Node Default;
    [SerializeField] EnemyBtn EnemyBtn;
    [SerializeField] Text StageText;
    public Node currentnode;
    [SerializeField] Text EnemyText;



    void Start()
    {
        foreach (Node node in Stages) 
        {
            
            Button button = node.gameObject.GetComponent<Button>();
            button.onClick.AddListener(() => CopyData(node));
            
        }
        CopyData(Default);
    }

    public void disablecurbutton()
    {
        if(currentnode != null) { 
            currentnode.GetComponent<Button>().interactable = false;
        
        }
    }

    void CopyData(Node node)
    {
        if (node.IsCompleted) 
        {
            node.GetComponent<Button>().interactable = false;
            return;

        }
        currentnode = node;
        FindAnyObjectByType<AudioManager>().Play("StageSelect");
        EnemyText.text = null;
        StageText.text = null;
        StageText.text += $"{node.Name}";
        for (int i = 0; i < node.EnemiesType.Length; i++)
        {
            EnemyText.text += $"{node.EnemiesType[i]} X {node.EnemiesNumber[i]}\n";
        }
        EnemyBtn.EnemiesType = node.EnemiesType;
        EnemyBtn.EnemiesNumber = node.EnemiesNumber;
        EnemyBtn.boss = node.Boss;
    }
}
