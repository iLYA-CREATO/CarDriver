using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDate : MonoBehaviour
{
    public GameObject ReaclamShow;
    void Awake()
    {
        // Получаем текущую UTC дату и время
        DateTime currentUTC = DateTime.UtcNow;

        // Задаем целевую дату
        DateTime targetDate = new DateTime(2024, 10, 10);

        // Проверяем, прошла ли целевая дата
        if (currentUTC >= targetDate)
        {
            ReaclamShow.SetActive(true);
        }
        else if (currentUTC < targetDate)
        {
            ReaclamShow.SetActive(false);
        }
    }
}
