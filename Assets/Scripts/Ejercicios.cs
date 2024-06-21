using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ejercicios : MonoBehaviour
{

    [SerializeField] private EjerciciosEnum currentExercise;
    [SerializeField] private float angle;
    [SerializeField] private GameObject linePrefab;
    [SerializeField] private Color lineColor;

    private EjerciciosEnum prevFrameSelectedExercise = EjerciciosEnum.Uno;
    private LineRenderer firstLine;
    private LineRenderer secondLine;
    private LineRenderer thirdLine;
    private LineRenderer fourthLine;


    #region ExerciseVariables
    private int offset = 10;
    private Vector3 firstPoint;
    private Vector3 secondPoint;
    private Vector3 thirdPoint;
    private Vector3 fourthPoint;

    Quaternion firstExerciseRotation = Quaternion.identity;
    Quaternion secondExerciseRotation = Quaternion.identity;
    Quaternion thirdExerciseRotation = Quaternion.identity;

    #endregion

    private void Start()
    {
        InitializeLine(out firstLine, "FirstSegment", lineColor);
        InitializeLine(out secondLine, "SecondSegment", lineColor);
        InitializeLine(out thirdLine, "ThirdSegment", lineColor);
        InitializeLine(out fourthLine, "FourthSegment", lineColor);

        SetExerciseLines();
        prevFrameSelectedExercise = currentExercise;
    }

    private void Update()
    {
        if (prevFrameSelectedExercise != currentExercise)
        {
            SetExerciseLines();
            prevFrameSelectedExercise = currentExercise;
        }
        else
            UpdateExerciseLines();
    }
    private void SetExerciseLines()
    {
        SetPointsDefaultValues();
        firstLine.gameObject.SetActive(true);
        secondLine.gameObject.SetActive(false);
        thirdLine.gameObject.SetActive(false);
        fourthLine.gameObject.SetActive(false);

        switch (currentExercise)
        {
            case EjerciciosEnum.Uno:
                SetVector(firstPoint, ref firstLine);
                break;
            case EjerciciosEnum.Dos:
                secondLine.gameObject.SetActive(true);
                thirdLine.gameObject.SetActive(true);

                SetLine(firstPoint, secondPoint, ref secondLine);
                SetLine(secondPoint, thirdPoint, ref thirdLine);
                break;
            case EjerciciosEnum.Tres:
                secondLine.gameObject.SetActive(true);
                thirdLine.gameObject.SetActive(true);
                fourthLine.gameObject.SetActive(true);

                SetLine(firstPoint, secondPoint, ref secondLine);
                SetLine(secondPoint, thirdPoint, ref thirdLine);
                SetLine(thirdPoint, fourthPoint, ref fourthLine);
                break;
            default:
                break;
        }
    }

    private void UpdateExerciseLines()
    {
        switch (currentExercise)
        {
            case EjerciciosEnum.Uno:
                firstExerciseRotation *= Quaternion.AngleAxis(angle, Vector3.up);
                SetVector(firstExerciseRotation * firstPoint, ref firstLine);
                break;
            case EjerciciosEnum.Dos:
                secondExerciseRotation *= Quaternion.AngleAxis(angle, Vector3.up);

                Vector3 firstPointRes = secondExerciseRotation * firstPoint;
                Vector3 secondPointRes = secondExerciseRotation * secondPoint;
                SetVector(firstPointRes, ref firstLine);
                SetLine(firstPointRes, secondPointRes, ref secondLine);
                SetLine(secondPointRes, secondExerciseRotation * thirdPoint, ref thirdLine);
                break;
            case EjerciciosEnum.Tres:
                break;
            default:
                break;
        }
    }

    private void SetPointsDefaultValues()
    {
        Vector3 horizontalOffset = new Vector3(offset, 0, 0);
        Vector3 verticalOffset = new Vector3(0, offset, 0);
        firstPoint = horizontalOffset;
        secondPoint = firstPoint + verticalOffset;
        thirdPoint = secondPoint + horizontalOffset;
        fourthPoint = thirdPoint + verticalOffset;
    }
    #region LineRendering
    private void InitializeLine(out LineRenderer line, string name, Color color)
    {
        GameObject spawnedLine = Instantiate(linePrefab, this.transform);

        spawnedLine.name = name;
        line = spawnedLine.GetComponent<LineRenderer>();
        line.startColor = color;
        line.endColor = color;
    }

    private void SetVector(Vector3 vector, ref LineRenderer line)
    {
        line.SetPosition(1, vector);
        string vectorText = @$"{line.gameObject.name}:
            X: {vector.x}
            Y: {vector.y}
            Z: {vector.z}";
        Transform textGO = line.gameObject.transform.GetChild(0);
        textGO.position = vector;
        TextMeshPro tmpText = textGO.GetComponent<TextMeshPro>();
        tmpText.text = vectorText;
        tmpText.color = line.startColor;
    }

    private void SetLine(Vector3 start, Vector3 end, ref LineRenderer line)
    {
        line.SetPosition(0, start);
        line.SetPosition(1, end);
        string vectorText = @$"{line.gameObject.name}:
            X: {end.x}
            Y: {end.y}
            Z: {end.z}";
        Transform textGO = line.gameObject.transform.GetChild(0);
        textGO.position = end;
        TextMeshPro tmpText = textGO.GetComponent<TextMeshPro>();
        tmpText.text = vectorText;
        tmpText.color = line.startColor;
    }
    #endregion
}
