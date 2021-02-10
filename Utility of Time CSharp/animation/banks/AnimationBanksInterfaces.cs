using System;
using System.Collections.Generic;

using UoT.limbs;

namespace UoT.animation.banks {
  public interface IAnimationBanks {
    void Populate(IReadOnlyList<IAnimationBank> banks);
    void Reset(IList<Limb>? limbs);

    IAnimation? SelectedAnimation { get; }
    event Action<IAnimation?> AnimationSelected;

    bool ShowBones { get; }
  }
}
