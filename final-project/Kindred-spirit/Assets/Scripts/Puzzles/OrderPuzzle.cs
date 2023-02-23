using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class OrderPuzzle : MonoBehaviour
{
    [Serializable]
    public struct PuzzlePairs
    {
        public GameObject fire;
        public GameObject trigger;
    }
    public UnityEvent puzzleComplete;

    public PuzzlePairs[] puzzlePairs;
    public List<GameObject> winningPadOrder;
    private int startTrigger = 0;
    private int triggerNumber;

    private AudioSource puzzleSound;
    public AudioClip correctSound;
    public AudioClip incorrectSound;

    private void Start()
    {
        puzzleSound = GetComponent<AudioSource>();
        triggerNumber = startTrigger;
        RandomiseWinningOrder();
    }
    public void RandomiseWinningOrder()
    {
        //TODO - Randomise winning pad order
    }
    public void PuzzlePairsTigger(GameObject triggerObj)
    {
        Debug.Log("triggered");
        if (!CheckCompletion())
        {
            if (winningPadOrder[triggerNumber].gameObject == triggerObj)
            {
                triggerNumber++;
                for (int i = 0; i < puzzlePairs.Length; i++)
                {
                    if (puzzlePairs[i].trigger == triggerObj)
                    {
                        puzzlePairs[i].fire.gameObject.SetActive(true);
                        puzzleSound.clip = correctSound;
                        puzzleSound.Play();
                        if (CheckCompletion())
                        {
                            PuzzleComplete();
                        }
                        return;
                    }
                }
            }
            else
            {
                puzzleSound.clip = incorrectSound;
                puzzleSound.Play();
                triggerNumber = startTrigger;
                for (int i = 0; i < puzzlePairs.Length; i++)
                {
                    puzzlePairs[i].fire.gameObject.SetActive(false);
                }
            }
        }
    }
    public bool CheckCompletion()
    {
        int checkCount = 0;
        for(int i = 0; i < puzzlePairs.Length; i++)
        {
            if (puzzlePairs[i].fire.gameObject.activeSelf == true)
            {
                checkCount++;
            }
        }
        
        if(checkCount == puzzlePairs.Length)
        {
            Debug.Log("COMPLETE!");
            return true;
        } else
        {
            Debug.Log("not complete!");
            return false;         
        }
    }
    public void PuzzleComplete()
    {
        for (int i = 0; i < puzzlePairs.Length; i++)
        {
            puzzlePairs[i].trigger.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        
        puzzleComplete.Invoke();
    }
}
