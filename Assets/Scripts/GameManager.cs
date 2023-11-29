using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{

    public bool isTalking;
    public GameObject _talkPanel;
    public TMP_Text _talking;
    public GameObject _gameObj;//여기에는 Rayhit로 가져온 targetObject가 들어갈공간임.
    
    public int velocity;
    public void Talk(GameObject gameobj)
    {

        

        if (isTalking)
        {
            isTalking = false;

            velocity = 1;

        }
        else
        {
            isTalking=true;

            velocity = 0;

            _gameObj = gameobj;
            _talking.text = $"Hello? Mr.{_gameObj.name}.";
        }


        _talkPanel.SetActive(isTalking);
    }

}
