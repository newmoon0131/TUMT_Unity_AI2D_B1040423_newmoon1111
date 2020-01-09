using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CCC
{
    public class GM : MonoBehaviour
    {
        public void ReP()
        {
            SceneManager.LoadScene("遊戲");
        }
        public void Qit()
        {
            Application.Quit();
        }
    }
}