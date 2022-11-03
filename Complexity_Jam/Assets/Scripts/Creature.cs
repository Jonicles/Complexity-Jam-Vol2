using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] List<GameObject> tileList = new List<GameObject>();
    [SerializeField] List<Organ> currentOrgansList = new List<Organ>();

    List<Organ> functioningOrgansList = new List<Organ>();
    int requiredBrainPieces;
    void Start()
    {
        
    }

    public void TileDisplay(bool show = true)
    {
        foreach (GameObject tile in tileList)
        {
            tile.SetActive(show);
        }
    }
    public void AddOrgan(Organ organToAdd)
    {
        currentOrgansList.Add(organToAdd);
        UpdateOrganStatus();;
    }

    public void RemoveOrgan(Organ organToRemove)
    {
        currentOrgansList.Remove(organToRemove);
        UpdateOrganStatus();
    }
    void UpdateOrganStatus()
    {
        int brainAmount = 0;
        int heartAmount = 0;
        int lungAmount = 0;
        int mouthAmount = 0;

        foreach (Organ organ in currentOrgansList)
        {
            if (organ.OrganEnabler)
            {
                brainAmount++;
            }
            else if (organ.BloodEnabler)
            {
                heartAmount++;
            }
            else if (organ.LungEnabler)
            {
                mouthAmount++;
            }
            else if (organ.OxygenEnabler)
            {
                lungAmount++;
            }
        }

        print($"Brain: {brainAmount} Heart: {heartAmount} Lung: {lungAmount} Mouth: {mouthAmount}");

        if(brainAmount > 0 && heartAmount > 0 && lungAmount > 0 && mouthAmount > 0)
        {
            foreach(Organ organ in currentOrgansList)
            {
                organ.Activate();
                print("Organs are now active");
            }
        }
        else
        {
            foreach (Organ organ in currentOrgansList)
            {
                organ.Deactivate();
                print("Organs are now non active");
            }
        }
    }

    void UpdateStatBars()
    {

    }
}
