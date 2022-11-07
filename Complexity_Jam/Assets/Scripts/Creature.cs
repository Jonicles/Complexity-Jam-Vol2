using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] List<Tile> tileList = new List<Tile>();
    [SerializeField] List<Organ> currentOrgansList = new List<Organ>();

    List<Organ> functioningOrgansList = new List<Organ>();

    [SerializeField] float brainPowerAmount = 3;
    [SerializeField] float mouthPowerAmount = 2;
    void Start()
    {

    }

    public void DisplayTiles(bool show = true)
    {
        foreach (Tile tile in tileList)
        {
            tile.Show(show);
        }
    }
    public void AddOrgan(Organ organToAdd)
    {
        currentOrgansList.Add(organToAdd);
        UpdateOrganStatus(); ;
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
        float totalBloodUsage = 0;
        float totalOxygenUsage = 0;
        float totalFuelUsage = 0;

        float totalBloodProd = 0;
        float totalOxygenProd = 0;
        float totalFuelSpace = 0;

        float lungsToActivate = mouthAmount * mouthPowerAmount;
        float organsToActivate = brainAmount * brainPowerAmount;

        if (brainAmount > 0 && heartAmount > 0 && lungAmount > 0 && mouthAmount > 0)
        {
            foreach (Organ organ in currentOrgansList)
            {
                //Activates the amount of organs equivalent to brainpower
                if (!organ.OrganEnabler)
                    organsToActivate--;
                else
                    organ.Activate();

                if (organsToActivate >= 0)
                {
                    //Activates lungs
                    if (organ.OxygenEnabler)
                    {
                        lungsToActivate--;

                        if (lungsToActivate >= 0)
                            organ.Activate();
                    }
                    else
                        organ.Activate();

                }

                if (organ.IsActive)
                {
                    totalBloodUsage += organ.BloodUsage;
                    totalOxygenUsage += organ.OxygenUsage;
                    totalFuelUsage += organ.FuelUsage;

                    totalBloodProd += organ.BloodProd;
                    totalOxygenProd += organ.OxygenProd;
                    totalFuelSpace += organ.FuelSpace;
                }
            }
        }
        else
        {
            foreach (Organ organ in currentOrgansList)
            {
                organ.Deactivate();
            }
        }

        foreach (Organ organ in currentOrgansList)
        {
            if (organ.IsActive)
            {
                print(organ.name + " is active");
            }
            else
                print(organ.name + " is not active");
        }

        //Updates statbars
        GameManager.Instance.UpdateStatBars(totalBloodProd - totalBloodUsage, totalOxygenProd - totalOxygenUsage, totalFuelSpace - totalFuelUsage, brainAmount);
        //print($"Blood: {totalBloodProd - totalBloodUsage}, Oxygen: {totalOxygenProd - totalOxygenUsage}, Fuel: {totalFuelSpace - totalFuelUsage}");
    }
}
