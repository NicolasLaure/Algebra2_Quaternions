using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicios : MonoBehaviour
{
    [SerializeField] private EjerciciosEnum currentExercise;
    [SerializeField] private float angle;

    void Update()
    {
        switch (currentExercise)
        {
            case EjerciciosEnum.Uno:
                break;
            case EjerciciosEnum.Dos:
                break;
            case EjerciciosEnum.Tres:
                break;
            default:
                break;
        }
    }
}
