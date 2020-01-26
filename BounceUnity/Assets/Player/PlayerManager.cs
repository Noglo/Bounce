using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public ParticleSystem particles;

    public TextMeshProUGUI orbsLeftIndicator;
    public Transform orbsHolder;

    public int orbsOnLevel;
    void Start()
    {
        orbsOnLevel = orbsHolder.childCount;
    }

    void Update()
    {
        orbsLeftIndicator.text = "" + orbsOnLevel;
        if (orbsOnLevel == 0){
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Death(){
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
