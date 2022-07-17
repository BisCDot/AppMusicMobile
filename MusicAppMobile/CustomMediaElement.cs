using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaManager;
using Xamarin.CommunityToolkit.UI.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicAppMobile
{
    public partial class CustomMediaElement : ContentView, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        

        public event EventHandler Clicked;

        public static readonly BindableProperty PlayCommandProperty =
            BindableProperty.Create("PlayCommand", typeof(ICommand), typeof(CustomMediaElement));

        public ICommand PlayCommand
        {
            get
            {
                return (ICommand)GetValue(PlayCommandProperty);
            }

            set
            {
                SetValue(PlayCommandProperty, value);
            }
        }

        public static readonly BindableProperty NextCommandProperty =
           BindableProperty.Create("NextCommand", typeof(ICommand), typeof(CustomMediaElement));

        public ICommand NextCommand
        {
            get
            {
                return (ICommand)GetValue(NextCommandProperty);
            }

            set
            {
                SetValue(NextCommandProperty, value);
            }
        }

        public static readonly BindableProperty PrevCommandProperty =
           BindableProperty.Create("PrevCommand", typeof(ICommand), typeof(CustomMediaElement));

        public ICommand PrevCommand
        {
            get
            {
                return (ICommand)GetValue(PrevCommandProperty);
            }

            set
            {
                SetValue(PrevCommandProperty, value);
            }
        }

        public static readonly BindableProperty SourceProperty =
           BindableProperty.Create("Source", typeof(string), typeof(CustomMediaElement));

        public string Source
        {
            get
            {
                return (string)GetValue(SourceProperty);
            }

            set
            {
                SetValue(SourceProperty, value);
                OnPropertyChanged();
            }
        }

        private bool isPlaying;

        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlayIcon));
            }
        }

        public string PlayIcon { get => isPlaying ? "pause2.png" : "play2.png"; }

        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var mediaInfo = CrossMediaManager.Current;
            var mediaElement = GetTemplateChild("PART_Media") as MediaElement;
            if (mediaInfo != null)
            {
                mediaInfo.MediaItemFinished += (sender, args) =>
                {
                    IsPlaying = true;

                    if (NextCommand != null && NextCommand.CanExecute(sender))
                    {
                        NextCommand.Execute(new { sender, args });
                    }
                    mediaInfo?.Play(Source);
                };
            }
            var playBtn = GetTemplateChild("PART_Play") as ImageButton;
            if (playBtn != null)
            {
                playBtn.Clicked += (sender, e) =>
                {
                    if (isPlaying)
                    {
                        mediaInfo?.Pause();
                        IsPlaying = false; ;
                    }
                    else
                    {
                        mediaInfo?.Play(Source);
                        IsPlaying = true; ;
                    }

                    if (PlayCommand != null && PlayCommand.CanExecute(sender))
                    {
                        PlayCommand.Execute(new { sender, e });
                    }
                };
            }

            var nextBtn = GetTemplateChild("PART_Next") as ImageButton;
            if (nextBtn != null)
            {
                nextBtn.Clicked += (sender, e) =>
                {
                    if (NextCommand != null && NextCommand.CanExecute(sender))
                    {
                        NextCommand.Execute(new { sender, e });
                    }
                    mediaInfo?.Play(Source);
                };
            }
            var prevBtn = GetTemplateChild("PART_Prev") as ImageButton;
            if (prevBtn != null)
            {
                prevBtn.Clicked += (sender, e) =>
                {
                    if (PrevCommand != null && PrevCommand.CanExecute(sender))
                    {
                        PrevCommand.Execute(new { sender, e });
                    }
                    mediaInfo?.Play(Source);
                };
            }
        }
    }
}