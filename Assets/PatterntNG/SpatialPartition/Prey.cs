﻿using UnityEngine;

public class Prey : MonoBehaviour, IUnit
{
    private int m_Square;

    public void AddToGrid(int square)
    {
        m_Square = square;
    }

    public int GetGridPosition()
    {
        return m_Square;
    }
}
