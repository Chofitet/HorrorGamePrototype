using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineStop : MonoBehaviour
{
    AudioSource verterAgua;
    [SerializeField] GameObject lavadoraSound;
    MultipleTrigger multipleTrigger;
    [SerializeField] GameObject Shoe;
    [SerializeField] AudioSource finLavaropa;
    [SerializeField] Collider TapaLavadora;
    SoundManager SM;
    // Start is called before the first frame update
    void Start()
    {
        verterAgua = GetComponentInChildren<AudioSource>();
        multipleTrigger = GetComponent<MultipleTrigger>();
        SM = FindObjectOfType<SoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (multipleTrigger.onTrigger)
        {
            SM.PlaySoud(verterAgua);
            StartCoroutine(stop());
        }
    }

    IEnumerator stop()
    {
        yield return new WaitForSeconds (verterAgua.clip.length);
        Shoe.SetActive(true);
        SM.PlaySoud(finLavaropa);
        TapaLavadora.enabled = true;
        Destroy(lavadoraSound);
    }
}
