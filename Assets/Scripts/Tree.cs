using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Tree : MonoBehaviour
{
    private SpriteRenderer treeSprite;

    [SerializeField]
    private Sprite[] leaf;
    [SerializeField]
    private Sprite[] unleaf;
    [SerializeField] 
    private Sprite stump;
    [SerializeField]
    private int phase; // ����ܰ�
    [SerializeField]
    private bool treeIsStump;

    private void Awake()
    {
        treeSprite = GetComponent<SpriteRenderer>();
        phase = 0;
        treeIsStump = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Drawing();
        DateManager.Main.SeasonChange.AddListener(PlusAge);
    }

    private void PlusAge()
    {
        // ���� ����
        if(DateManager.Main.season != Season.Spring) // ���������� �ܿ��� �ƴҶ���
        {
            if (treeIsStump)
            {
                treeIsStump = false;
            }
            else if (phase < 2)
            {
                phase++;
            }
        }
        Drawing();
    }

    void Drawing()
    {
        // ��������Ʈ ����
        if (treeIsStump) // �߷��ִٸ�
        {
            treeSprite.sprite = stump;
        }
        else // �߷����� �ʴٸ�
        {
            if (DateManager.Main.season == Season.Winter) // Winter ����
            {
                treeSprite.sprite = unleaf[phase];
            }
            else // not Winter ����
            {
                treeSprite.sprite = leaf[phase];
            }
        }
    }


}
