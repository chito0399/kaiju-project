using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject finalMenu;
    public EnemyManager kaiju;
    private int lifeKaiju;
    private bool lost;

    // Start is called before the first frame update
    void Start()
    {
        finalMenu.SetActive(false);
        lost = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (lost == true)
        {
            lifeKaiju = kaiju.gameObject.GetComponent<EnemyManager>().health;

            if (lifeKaiju <= 0)
            {
                lost = false;
                FinishGame();
            }
        }
        
    }

    public void FinishGame()
    {
        Debug.Log("YA SE ACABO EL JUEGO");
        Time.timeScale = 0;
        finalMenu.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("PERDIMOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOS");
            FinishGame();
        }
    }
}
