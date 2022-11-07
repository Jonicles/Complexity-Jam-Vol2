using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<GameObject> tileList = new List<GameObject>();
    [SerializeField] Creature currentCreature;
    [SerializeField] GameObject heartBarObject;
    [SerializeField] GameObject brainBarObject;
    [SerializeField] GameObject lungBarObject;

    StatBar heartBar;
    StatBar brainBar;
    StatBar lungBar;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }


    public void PlaceOrgan(Organ organToAdd)
    {
        currentCreature.AddOrgan(organToAdd);
    }

    public void RemoveOrgan(Organ organToRemove)
    {
        currentCreature.RemoveOrgan(organToRemove);
    }

    public void UpdateStatBars(float blood, float oxygen, float fuel, float brainAmount)
    {
        heartBar.UpdateValue(blood);
        lungBar.UpdateValue(oxygen);
        brainBar.UpdateValue(brainAmount);
    }

    public void DisplayTiles(bool show = true)
    {
        currentCreature.DisplayTiles(show);
    }
}
