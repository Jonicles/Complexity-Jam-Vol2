using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<GameObject> tileList = new List<GameObject>();
    [SerializeField] Creature currentCreature;
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

        //foreach (Organ organ in organList)
        //{
        //    print($"{organ.BloodProd}, {organ.OxygenUsage}, {organ.FuelUsage}");
        //}
    }

    private void Update()
    {

    }

    public void PlaceOrgan(Organ organToAdd)
    {
        currentCreature.AddOrgan(organToAdd);
    }

    public void RemoveOrgan(Organ organToRemove)
    {
        currentCreature.RemoveOrgan(organToRemove);
    }

    public void TileDisplay(bool show = true)
    {
        currentCreature.TileDisplay(show);
    }
}
