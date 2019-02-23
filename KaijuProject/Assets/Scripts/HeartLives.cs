using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartLives : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] HeartSprites;
    public Image HeartUI;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        HeartUI.sprite = HeartSprites[player.curHealth];
    }
}
