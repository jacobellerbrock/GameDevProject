using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public enum Stage
    {
        Drawing,
        Placement,
        Movement,
        Evaluate
    }

    [SerializeField] private TextMeshProUGUI stageText;

    public Stage stage = Stage.Drawing;

    // Start is called before the first frame update
    void Start()
    {
        LoadStage();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) NextStage();
    }
    
    public void NextStage()
    {
        //advance stage
        stage = (stage == Stage.Evaluate) ? Stage.Drawing : stage + 1;
        LoadStage();
    }

    void LoadStage()
    {
        //change text
        string newtext = "";
        switch (stage)
        {
            case Stage.Drawing: newtext = "Drawing";
                break;
            case Stage.Placement: newtext = "Placement";
                break;
            case Stage.Movement: newtext = "Movement";
                break;
            case Stage.Evaluate: newtext = "Evaluate";
                break;
        }
        stageText.text = newtext;
        
        //initiate each stage
        switch (stage)
        {
            case Stage.Drawing: InitDrawingStage();
                break;
            case Stage.Placement: InitPlacementStage();
                break;
            case Stage.Movement: InitMovementStage();
                break;
            case Stage.Evaluate: InitEvaluateStage();
                break;
        }
    }

    void InitDrawingStage()
    {
        Debug.Log("TODO: DRAW CARDS");
    }

    void InitPlacementStage()
    {
        Debug.Log("TODO: Start Placement Stage");
    }

    void InitMovementStage()
    {
        Debug.Log("TODO: Start Movement Stage");
    }

    void InitEvaluateStage()
    {
        Debug.Log("TODO: Evaluate Stage");
    }
}
