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
    private int phase; // 성장단계
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
        // 성장 로직
        if(DateManager.Main.season != Season.Spring) // 직전시즌이 겨울이 아닐때만
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
        // 스프라이트 로직
        if (treeIsStump) // 잘려있다면
        {
            treeSprite.sprite = stump;
        }
        else // 잘려있지 않다면
        {
            if (DateManager.Main.season == Season.Winter) // Winter 로직
            {
                treeSprite.sprite = unleaf[phase];
            }
            else // not Winter 로직
            {
                treeSprite.sprite = leaf[phase];
            }
        }
    }


}
