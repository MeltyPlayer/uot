using System;
using System.Windows.Forms;

namespace UoT {
  public partial class AnimationPlaybackPanel : UserControl, IAnimationPlaybackManager {
    // TODO: Add tests.

    private readonly IAnimationPlaybackManager impl_ = new FrameAdvancer();

    public AnimationPlaybackPanel() {
      this.InitializeComponent();

      this.PlayButton.Click += (object sender, EventArgs e) => {
        this.IsPlaying = true;
      };
      this.StopButton.Click += (object sender, EventArgs e) => {
        this.IsPlaying = false;
      };
      this.LoopCheckBox.Click += (object sender, EventArgs e) => {
        this.ShouldLoop = this.LoopCheckBox.Checked;
      };
      this.FrameTrackBar.Scroll += (object sender, EventArgs e) => {
        this.Frame = this.FrameTrackBar.Value;
      };
      this.FrameRateSelector.ValueChanged += (object sender, EventArgs e) => {
        var newFrameRate = (int)Math.Floor(this.FrameRateSelector.Value);
        if (this.FrameRate != newFrameRate) {
          this.FrameRate = newFrameRate;
        }
      };

      this.FrameRate = (int) Math.Floor(this.FrameRateSelector.Value);
    }

    // TODO: Should carry over changes to form.
    public double Frame {
      get => this.impl_.Frame;
      set {
        this.impl_.Frame = value;

        if (this.TotalFrames > 0) {
          this.FrameTrackBar.Value = (int)value;
        }
      } 
    }
    public int TotalFrames {
      get => this.impl_.TotalFrames;
      set {
        this.impl_.TotalFrames = value;
        this.FrameTrackBar.Maximum = value;
      }
    }

    public int FrameRate {
      get => this.impl_.FrameRate;
      set {
        this.impl_.FrameRate = value;
        this.FrameRateSelector.Value = value;
      }
    }


    public bool IsPlaying {
      get => this.impl_.IsPlaying;
      set => this.impl_.IsPlaying = value;
    }
    public bool ShouldLoop {
      get => this.impl_.ShouldLoop;
      set {
        this.impl_.ShouldLoop = value;
        this.LoopCheckBox.Checked = value;
      }
    }


    public void Reset() => this.impl_.Reset();

    public void Tick() {
      this.impl_.Tick();
      this.Update_();
    }

    private void Update_() {
      string animationElapseText = "0:0s";
      string frameNoText = "0/0";

      // TODO: What's with all these extra checks?
      if (this.TotalFrames > 0) {
        var frame = this.Frame;
        var frameIndex = (int)Math.Floor(frame);

        this.FrameTrackBar.Value = frameIndex;

        var seconds = frame / this.FrameRate;
        var secondsInt = (int)Math.Max(0, seconds);
        var secondsDelta = (int)(seconds * 1000 % 1000);

        animationElapseText = secondsInt +
                              ":" +
                              secondsDelta +
                              "s";
        frameNoText = frameIndex + "/" + this.TotalFrames;
      }

      this.AnimationElapse.Text = animationElapseText;
      this.FrameNo.Text = frameNoText;
    }
  }
}
