using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    // Ќачальные и конечные координаты
    private Vector3 startPosition = new Vector3(23.64f, 3.1378f, -50.79f);
    private Vector3 endPosition = new Vector3(23.64f, 3.1378f, -350f);

    // —корость движени€ поезда
    public float speed = 2f;

    // “екуща€ цель (начальна€ или конечна€ позици€)
    private Vector3 targetPosition;

    void Start()
    {
        // ”станавливаем начальную позицию и цель
        transform.position = startPosition;
        targetPosition = endPosition;
    }

    void Update()
    {
        // ƒвигаем поезд к текущей цели
        MoveTrain();
    }

    private void MoveTrain()
    {
        // ƒвигаем поезд к цели
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ѕровер€ем, достиг ли поезд цели
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // “елепортируем поезд в начальную позицию, если он достиг конечной
            if (targetPosition == endPosition)
            {
                transform.position = startPosition;
                targetPosition = endPosition; // —нова устанавливаем цель на конечную позицию
            }
            else
            {
                targetPosition = endPosition; // ”станавливаем цель на конечную позицию
            }
        }
    }
}