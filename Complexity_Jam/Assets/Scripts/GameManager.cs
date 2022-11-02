using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] List<GameObject> tileList = new List<GameObject>();
    [SerializeField] List<Organ> organList = new List<Organ>();
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

        foreach (Organ organ in organList)
        {
            print($"{organ.BloodProd}, {organ.OxygenUsage}, {organ.FuelUsage}");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (Organ organ in organList)
            {
                if (!organ.IsActive)
                {
                    organ.Activate();
                    print($"{organ.BloodProd}, {organ.OxygenUsage}, {organ.FuelUsage}");
                }
                else
                {
                    organ.Deactivate();
                    print($"{organ.BloodProd}, {organ.OxygenUsage}, {organ.FuelUsage}");
                }
            }
        }
    }

    public void DisplayTiles(bool show = true)
    {
        foreach (GameObject tile in tileList)
        {
            tile.SetActive(show);
        }
    }
}
