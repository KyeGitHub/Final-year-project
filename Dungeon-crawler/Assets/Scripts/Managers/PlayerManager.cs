﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] public GameObject player;
    [SerializeField] private PlayerMotor playerMotor;

}

