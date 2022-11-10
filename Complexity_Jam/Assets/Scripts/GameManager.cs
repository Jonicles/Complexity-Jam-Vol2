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

        float mouthAmount = 0, brainAmount = 0, heartAmount = 0, lungAmount = 0;

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
            if (organ.OxygenEnabler && organ.IsActive)
            {
                lungAmount++;
            }
        }

        if (brainAmount <= 0 || heartAmount <= 0 || lungAmount <= 0 || mouthAmount <= 0)
        {
            print("Doesn't pass basic functionality test");
            TextBox.Instance.PlayLine(LineType.BasicFunc);
            //Doesn't pass basic functionality test
        }
        else
        {
            //if (creaturenumber > 1 && fuelamount X)
            //{

            //}

            //if(reproduction X)
            //Passes basic functionlity test
            if (lungAmount <= 2)
            {
                print("Does not pass lung test, just two lungs wont cut it in this environment");
                //Does not pass lung test, just two lungs wont cut it in this environment
            }
            else if (lungBar.CurrentValue <= 0)
            {
                print("Is not self sustaining oxygenwise");
                //Is not self sustaining oxygenwise
            }
            else if (heartBar.CurrentValue <= 0)
            {
                print("Is not self sustaining blood wise");
                //Is not self sustaining blood wise
            }
            else if (heartBar.CurrentValue < currentCreature.BloodRequirement)
            {
                print("Does not pass test for blood production for current creature");
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
                print("Creature passes all tests!");
                //Creature passes all tests!
            }
        }


    }
}
