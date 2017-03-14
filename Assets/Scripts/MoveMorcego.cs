﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMorcego : MonoBehaviour
{

    public float velocidade = 1f;
    public float velocidadeHorizontal;
    public float velocidadeVertical;
    public float min;
    public float max;
    public float espera;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Move(max));
    }

   IEnumerator Move(float destino)
    {
        while(Mathf.Abs(destino - transform.localPosition.y) > 0.3f) {
   
            Vector3 direcao2 = (destino == max) ? Vector3.up : Vector3.down;
           
            Vector3 velocidadeVetorial2 = direcao2 * velocidadeVertical;

            transform.localPosition = transform.localPosition + velocidadeVetorial2 * Time.deltaTime;

            yield return null;

        }

        yield return new WaitForSeconds(espera);

        destino = (destino == max) ? min : max;
        StartCoroutine(Move(destino));
    }

    void Update()
    {

        Vector3 velocidadeVetorial = Vector3.left * velocidade;

        transform.position = transform.position + velocidadeVetorial * Time.deltaTime;


    }
    }