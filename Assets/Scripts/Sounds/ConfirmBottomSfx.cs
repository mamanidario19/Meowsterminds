using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmBottomSfx : MonoBehaviour
{
    public FMODUnity.EventReference MyEvent;


    public void PlayOneShot()
    {
        FMODUnity.RuntimeManager.PlayOneShotAttached(MyEvent.Guid, gameObject);
        // FMODUnity.RuntimeManager.PlayOneShotAttached(Event, gameObject);
    }


}
