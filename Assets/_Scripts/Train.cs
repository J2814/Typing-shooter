using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    private AudioSource m_AudioSource;

    private Vector3 startPosition = new Vector3(23.64f, 3.1378f, -50.79f);
    private Vector3 endPosition = new Vector3(23.64f, 3.1378f, -350f);

    public float speed = 2f;

    private Vector3 targetPosition;
    private void OnEnable()
    {
        PauseUIManager.PauseEnabled += PauseSound;
        PauseUIManager.PauseDisabled += UnpauseSound;
    }
    private void OnDisable()
    {
        PauseUIManager.PauseEnabled -= PauseSound;
        PauseUIManager.PauseDisabled -= UnpauseSound;
    }
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        transform.position = startPosition;
        targetPosition = endPosition;
    }

    void Update()
    {
        MoveTrain();
    }

    private void MoveTrain()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (targetPosition == endPosition)
            {
                transform.position = startPosition;
                targetPosition = endPosition; 
            }
            else
            {
                targetPosition = endPosition; 
            }
        }
    }

    private void PauseSound()
    {
        m_AudioSource.Pause();
    }

    private void UnpauseSound()
    {
        m_AudioSource.Play();
    }
}