using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class StickCollection : MonoBehaviour
{

    private int _stickcount = 0;
    public TextMeshProUGUI _stickText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _stickcount += 1;
            
            _stickText.text = "Sticks: " + _stickcount.ToString();
            Destroy(this.gameObject);
        }
    }

}
