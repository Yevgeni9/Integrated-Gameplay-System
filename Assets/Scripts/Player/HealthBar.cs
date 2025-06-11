using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar
{
    private List<GameObject> blocks;

    public HealthBar(Transform blockContainer, GameObject blockPrefab, int initialHealth)
    {
        blocks = new List<GameObject>();

        for (int i = 0; i < initialHealth; i++)
        {
            GameObject block = GameObject.Instantiate(blockPrefab, blockContainer);
            blocks.Add(block);
        }
    }

    public void UpdateHealthBar(int currentHealth)
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].SetActive(i < currentHealth);
        }
    }
}
