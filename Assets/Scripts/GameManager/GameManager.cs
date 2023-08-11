using Photon.Pun;
using UnityEngine;
using UnityEngine.UI; 
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    public int totalObjectsToCollect = 7;
    private int totalCollectedObjects = 0;
    public Text winText;

    private void Awake()
    {
        Instance = this;
    }

    public void CollectObject(int amount)
    {
        totalCollectedObjects += amount;
        CheckWinCondition();
        //Debug.Log(amount);
    }
    [PunRPC]
    private void CheckWinCondition()
    {
        if (totalCollectedObjects >= totalObjectsToCollect)
        {
            SceneManager.LoadScene("Win");
        }
    }

    private void AnnounceWinner()
    {
        winText.text = "¡Los jugadores han ganado!";
    }
}
