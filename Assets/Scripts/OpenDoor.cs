using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Menu
{
    // This script is for loading scenes from the main menu.
    // Each 'button' will be a rendering showing the scene
    // that will be loaded and use the SelectionRadial.
    public class OpenDoor : MonoBehaviour
    {
        public event Action<OpenDoor> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

        
        [SerializeField] private SelectionRadial m_SelectionRadial;         // This controls when the selection is complete.
        [SerializeField] private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.

        public AudioClip[] _AudioDoor;
        public AudioSource Src;

        public GameObject Door;
        public bool DoorOpened;


        private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.

        private void Update()
        {
            
            if (DoorOpened)
            {
                if (Door.transform.eulerAngles.y >= 180 && Door.transform.eulerAngles.y <= 271 )
                {
                    Door.transform.Rotate(0,0,Time.deltaTime * 50);
                }
                if (Door.transform.eulerAngles.y <= 180) {
                    DoorOpened = false;
                    Door.GetComponent<Collider>().enabled = false;
                }
            }
        }

        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_SelectionRadial.OnSelectionComplete += HandleSelectionComplete;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_SelectionRadial.OnSelectionComplete -= HandleSelectionComplete;
        }


        private void HandleOver()
        {
            // When the user looks at the rendering of the scene, show the radial.
            m_SelectionRadial.Show();

            m_GazeOver = true;

        }


        private void HandleOut()
        {
            // When the user looks away from the rendering of the scene, hide the radial.
            m_SelectionRadial.Hide();

            m_GazeOver = false;

        }


        public void HandleSelectionComplete()
        {
            DoorOpened = true;
            Src.clip = _AudioDoor[0];
            Src.Play();

             m_GazeOver = false;
        }

    }


}