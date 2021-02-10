using System;
using System.Collections.Generic;

namespace UoT.animation.banks {
  public interface IAnimationBanks {
    void Reset(IList<Limb>? limbs);

    IAnimation? SelectedAnimation { get; }
    event Action<IAnimation?> AnimationSelected;

    bool ShowBones { get; }
  }
}
