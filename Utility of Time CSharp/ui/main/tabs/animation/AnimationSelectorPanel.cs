using System;
using System.Collections.Generic;
using System.Windows.Forms;

using UoT.animation.banks;
using UoT.limbs;
using UoT.util;

namespace UoT.ui.main.tabs.animation {
  public partial class AnimationSelectorPanel : UserControl, IAnimationBanks {
    // TODO: Add tests to make sure expected # of events are fired in expected places.

    private readonly AnimationReader animationReader_ = new AnimationReader();
    private IReadOnlyList<IAnimationBank>? animationBanks_;
    private IList<IAnimation>? animations_;
    private IList<Limb>? limbs_;

    public AnimationSelectorPanel() => this.InitializeComponent();

    public void Populate(IReadOnlyList<IAnimationBank> banks) {
      this.animationBanks_ = banks;

      this.bankComboBox_.Items.Clear();
      foreach (var bank in this.animationBanks_) {
        this.bankComboBox_.Items.Add(bank.Name);
      }
    }

    public void Reset(IList<Limb>? limbs) {
      this.limbs_ = limbs;

      if (limbs != null) {
        var initialIndex = this.bankComboBox_.SelectedIndex;
        this.bankComboBox_.SelectedIndex = 0;
        // If initial index was 0, then change wasn't detected. We need to 
        // manually reload.
        if (initialIndex == 0) {
          this.LoadBankAndSelectFirstAnimation_();
        }
      } else {
        this.bankComboBox_.SelectedIndex = -1;
        this.TriggerAnimationSelectedEvent_();
      }
    }

    public event Action<IAnimation?> AnimationSelected = delegate {};

    public bool ShowBones => this.showBonesCheckBox_.Checked;


    public IAnimationBank? SelectedAnimationBank {
      get {
        var selectedIndex = this.bankComboBox_.SelectedIndex;
        return selectedIndex == -1
                   ? null
                   : this.animationBanks_?[selectedIndex];
      }
    }

    private void bankComboBox__SelectedIndexChanged_(
        object sender,
        System.EventArgs e) => this.LoadBankAndSelectFirstAnimation_();

    private void LoadBankAndSelectFirstAnimation_() {
      this.animations_ = null;

      var limbCount = this.limbs_?.Count ?? 0;
      var selectedAnimationBank = this.SelectedAnimationBank;

      if (limbCount > 0 && selectedAnimationBank != null) {
        // Inline
        if (selectedAnimationBank.Bank == null) {
          this.animations_ =
              this.animationReader_.GetCommonAnimations(
                  RamBanks.ZFileBuffer,
                  limbCount,
                  this.animationsListBox_);
        } else {
          if (selectedAnimationBank.Name == "link_animetion") {
            this.animations_ = this.animationReader_.GetLinkAnimations(
                RamBanks.GameplayKeep,
                limbCount,
                selectedAnimationBank.Bank,
                this.animationsListBox_);
          } else {
            this.animations_ = this.animationReader_.GetCommonAnimations(
                selectedAnimationBank.Bank,
                limbCount,
                this.animationsListBox_);
          }
        }
      }

      if (this.animations_ != null) {
        Asserts.Assert(this.animations_.Count > 0);
        this.animationsListBox_.SelectedIndex = 0;
      } else {
        this.animationsListBox_.SelectedIndex = -1;
        this.TriggerAnimationSelectedEvent_();
      }
    }


    public IAnimation? SelectedAnimation {
      get {
        var selectedIndex = this.animationsListBox_.SelectedIndex;
        return selectedIndex == -1 ? null : this.animations_?[selectedIndex];
      }
    }

    private void animationsListBox__SelectedIndexChanged(
        object sender,
        EventArgs e) => this.TriggerAnimationSelectedEvent_();

    private void TriggerAnimationSelectedEvent_()
      => this.AnimationSelected.Invoke(this.SelectedAnimation);
  }
}