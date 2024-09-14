using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{

    #region Editor Settings

    [Tooltip("Material to switch to during the flash.")]
    [SerializeField] protected Material _normalFlashMaterial;



    [Tooltip("Duration of the flash.")]
    public float FlashDuration;

    #endregion

    #region Private Fields

    // The SpriteRenderer that should flash.
    [SerializeField] protected SpriteRenderer _spriteRenderer;

    // The material that was in use, when the script started.
    [SerializeField] protected Material _originalMaterial;

    // The currently running coroutine.
    protected Coroutine _flashRoutine;

    #endregion

    public void NormalFlash()
    {
        // If the flashRoutine is not null, then it is currently running.
        if (_flashRoutine != null)
        {
            // In this case, we should stop it first.
            // Multiple FlashRoutines the same time would cause bugs.
            StopCoroutine(_flashRoutine);
        }

        // Start the Coroutine, and store the reference for it.

        _flashRoutine = StartCoroutine(FlashRoutine());


    }
    private IEnumerator FlashRoutine()
    {

        // Swap to the flashMaterial.
        _spriteRenderer.material = _normalFlashMaterial;

        // Pause the execution of this function for "duration" seconds.
        yield return new WaitForSeconds(FlashDuration);

        // After the pause, swap back to the original material.
        _spriteRenderer.material = _originalMaterial;
        //Debug.Log("Original material");
        // Set the routine to null, signaling that it's finished.
        _flashRoutine = null;


    }
}
