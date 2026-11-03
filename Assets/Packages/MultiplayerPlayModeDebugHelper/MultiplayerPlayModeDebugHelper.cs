#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Multiplayer.PlayMode {
[DefaultExecutionOrder(-10000)]
public class MultiplayerPlayModeDebugHelper : MonoBehaviour
{
    [field:SerializeField] public UnityEvent OnMainEditorStarted    { get; private set; }
    [field:SerializeField] public UnityEvent OnVirtualPlayerStarted { get; private set; }

    public static bool IsMainEditor => CurrentPlayer.IsMainEditor;

    private void Awake()
    {
        if (IsMainEditor)
        {
            Debug.Log($"{nameof(MultiplayerPlayModeDebugHelper)} ({name}) : Started as a main editor.");
            OnMainEditorStarted?.Invoke();
        }
        else
        {
            Debug.Log($"{nameof(MultiplayerPlayModeDebugHelper)} ({name}) : Started as a virtual player.");
            OnVirtualPlayerStarted?.Invoke();
        }
    }
}}
#endif