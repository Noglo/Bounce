using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public ParticleSystem particles;

    public TextMeshProUGUI orbsLeftIndicator;
    public Transform orbsHolder;

    public int OrbsOnLevel;
    private int orbsOnLevelCount;

    void Start()
    {
        OrbsOnLevel = orbsHolder.childCount;
    }

    void Update()
    {
        if(orbsOnLevelCount != OrbsOnLevel)
        {
            orbsLeftIndicator.text = OrbsOnLevel.ToString();
            orbsOnLevelCount = OrbsOnLevel;
        }
        if (OrbsOnLevel == 0){
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void Death(){
        Instantiate(particles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
