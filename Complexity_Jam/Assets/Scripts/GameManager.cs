using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] Creature currentCreature;
    [SerializeField] List<GameObject> creatureList = new List<GameObject>();
    [SerializeField] StatBar heartBar;
    [SerializeField] StatBar brainBar;
    [SerializeField] StatBar lungBar;
    [SerializeField] GameObject containers;

    [SerializeField] int creatureNumber = 1;
    [SerializeField] float[] bloodRequirements = { 10, 20, 30 };

    Vector3 startPos = new Vector3(0, -0.75f);
    LineType currentLineType;

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

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TextBox.Instance.Looping && !TextBox.Instance.TextBoxAppear(currentLineType, "")) { }
            else
            {
                TextBox.Instance.TextBoxDisappear();
            }
        }
    }

    private void Start()
    {
        currentLineType = LineType.Level1;
        TextBox.Instance.PlayLine(LineType.Level1);
    }

    public void ContainersAppear()
    {
        containers.SetActive(true);
    }

    public void ContainersDisappear()
    {
        containers.SetActive(false);
    }

    public void PlaceCreature()
    {
        if (currentCreature != null)
            Destroy(currentCreature.gameObject);
        GameObject tempObject = Instantiate(creatureList[creatureNumber], startPos, Quaternion.identity);
        currentCreature = tempObject.GetComponent<Creature>();
        UpdateStatBars(0, 0, 0, 0);
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

    public void WinLoseCheck()
    {
        List<Organ> currentOrgans = currentCreature.CurrentOrgans();

        float mouthAmount = 0, brainAmount = 0, heartAmount = 0, lungAmount = 0, totalLungAmount = 0;

        foreach (Organ organ in currentOrgans)
        {
            if (organ.OrganEnabler && organ.IsActive)
            {
                brainAmount++;
            }
            if (organ.BloodEnabler && organ.IsActive)
            {
                heartAmount++;
            }
            if (organ.LungEnabler && organ.IsActive)
            {
                mouthAmount++;
            }
            if (organ.OxygenEnabler)
            {
                totalLungAmount++;
                if (organ.IsActive)
                {
                    lungAmount++;
                }
            }
        }

        if (brainAmount <= 0)
        {
            TextBox.Instance.PlayLine(LineType.NoBrain);
        }
        else if (brainAmount <= 0 || heartAmount <= 0 || lungAmount <= 0 || mouthAmount <= 0)
        {
            TextBox.Instance.PlayLine(LineType.NoBasicFun);
            //Doesn't pass basic functionality test
        }
        else
        {
            if (lungAmount <= 2)
            {
                if (totalLungAmount < mouthAmount * 2)
                {
                    TextBox.Instance.PlayLine(LineType.NoLungs);
                }
                else
                {
                    TextBox.Instance.PlayLine(LineType.NoMouth);
                }
                //Does not pass lung test, just two lungs wont cut it in this environment
            }
            else if (lungBar.CurrentValue <= 0)
            {
                TextBox.Instance.PlayLine(LineType.NoOxygen);
                //Is not self sustaining oxygenwise
            }
            else if (heartBar.CurrentValue <= 0)
            {
                TextBox.Instance.PlayLine(LineType.NoBlood);
                //Is not self sustaining blood wise
            }
            else if (heartBar.CurrentValue < currentCreature.BloodRequirement)
            {
                TextBox.Instance.PlayLine(LineType.NoRequirement);
                //Does not pass test for blood production for current creature
            }
            else if (brainAmount > 8)
            {
                print("Creature is sentient! KILL IT");
            }
            else
            {
                creatureNumber++;
                if (creatureNumber == 1)
                {
                    currentLineType = LineType.Level2;
                }
                else if (creatureNumber == 2)
                {
                    currentLineType = LineType.Level3;
                }
                else if (creatureNumber == 3)
                {
                    currentLineType = LineType.GameComplete;
                }
                TextBox.Instance.PlayLine(currentLineType);
                //Creature passes all tests!
            }
        }


    }
}
