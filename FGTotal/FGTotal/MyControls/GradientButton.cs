using MagicGradients;
using System.Collections.Generic;
using NControl.Abstractions;
using System.Windows.Input;
using Xamarin.Forms;

namespace FGTotal.MyControls
{
    public class GradientButton : NControlView
    {
        private Frame _frame;
        private Label _label;
        private GradientView _gradientView;

        public float BorderRadius
        {
            get => (float)GetValue(BorderRadiusProperty);
            set
            {
                SetValue(BorderRadiusProperty, value);
                Invalidate();
            }
        }
        static float initialRadius = 15;

        public static BindableProperty BorderRadiusProperty =
            BindableProperty.Create(nameof(BorderRadius),
                typeof(float),
                typeof(GradientButton),
                initialRadius,
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.BorderRadius = (float)n;
                });


        public string Text
        {
            get => (string)GetValue(TextProperty);
            set
            {
                SetValue(TextProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text),
                typeof(string),
                typeof(GradientButton),
                "",
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.Text = (string)n;
                });

        public string GradientStyle
        {
            get => (string)GetValue(GradientStyleProperty);
            set
            {
                SetValue(GradientStyleProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty GradientStyleProperty =
            BindableProperty.Create(nameof(GradientStyle),
                typeof(string),
                typeof(GradientButton),
                "background-image: radial-gradient(circle at center center, rgb(233, 255, 32),rgb(176, 209, 39),rgb(118, 163, 47),rgb(61, 116, 54),rgb(3, 70, 61))",
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.GradientStyle = (string)n;
                });


        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set
            {
                SetValue(CommandProperty, value);
                Invalidate();
            }
        }

        public static BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command),
                typeof(ICommand),
                typeof(GradientButton),
                defaultBindingMode: BindingMode.TwoWay,
                propertyChanged: (b, o, n) =>
                {
                    var control = (GradientButton)b;
                    control.Command = (ICommand)n;
                });


        public GradientButton()
        {
            _label = new Label
            {
                Text = "Regresar",
                TextColor = Xamarin.Forms.Color.White,
                VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center
            };

            _gradientView = new GradientView
            {
                GradientSource = new CssGradientSource
                {
                    Stylesheet = "radial-gradient(circle at left center, rgb(157, 191, 59),rgb(98, 190, 121))"
                }
            };


            _frame = new Frame
            {
                Content = new Grid
                {
                    Children =
                    {
                        _gradientView,
                        _label
                    }
                },
                Padding = 0,
                CornerRadius = 38f
            };

            Content = _frame;
        }

        public override bool TouchesBegan(IEnumerable<NGraphics.Point> points)
        {
            this.ScaleTo(0.96, 65, Easing.CubicInOut);
            return true;
        }

        public override bool TouchesCancelled(IEnumerable<NGraphics.Point> points)
        {
            this.ScaleTo(1, 65, Easing.CubicInOut);
            return true;
        }

        public override bool TouchesEnded(IEnumerable<NGraphics.Point> points)
        {
            this.ScaleTo(1, 65, Easing.CubicInOut);

            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }

            return true;
        }

        //public override void Draw(ICanvas canvas, Rect rect)
        //{
        //    //canvas.DrawLine(rect.Left, rect.Top, rect.Width, rect.Height,
        //    //    NGraphics.Colors.Red);
        //    //canvas.DrawLine(rect.Width, rect.Top, rect.Left, rect.Height,
        //    //    NGraphics.Colors.Green);
        //    _frame.CornerRadius = BorderRadius;
        //    _label.Text = Text;

        //    _gradientView.GradientSource =
        //        new CssGradientSource
        //        {
        //            Stylesheet = this.GradientStyle
        //        };
        //}
    }
}