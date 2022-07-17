using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using MusicAppMobile.Models;
using Xamarin.Forms;

namespace MusicAppMobile.ViewModels
{
    public class LibraryMusicViewModel : BaseViewModel
    {
        public string SourceMedia { get; set; }
        private ItemSong _selectedAudio;
        public ObservableCollection<ItemSong> ListSounds { get; set; }
        public List<string> listPlayers { get; set; }

        public LibraryMusicViewModel()
        {
            NextCommand = new Command(NextCommandInvoke);
            PrevCommand = new Command(PrevCommandInvoke);
            SourceMedia = ListSounds[0].Url;
            ListSounds = new ObservableCollection<ItemSong>
            {
                new ItemSong(){Url = @"https://c1-ex-swe.nixcdn.com/NhacCuaTui2023/Tim-Orange-7584562.mp3?st=5xtgu0_BSRx1lMimZiXB6A&e=1658038656&t=1657952258181", NameMusic = "Tìm        ",Time = "03:50", Number ="1" },
                new ItemSong(){Url = @"https://c1-ex-swe.nixcdn.com/NhacCuaTui2023/LaMayTrenBauTroiCuaAiDo-ERIK-7588091.mp3", NameMusic = "Là Mây Trên Bầu Trời Của Ai Đó  ",Time = "05:22", Number ="2" },
                new ItemSong(){Url = @"https://vnno-vn-6-tf-mp3-s1-zmp3.zmdcdn.me/5c98a1be5affb3a1eaee/3249458650452441442?authen=exp=1658235441~acl=/5c98a1be5affb3a1eaee/*~hmac=3b4fa9c85c4ebc711337e42801876811&fs=MTY1ODA2MjY0MTA0OHx3ZWJWNnwwfDExNy4yLjI1LjY5", NameMusic = "Thiêu Thân          ",Time = "03:19", Number = "3" },
                new ItemSong(){Url = @"https://vnno-vn-6-tf-mp3-s1-zmp3.zmdcdn.me/364679e89fa976f72fb8/390350612642495996?authen=exp=1658235505~acl=/364679e89fa976f72fb8/*~hmac=74fa24eece2bf2748c405c5db898df20&fs=MTY1ODA2MjmUsICwNTA5Nnx3ZWJWNnwwfDEyMy4xOS40My4xOTE", NameMusic = "Chạy Khỏi Thế Giới Này",Time = "04:15", Number = "4" },

                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZCZCCED/320",
                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZDA60O8/320",
                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZ98CW7W/320",
                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZDI9B7U/320",
                  //@"http://api.mp3.zing.vn/api/streaming/audio/ZZDWA6AE/320",//Thieu Than
                  //@"C:\Users\nguye\Downloads\Music\n2.mp3",
                  //@"C:\Users\nguye\Downloads\Music\n3.mp3",
                  //@"C:\Users\nguye\Downloads\Music\n4.mp3",
            };
        }

        public ItemSong SelectedAudio
        {
            get { return _selectedAudio; }
            set
            {
                if (!ItemSong.Equals(_selectedAudio, value))
                {
                    _selectedAudio = value;
                    SourceMedia = value.Url;
                    OnPropertyChanged(nameof(SourceMedia));
                }
            }
        }

        public ICommand NextCommand { get; set; }
        public ICommand PrevCommand { get; set; }

        private void NextCommandInvoke(object sender)
        {
            var indexOfCurrenSource = ListSounds.Select(x => x.Url).ToList().IndexOf(SourceMedia);
            if (indexOfCurrenSource < ListSounds.Count - 1)
            {
                SourceMedia = ListSounds[indexOfCurrenSource + 1].Url;
                OnPropertyChanged(nameof(SourceMedia));
            }
            else
            {
                SourceMedia = ListSounds[0].Url;
            }
        }

        private void PrevCommandInvoke(object sender)
        {
            var indexOfCurrenSource = ListSounds.Select(x => x.Url).ToList().IndexOf(SourceMedia);
            if (indexOfCurrenSource == 0)
            {
                SourceMedia = ListSounds[ListSounds.Count - 1].Url;
                OnPropertyChanged(nameof(SourceMedia));
            }
            else
            {
                SourceMedia = ListSounds[indexOfCurrenSource - 1].Url;
                OnPropertyChanged(nameof(SourceMedia));
            }
        }
    }
}