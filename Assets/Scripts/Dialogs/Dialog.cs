using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Dialog : MonoBehaviour
{
    public NPCConversation[] conversations;
    private bool inCollider = false;

    private GameObject player;
    Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAnim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) &&  inCollider)
        {
            foreach (var conversation in conversations)
            {
                if(conversation.gameObject.activeSelf == true)
                {
                    ConversationManager.Instance.StartConversation(conversation);
                    break;
                }
            }
            
        }

        if (ConversationManager.Instance.IsConversationActive)
        {
            PlayerMove playerMove = player.GetComponent<PlayerMove>();
            playerMove.speed = 0;
            playerMove.enabled = false;
            playerAnim.SetBool("isRunning", false);
        }
        else
        {
            PlayerMove playerMove = player.GetComponent<PlayerMove>();
            playerMove.enabled = true;
            playerMove.speed = playerMove.maxSpeed;            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inCollider = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inCollider = false;
        }
    }
}
