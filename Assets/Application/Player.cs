//*****************************************************************************
// Author: Arthur LeVesque
// Copyright: DefaultCompany, 2024
//*****************************************************************************

namespace SaltySnailStudios
{
    using System;
    using UnityEngine;
    using UnityEngine.UIElements;

    /// <summary>
    /// [INSERT CLASS COMMENT HERE]
    /// </summary>
    public static class Player
    {
        public static float Speed;
        public static int Health;
        public static void DecrementHealth(int value)
        {
            Health -= value;
        }

        public static void ApplyMovement(GameObject enemy, float deltaTime)
        {
            enemy.transform.position += new Vector3(x, y) Speed * deltaTime;
        }
    }
}
