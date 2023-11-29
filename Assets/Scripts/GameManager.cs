using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public bool isTalking;
    public GameObject _talkPanel;
    public TMP_Text _talking;
    public GameObject _npc;
    
    public int velocity = 0;
    public void Talk(GameObject _Npc)
    {

        if (isTalking)
        {
            isTalking = false;

            velocity = 0;

        }
        else
        {
            isTalking=true;

            velocity = 1;

            _npc = _Npc;
            _talking.text = $"¿À¼Ì±º¿ä.{_npc.name}´Ô.";
        }


        _talkPanel.SetActive(isTalking);
    }

}
