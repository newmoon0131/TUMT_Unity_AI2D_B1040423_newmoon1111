using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public enum stat
    {
        一般,還沒完成,完成
    }
    public stat _state;

    public string start = "我需要10顆能量球!!!";
    public string notC = "快點，還不夠10顆!!!";
    public string C = "棒喔";

    public float speed = 1.5f;

    public bool c;
    public int countP;
    public int countf = 10;

    public GameObject objcan;
    public Text textsay;
    public GameObject final;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name=="玩家")
        {
            say();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "玩家")
        {
            sayclose();
        }
    }
    private void say()
    {
            objcan.SetActive(true);
            StopAllCoroutines();

        if (countP>=countf)
        {
            _state = stat.完成;
        }

        switch (_state)
        {
            case stat.一般:
                StartCoroutine(showD(start));
                _state = stat.還沒完成;
                break;
            case stat.還沒完成:
                StartCoroutine(showD(notC));
                break;
            case stat.完成:
                StartCoroutine(showD(C));
                break;
        }
    }
    private IEnumerator showD(string say)
    {
        textsay.text = "";
        for (int i = 0; i < say.Length; i++)
        {
            textsay.text += say[i].ToString();
            yield return new WaitForSeconds(speed);
        }
    }

    private void sayclose()
    {
        StopAllCoroutines();
        objcan.SetActive(false);
    }
    public void get()
    {
        countP++;
        if (countP>=10)
        {
            final.SetActive(true);
        }
    }
   
}
