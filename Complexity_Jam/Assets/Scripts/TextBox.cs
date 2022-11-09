using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
public enum LineType
{
    //Add more lineTypes here
    Level1,
    Level2,
    Level3,
    GameComplete,
    BasicFunc,
    NoMouth,
}

public class TextBox : MonoBehaviour
{
    [SerializeField] List<string> IntroductionLinesList = new List<string>();
    [SerializeField] List<string> Level2LineList = new List<string>();
    [SerializeField] List<string> Level3LineList = new List<string>();
    [SerializeField] List<string> GameCompletedLineList = new List<string>();

    [SerializeField] GameObject textBoxUI;
    [SerializeField] TextMeshProUGUI textBoxText;
    public static TextBox Instance;

    int currentLoopIndex = 0;
    public bool Looping { get; private set; }
    [System.Serializable]
    public class Line
    {
        [SerializeField] string name;
        [SerializeField] public LineType lineName;
        public List<string> lines = new List<string>();
        List<string> tempLines = new List<string>();

        public void Reset()
        {
            foreach (string line in tempLines)
            {
                lines.Add(line);
            }
        }

        public void CopyElements()
        {
            foreach (string line in lines)
            {
                tempLines.Add(line);
            }
        }

        public void Remove(string lineToRemove)
        {
            foreach (string line in lines)
            {
                if (line == lineToRemove)
                {
                    lines.Remove(line);
                }
            }
        }
    }

    [SerializeField] List<Line> lineList = new List<Line>();
    Dictionary<LineType, List<string>> lineDictionary = new Dictionary<LineType, List<string>>();


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

        foreach (Line line in lineList)
        {
            line.CopyElements();
            lineDictionary.Add(line.lineName, line.lines);
        }
    }

    public void PlayLine(LineType line)
    {
        int lineIndex = PickLine(line);
        TextBoxAppear(line, lineDictionary[line][lineIndex]);
        RemoveLine(line, lineIndex);
    }

    int PickLine(LineType lineToFind)
    {
        if (lineDictionary[lineToFind].Count == 0)
        {
            foreach (Line line in lineList)
            {
                if (line.lineName == lineToFind)
                {
                    line.Reset();
                }
            }
        }

        int rnd = Random.Range(0, lineDictionary[lineToFind].Count);
        return rnd;
    }

    void RemoveLine(LineType line, int lineIndex)
    {
        lineDictionary[line].Remove(lineDictionary[line][lineIndex]);
    }

    public bool TextBoxAppear(LineType lineType, string line)
    {
        bool finished = false;
        textBoxUI.SetActive(true);
        switch (lineType)
        {
            case LineType.Level1:
                ContiniousLines(IntroductionLinesList);
                if (currentLoopIndex == IntroductionLinesList.Count)
                {
                    finished = true;
                    currentLoopIndex = 0;
                    Looping = false;
                }
                break;
            case LineType.Level2:
                ContiniousLines(Level2LineList);
                if (currentLoopIndex == Level2LineList.Count)
                {
                    finished = true;
                    currentLoopIndex = 0;
                    Looping = false;
                }
                break;
            case LineType.Level3:
                ContiniousLines(Level3LineList);
                if (currentLoopIndex == Level3LineList.Count)
                {
                    finished = true;
                    currentLoopIndex = 0;
                    Looping = false;
                }
                break;
            case LineType.GameComplete:
                break;
            default:
                textBoxText.text = line;
                finished = true;
                break;
        }

        return finished;
    }

    private void ContiniousLines(List<string> lineList)
    {
        Looping = true;
        textBoxText.text = lineList[currentLoopIndex];
        currentLoopIndex++;
    }

    public void TextBoxDisappear()
    {
        textBoxUI.SetActive(false);
    }
}

