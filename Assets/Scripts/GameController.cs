﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Estado estado { get;  private set; }

    public GameObject obstaculo;
    public float espera;
    public float tempoDestruicao;

    public static GameController instancia = null;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia!= null)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
	void Start () {
        estado = Estado.AguardoComecar;
        StartCoroutine(GerarObstaculos());
	}

    IEnumerator GerarObstaculos()
    {
        while (GameController.instancia.estado == Estado.Jogando)
        {
            Vector3 pos = new Vector3(28f, Random.Range(-2.0f, 5.0f), 5.48f);
            GameObject obj = Instantiate(obstaculo, pos, Quaternion.identity) as GameObject;
            Destroy(obj, tempoDestruicao);
            yield return new WaitForSeconds(espera);
        }
    }
	
	public void PlayerComecou()
    {
        estado = Estado.Jogando;
        StartCoroutine(GerarObstaculos());
    }

    public void PlayerMorreu()
    {
        estado = Estado.GameOver;
    }
}
