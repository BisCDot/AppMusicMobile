using MusicAppMobile.Models;
using MusicAppMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MusicAppMobile.ViewModels
{
    public class DiscorverViewModel : BaseViewModel
    {
        public DiscorverViewModel()
        {
            musicList = GetMusics();
            recentMusic = musicList.Where(x => x.IsRecent == true).FirstOrDefault();
        }

        private ObservableCollection<Music> musicList;

        public ObservableCollection<Music> MusicList
        {
            get { return musicList; }
            set
            {
                musicList = value;
                OnPropertyChanged();
            }
        }

        private Music recentMusic;

        public Music RecentMusic
        {
            get { return recentMusic; }
            set
            {
                recentMusic = value;
                OnPropertyChanged();
            }
        }

        private Music selectedMusic;

        public Music SelectedMusic
        {
            get { return selectedMusic; }
            set
            {
                selectedMusic = value;
                OnPropertyChanged();
            }
        }

        public ICommand SelectionCommand => new Command(PlayMusic);

        public ICommand BackPlayerCommand => new Command(() =>
                     {
                         var viewModel = new PlayerViewModel(selectedMusic);
                         var playerPage = new PlayerPage { BindingContext = viewModel };
                         Shell.Current.Navigation.PushAsync(playerPage, true);
                     });

        private void PlayMusic()
        {
            if (selectedMusic != null)
            {
                var viewModel = new PlayerViewModel(selectedMusic, musicList);
                var playerPage = new PlayerPage { BindingContext = viewModel };
                Shell.Current.Navigation.PushAsync(playerPage, true);
            }
        }

        private ObservableCollection<Music> GetMusics()
        {
            return new ObservableCollection<Music>
            {
                new Music { Title = "Vì Mẹ Anh Bắt Chia Tay", Artist = " Miu Lê, Karik,Châu Đăng Khoa", Url = @"https://c1-ex-swe.nixcdn.com/NhacCuaTui2022/ViMeAnhBatChiaTay-MiuLe-7503053.mp3?st=2R3Y0iqrOnscyfihtYOwxw&e=1657949612&t=1657863213765", CoverImage = "https://avatar-ex-swe.nixcdn.com/song/2022/06/14/9/6/4/c/1655187824693_500.jpg", IsRecent = true},
                new Music { Title = "Là Do Em Xui Thôi ", Artist = " Khói, Sofia, Châu Đăng Khoa", Url = @"https://c1-ex-swe.nixcdn.com/NhacCuaTui1025/LaDoEmXuiThoi-KhoiSofiaDanTrangChauDangKhoa-7125647.mp3", CoverImage = "https://avatar-ex-swe.nixcdn.com/song/2022/01/25/b/f/4/a/1643078471057_500.jpg"},
                new Music { Title = "Sau Lưng Anh Có Ai Kìa", Artist = "Thiều Bảo Trâm", Url = @"https://vnno-vn-6-tf-mp3-s1-zmp3.zmdcdn.me/6967661c225dcb03924c/4853633856808819522?authen=exp=1658234391~acl=/6967661c225dcb03924c/*~hmac=7921cec9920d4471c7edcb0c05d2185a&fs=MTY1ODA2MTU5MTI4N3x3ZWJWNnwxMDIzNjE0NTI5fDE0LjE2OS4yMjIdUngMTM5",CoverImage=@"https://photo-resize-zmp3.zmdcdn.me/w94_r1x1_webp/cover/1/8/0/7/1807c6b5fcc7058a14e1a288801221c7.jpg"},
                new Music { Title = "Thương Em Đến Già", Artist = "Lê Bảo Bình", Url = @"https://vnno-zn-5-tf-mp3-s1-zmp3.zmdcdn.me/f64307c67a8793d9ca96/182480450307363704?authen=exp=1658234926~acl=/f64307c67a8793d9ca96/*~hmac=e44e3cbd9e3d68355ba3534f1dd9d779&fs=MTY1ODA2MjEyNjI1M3x3ZWJWNnwwfDEyMy4yOC4yNDUdUngNDg",CoverImage=@"https://photo-resize-zmp3.zmdcdn.me/w240_r1x1_webp/cover/b/1/5/7/b1571618c3e6169aef31dc6cf75d09de.jpg"},
                new Music { Title = "hai mươi hai (22)", Artist = "Hứa Kim Tuyền & AMME", Url = @"https://vnno-vn-6-tf-mp3-s1-zmp3.zmdcdn.me/ca2d340d954c7c12255d/8465681852686731330?authen=exp=1658235029~acl=/ca2d340d954c7c12255d/*~hmac=85297cd45cf4872af8e5596fa5b3a160&fs=MTY1ODA2MjIyOTM3MHx3ZWJWNnwxMDIyMTmUsIC5NDAwfDExNi4xMDYdUngMjM4LjY1",CoverImage=@"https://photo-resize-zmp3.zmdcdn.me/w240_r1x1_webp/cover/b/6/d/e/b6de6c0857b19e1c921f2d379817d491.jpg"},
                new Music { Title = "Chạy Về Nơi Phía Anh", Artist = "Khắc Việt", Url = @"https://vnno-vn-6-tf-mp3-s1-zmp3.zmdcdn.me/30ebf1a99ce875b62cf9/1207873609872211285?authen=exp=1658234969~acl=/30ebf1a99ce875b62cf9/*~hmac=9b96ac6b6ae728890693b84ab19bf80e&fs=MTY1ODA2MjE2OTUyMHx3ZWJWNnwxMDM2Mjk2NDUwfDE3MS4yMzQdUngMjI0LjIwNw",CoverImage=@"https://photo-resize-zmp3.zmdcdn.me/w240_r1x1_webp/cover/6/3/0/d/630d20b0a79917e1545b4e2ada081040.jpg"}
            };
        }
    }
}