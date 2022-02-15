using StudentTesting.Application.Commands.Sync;
using StudentTesting.Application.Services.Captcha;
using StudentTesting.Application.Utils;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace StudentTesting.Application.ViewModels
{
    public class CaptchaViewModel : OnPropertyChangeBase, IRequestCloseViewModel
    {
        public event EventHandler OnRequestClose;
        private ICapthaGenerator _capthaGenerator;

        public bool IsAccept { get; set; } = false;

        public CaptchaViewModel(ICapthaGenerator capthaGenerator = null)
        {
            _capthaGenerator = capthaGenerator ?? new CapthaGenerator();

            // TODO: Сделать нормальное указание размера, и убрать это захаркоденое говно.
            ImageSize = new Size(274, 68.08);

            CaptchaImage = _capthaGenerator.CapthaImage;

            NewCaptchaCommand = new RelayCommand(x => NewCaptcha());
            CheckCaptchaCommand = new RelayCommand(x => CheckCaptcha());
        }

        #region Property
        #region CaptchaImage
        private ImageSource _captchaImage;
        public ImageSource CaptchaImage
        {
            get => _captchaImage;
            set
            {
                _captchaImage = value;
                OnPropertyChange();
            }
        }
        #endregion

        #region Answer
        private string _answer;
        public string Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                OnPropertyChange();
            }
        }
        #endregion

        #region ImageSize
        private Size _renderSize;
        public Size ImageSize
        {
            get => _renderSize;
            set
            {
                _capthaGenerator.WidhtImage = (int)value.Width;
                _capthaGenerator.HeightImage = (int)value.Height;

                _renderSize = value;

                NewCaptcha();
                OnPropertyChange();
            }
        }
        #endregion
        #endregion

        #region Command
        public ICommand NewCaptchaCommand { get; }
        public ICommand CheckCaptchaCommand { get; }
        #endregion

        private void NewCaptcha()
        {
            Answer = "";
            _capthaGenerator.NewCaptcha();
            CaptchaImage = _capthaGenerator.CapthaImage;
        }

        private void CheckCaptcha()
        {
            if (_capthaGenerator.CheckCaptcha(Answer))
            {
                IsAccept = true;
                OnRequestClose?.Invoke(this, new EventArgs());
                return;
            }

            NewCaptcha();
        }
    }
}
