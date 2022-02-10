using StudentTesting.Application.Utils;
using System;
using System.Drawing;
using System.Linq;

namespace StudentTesting.Application.Services.Captcha
{
    public class CapthaGenerator : ICapthaGenerator
    {
        private IStringGenerator _stringGenerator;
        private Font _font;
        private Random _rnd;

        public int WidhtImage { get; set; }
        public int HeightImage { get; set; }
        public System.Windows.Media.ImageSource CapthaImage { get; private set; }

        public CapthaGenerator(IStringGenerator stringGenerator = null, Font font = null)
        {
            _stringGenerator = stringGenerator ?? new RandomStringGenerator();
            _font = font ?? new Font("Comic Sans MS", 24);
            
            _rnd = new Random();
        }

        public bool CheckCaptcha(string captcha)
        {
            return _stringGenerator.String.ToLower() == captcha.ToLower();
        }

        private void GenerateCaptcha()
        {
            var brushText = new SolidBrush(Color.Red);
            var penLine = new Pen(Color.Blue, 2);

            var bitmap = new Bitmap(WidhtImage, HeightImage);
            string captcha = _stringGenerator.String;

            using var graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);

            string[] captchaMass = ConvertType.ConvertStringToMassiveString(captcha);

            float wightString = captchaMass
                .Select(x => graphics.MeasureString(x, _font).Width)
                .Sum();

            float marginSymvol = (WidhtImage - wightString) / (captcha.Length - 1);

            float currentX = 0;
            foreach (var symvol in captchaMass)
            {
                SizeF symvolSize = graphics.MeasureString(symvol, _font);
                Point coordSymvol = new Point
                {
                    X = (int)currentX,
                    Y = _rnd.Next(0, (int)(HeightImage - symvolSize.Height)) // TODO: Если высота изображения будет меньше размера символа, то произойдет пиздец. Нужно добавть проверку, ну или еще какую-нибудь хкрню.
                };

                graphics.DrawString(symvol, _font, brushText, coordSymvol);
                currentX += symvolSize.Width + marginSymvol;
            }

            graphics.DrawLine(penLine, 0, 0, WidhtImage, HeightImage);
            graphics.DrawLine(penLine, WidhtImage, 0, 0, HeightImage);

            CapthaImage = ConvertType.ConvertBitmapToImageSource(bitmap);
        }

        public void NewCaptcha()
        {
            _stringGenerator.GenerateString();
            GenerateCaptcha();
        }
    }
}
