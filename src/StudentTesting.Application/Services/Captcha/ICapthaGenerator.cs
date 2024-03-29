﻿using System.Windows.Media;

namespace StudentTesting.Application.Services.Captcha
{
    public interface ICapthaGenerator
    {
        public int WidhtImage { get; set; }
        public int HeightImage { get; set; }
        public ImageSource CapthaImage { get; }

        public bool CheckCaptcha(string captcha);
        public void NewCaptcha();
    }
}
