using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SimpleKeyboard
{
    /// <summary>
    /// Логика взаимодействия для SimpleKeyboardControl.xaml
    /// </summary>
    public partial class SimpleKeyboardControl : UserControl
    {
        public SimpleKeyboardControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the default state of the keyboard
        /// </summary>
        public void SetKeyboardState(KeyboardCurrentState state)
        {
            var viewmodel = (SimpleKeyboardViewModel)this.DataContext;
            viewmodel.CurrentState = state;
            viewmodel.PreviousState = state;
        }

        /// <summary>
        /// Gets or sets border thickness of the external keyoard shape
        /// </summary>
        public Thickness MainBorderThickness
        {
            get { return (Thickness)GetValue(MainBorderThicknessProperty); }
            set { SetValue(MainBorderThicknessProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MainBorder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainBorderThicknessProperty =
            DependencyProperty.Register("MainBorderThickness", typeof(Thickness), typeof(SimpleKeyboardControl), new PropertyMetadata(new Thickness(0)));

        /// <summary>
        /// Gets or sets the external border brush color
        /// </summary>
        public Brush MainBorderBrush
        {
            get { return (Brush)GetValue(MainBorderBrushProperty); }
            set { SetValue(MainBorderBrushProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MainBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainBorderBrushProperty =
            DependencyProperty.Register("MainBorderBrush", typeof(Brush), typeof(SimpleKeyboardControl), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Gets or sets the main background
        /// </summary>
        public Brush MainBackground
        {
            get { return (Brush)GetValue(MainBackgroundProperty); }
            set { SetValue(MainBackgroundProperty, value); }
        }
        // Using a DependencyProperty as the backing store for MainBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainBackgroundProperty =
            DependencyProperty.Register("MainBackground", typeof(Brush), typeof(SimpleKeyboardControl), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Gets or sets the border radius of all the keys on the keyboard
        /// </summary>
        public CornerRadius KeyCornerRadius
        {
            get { return (CornerRadius)GetValue(KeyCornerRadiusProperty); }
            set { SetValue(KeyCornerRadiusProperty, value); }
        }
        // Using a DependencyProperty as the backing store for KeyCornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyCornerRadiusProperty =
            DependencyProperty.Register("KeyCornerRadius", typeof(CornerRadius), typeof(SimpleKeyboardControl), new PropertyMetadata(new CornerRadius(0)));

        /// <summary>
        /// Gets or sets the height of each key
        /// </summary>
        public Double KeyHeight
        {
            get { return (Double)GetValue(KeyHeightProperty); }
            set { SetValue(KeyHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KeyHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyHeightProperty =
            DependencyProperty.Register("KeyHeight", typeof(Double), typeof(SimpleKeyboardControl), new PropertyMetadata(64.0));

        /// <summary>
        /// Gets or sets the width of each key
        /// </summary>
        public Double KeyWidth
        {
            get { return (Double)GetValue(KeyWidthProperty); }
            set { SetValue(KeyWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KeyHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyWidthProperty =
            DependencyProperty.Register("KeyWidth", typeof(Double), typeof(SimpleKeyboardControl), new PropertyMetadata(64.0));

        /// <summary>
        /// Gets or sets the brush for the border of each key
        /// </summary>
        public Brush KeyBorderBrush
        {
            get { return (Brush)GetValue(KeyBorderBrushProperty); }
            set { SetValue(KeyBorderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KeyBorderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyBorderBrushProperty =
            DependencyProperty.Register("KeyBorderBrush", typeof(Brush), typeof(SimpleKeyboardControl), new PropertyMetadata(Brushes.Gray));

        /// <summary>
        /// Gets or sets the space between keys
        /// </summary>
        public Thickness SpaceBetween
        {
            get { return (Thickness)GetValue(SpaceBetweenProperty); }
            set { SetValue(SpaceBetweenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SpaceBetween.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpaceBetweenProperty =
            DependencyProperty.Register("SpaceBetween", typeof(Thickness), typeof(SimpleKeyboardControl), new PropertyMetadata(new Thickness(0, 4, 4, 0)));

        /// <summary>
        /// Gets or sets the width of the backspace key
        /// </summary>
        public Double BackSpaceWidth
        {
            get { return (Double)GetValue(BackSpaceWidthProperty); }
            set { SetValue(BackSpaceWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackSpaceWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackSpaceWidthProperty =
            DependencyProperty.Register("BackSpaceWidth", typeof(Double), typeof(SimpleKeyboardControl), new PropertyMetadata(124.0));

        /// <summary>
        /// Gets or sets the width of the enter key
        /// </summary>
        public Double EnterWidth
        {
            get { return (Double)GetValue(EnterWidthProperty); }
            set { SetValue(EnterWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnterWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnterWidthProperty =
            DependencyProperty.Register("EnterWidth", typeof(Double), typeof(SimpleKeyboardControl), new PropertyMetadata(120.0));

        /// <summary>
        /// Gets or sets the width of the space key
        /// </summary>
        public Double SpaceWidth
        {
            get { return (Double)GetValue(SpaceWidthProperty); }
            set { SetValue(SpaceWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SpaceWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpaceWidthProperty =
            DependencyProperty.Register("SpaceWidth", typeof(Double), typeof(SimpleKeyboardControl), new PropertyMetadata(550.0));

        /// <summary>
        /// Gets or sets the background color of each key
        /// </summary>
        public Brush KeyBackground
        {
            get { return (Brush)GetValue(KeyBackgroundProperty); }
            set { SetValue(KeyBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for KeyBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty KeyBackgroundProperty =
            DependencyProperty.Register("KeyBackground", typeof(Brush), typeof(SimpleKeyboardControl), new PropertyMetadata(Brushes.Transparent));

        /// <summary>
        /// Gets or sets the width of the shift button
        /// </summary>
        public Double ShiftWidth
        {
            get { return (Double)GetValue(ShiftWidthProperty); }
            set { SetValue(ShiftWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShiftWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShiftWidthProperty =
            DependencyProperty.Register("ShiftWidth", typeof(Double), typeof(SimpleKeyboardControl), new PropertyMetadata(100.0));


    }
}
