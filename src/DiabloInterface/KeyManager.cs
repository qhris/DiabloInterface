﻿using System.Collections.Generic;
using System.Windows.Forms;
using WindowsInput;

namespace DiabloInterface
{
    /// <summary>
    /// ugly with way too much hardcoding. but functional so far
    /// </summary>
    class KeyManager
    {
        
        public static string KeyEventArgsToKeyString(KeyEventArgs e)
        {
            //ok keys
            List<string> keys = new List<string>();

            if (e.Control)
            {
                keys.Add("Ctrl");
            }
            if (e.Shift)
            {
                keys.Add("Shift");
            }
            if (e.Alt)
            {
                keys.Add("Alt");
            }
            keys.Add(KeyManager.KeyToString(e.KeyCode));
            return string.Join("+", keys.ToArray());
        }

        public static string KeyToString(Keys key)
        {
            string c = "";
            if ((key >= Keys.A) && (key <= Keys.Z))
            {
                c = ((char)((int)'A' + (int)(key - Keys.A))).ToString();
            }

            else if ((key >= Keys.D0) && (key <= Keys.D9))
            {
                c = ((char)((int)'0' + (int)(key - Keys.D0))).ToString();
            }
            else if ((key >= Keys.F1) && (key <= Keys.F9))
            {
                c = "F" + ((char)((int)'1' + (int)(key - Keys.F1))).ToString();
            }
            else if (key == Keys.F10)
            {
                c = "F10";
            }
            else if (key == Keys.F11)
            {
                c = "F11";
            }

            else if (key == Keys.F12)
            {
                c = "F12";
            }
            else
            {
                c = key.ToString();
            }

            return c.ToString();
        }
        public static void sendKeys(string keys)
        {
            string[] keyArr = keys.Split('+');
            List<VirtualKeyCode> modifiers = new List<VirtualKeyCode>();
            VirtualKeyCode key = 0;
            
            foreach ( string k in keyArr )
            {
                string kLower = k.ToLower();
                if (kLower == "shift") { modifiers.Add(VirtualKeyCode.SHIFT); }
                else if (kLower == "ctrl") { modifiers.Add(VirtualKeyCode.CONTROL); }
                else if (kLower == "alt") { modifiers.Add(VirtualKeyCode.MENU); }
                else if (k.Length == 1) { key = (VirtualKeyCode)(int)k[0]; }
                else if (kLower == "f1") { key = VirtualKeyCode.F1; }
                else if (kLower == "f2") { key = VirtualKeyCode.F2; }
                else if (kLower == "f3") { key = VirtualKeyCode.F3; }
                else if (kLower == "f4") { key = VirtualKeyCode.F4; }
                else if (kLower == "f5") { key = VirtualKeyCode.F5; }
                else if (kLower == "f6") { key = VirtualKeyCode.F6; }
                else if (kLower == "f7") { key = VirtualKeyCode.F7; }
                else if (kLower == "f8") { key = VirtualKeyCode.F8; }
                else if (kLower == "f9") { key = VirtualKeyCode.F9; }
                else if (kLower == "f10") { key = VirtualKeyCode.F10; }
                else if (kLower == "f11") { key = VirtualKeyCode.F11; }
                else if (kLower == "f12") { key = VirtualKeyCode.F12; }
            }

            if (key == 0)
            {
                return;
            }
            InputSimulator.SimulateModifiedKeyStroke(modifiers.ToArray(), key);
           
        }
    }
}
