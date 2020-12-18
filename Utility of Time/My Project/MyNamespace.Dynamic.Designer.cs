using System;
using System.ComponentModel;
using System.Diagnostics;

namespace UoT.My {
  internal static partial class MyProject {
    internal partial class MyForms {
      [EditorBrowsable(EditorBrowsableState.Never)]
      public AboutBoxDialog m_AboutBoxDialog;

      public AboutBoxDialog AboutBoxDialog {
        [DebuggerHidden]
        get {
          m_AboutBoxDialog = Create__Instance__(m_AboutBoxDialog);
          return m_AboutBoxDialog;
        }

        [DebuggerHidden]
        set {
          if (ReferenceEquals(value, m_AboutBoxDialog))
            return;
          if (value is object)
            throw new ArgumentException("Property can only be set to Nothing");
          Dispose__Instance__(ref m_AboutBoxDialog);
        }
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public ActorPresets m_ActorPresets;

      public ActorPresets ActorPresets {
        [DebuggerHidden]
        get {
          m_ActorPresets = Create__Instance__(m_ActorPresets);
          return m_ActorPresets;
        }

        [DebuggerHidden]
        set {
          if (ReferenceEquals(value, m_ActorPresets))
            return;
          if (value is object)
            throw new ArgumentException("Property can only be set to Nothing");
          Dispose__Instance__(ref m_ActorPresets);
        }
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public BankSetup m_BankSetup;

      public BankSetup BankSetup {
        [DebuggerHidden]
        get {
          m_BankSetup = Create__Instance__(m_BankSetup);
          return m_BankSetup;
        }

        [DebuggerHidden]
        set {
          if (ReferenceEquals(value, m_BankSetup))
            return;
          if (value is object)
            throw new ArgumentException("Property can only be set to Nothing");
          Dispose__Instance__(ref m_BankSetup);
        }
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public CombinerEditor m_CombinerEditor;

      public CombinerEditor CombinerEditor {
        [DebuggerHidden]
        get {
          m_CombinerEditor = Create__Instance__(m_CombinerEditor);
          return m_CombinerEditor;
        }

        [DebuggerHidden]
        set {
          if (ReferenceEquals(value, m_CombinerEditor))
            return;
          if (value is object)
            throw new ArgumentException("Property can only be set to Nothing");
          Dispose__Instance__(ref m_CombinerEditor);
        }
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public HexEditor m_HexEditor;

      public HexEditor HexEditor {
        [DebuggerHidden]
        get {
          m_HexEditor = Create__Instance__(m_HexEditor);
          return m_HexEditor;
        }

        [DebuggerHidden]
        set {
          if (ReferenceEquals(value, m_HexEditor))
            return;
          if (value is object)
            throw new ArgumentException("Property can only be set to Nothing");
          Dispose__Instance__(ref m_HexEditor);
        }
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public LevelCreator m_LevelCreator;

      public LevelCreator LevelCreator {
        [DebuggerHidden]
        get {
          m_LevelCreator = Create__Instance__(m_LevelCreator);
          return m_LevelCreator;
        }

        [DebuggerHidden]
        set {
          if (ReferenceEquals(value, m_LevelCreator))
            return;
          if (value is object)
            throw new ArgumentException("Property can only be set to Nothing");
          Dispose__Instance__(ref m_LevelCreator);
        }
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public MainWin m_MainWin;

      public MainWin MainWin {
        [DebuggerHidden]
        get {
          m_MainWin = Create__Instance__(m_MainWin);
          return m_MainWin;
        }

        [DebuggerHidden]
        set {
          if (ReferenceEquals(value, m_MainWin))
            return;
          if (value is object)
            throw new ArgumentException("Property can only be set to Nothing");
          Dispose__Instance__(ref m_MainWin);
        }
      }

      [EditorBrowsable(EditorBrowsableState.Never)]
      public SetupDialog m_SetupDialog;

      public SetupDialog SetupDialog {
        [DebuggerHidden]
        get {
          m_SetupDialog = Create__Instance__(m_SetupDialog);
          return m_SetupDialog;
        }

        [DebuggerHidden]
        set {
          if (ReferenceEquals(value, m_SetupDialog))
            return;
          if (value is object)
            throw new ArgumentException("Property can only be set to Nothing");
          Dispose__Instance__(ref m_SetupDialog);
        }
      }
    }
  }
}