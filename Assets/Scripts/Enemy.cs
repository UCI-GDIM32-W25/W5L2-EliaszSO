using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Assertions;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyStats _stats;

    [SerializeField] private DialogueBubble _dialogueBubble;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _dialogueDistance;

    private float timer = 0;
    private int displayLineNumber = 0;

    private void Start ()
    {
        _spriteRenderer.sortingOrder = -(int)transform.position.y;
    }

    private void Update ()
    {
        //periodically reset the timer and increment the line
        if (timer > _stats.textDisplaySpeed)
        {
            // increase the line number and reset timer
            displayLineNumber++;
            timer -= _stats.textDisplaySpeed;
            
            // reset line number if its greater than the number of lines in the list
            if(displayLineNumber > _stats.dialogueLine.Count)
            {
                displayLineNumber = 0;
            }
        }
        

        Player player = Player.Instance;
        Assert.IsNotNull(player);
        if(player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if(distance <= _dialogueDistance)
            {
                // increment the timer and show the current dialouge line
                timer += Time.deltaTime;
                _dialogueBubble.ShowDialogue(_stats.dialogueLine[displayLineNumber]);
            }
            else 
            {
                _dialogueBubble.HideDialogue();
                
                //reset the timer and line number
                timer = 0;
                displayLineNumber = 0;
            }
        }
    }
}
