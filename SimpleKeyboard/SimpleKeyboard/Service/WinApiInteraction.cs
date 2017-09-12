using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;

namespace SimpleKeyboard.Service
{
    public class WinApiInteraction
    {
        public static void ChangeLanguage(KeyboardCurrentState state)
        {
            if (state == KeyboardCurrentState.eng)
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
            if (state == KeyboardCurrentState.rus)
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ru-RU"));
            else
                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("en-US"));
        }
        [StructLayout(LayoutKind.Explicit, Size = 28)]
        public struct Input
        {
            [FieldOffset(0)]
            public uint type;
            [FieldOffset(4)]
            public KeyboardInput ki;
        }

        public struct KeyboardInput
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public long time;
            public uint dwExtraInfo;
        }

        const int KEYEVENTF_KEYUP = 0x0002;
        const int INPUT_KEYBOARD = 1;

        [DllImport("user32.dll")]
        public static extern int SendInput(uint cInputs, ref Input inputs, int cbSize);

        [DllImport("user32.dll")]
        static extern short GetKeyState(int nVirtKey);

        [DllImport("user32.dll")]
        static extern ushort MapVirtualKey(int wCode, int wMapType);
        
        public static void HoldKey(Keys vk)
        {
            ushort nScan = MapVirtualKey((ushort)vk, 0);

            Input input = new Input();
            input.type = INPUT_KEYBOARD;
            input.ki.wVk = (ushort)vk;
            input.ki.wScan = nScan;
            input.ki.dwFlags = 0;
            input.ki.time = 0;
            input.ki.dwExtraInfo = 0;
            SendInput(1, ref input, Marshal.SizeOf(input)).ToString();
        }

        public static void ReleaseKey(Keys vk)
        {
            ushort nScan = MapVirtualKey((ushort)vk, 0);

            Input input = new Input();
            input.type = INPUT_KEYBOARD;
            input.ki.wVk = (ushort)vk;
            input.ki.wScan = nScan;
            input.ki.dwFlags = KEYEVENTF_KEYUP;
            input.ki.time = 0;
            input.ki.dwExtraInfo = 0;
            SendInput(1, ref input, Marshal.SizeOf(input));
        }
    }
}
