using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratulationsWritings : MonoBehaviour
{
    public List<GameObject> writings;
    private void Start()
    {
        GameEvents.ShowCongratulationWritings += ShowCongratulationWritings;
    }

    private void OnDisable()
    {
        GameEvents.ShowCongratulationWritings -= ShowCongratulationWritings;
    }
    private void ShowCongratulationWritings()
    {
        var index = UnityEngine.Random.Range(0, writings.Count);
        writings[index].SetActive(true);
    }

}