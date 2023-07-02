using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] bool win = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            win = true;
        }
    }

    public void Update()
    {
        if (win) GameWin();
    }

    public void GameWin()
    {
        panel.SetActive(true);
    }
}
