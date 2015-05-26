namespace System.Windows.Forms
{
    public static class ControlExtensions
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool LockWindowUpdate(IntPtr hWndLock);

        public static void Suspend(this Control control)
        {
            LockWindowUpdate(control.Handle);
        }

        public static void Resume(this Control control)
        {
            LockWindowUpdate(IntPtr.Zero);
        }

        public static void SetValue(this ProgressBar bar, int value)
        {
            // To get around this animation, we need to move the progress bar backwards.
            if (value == bar.Maximum)
            {
                // Special case (can't set value > Maximum).
                bar.Value = value;           // Set the value
                bar.Value = value - 1;       // Move it backwards
            }
            else
            {
                bar.Value = value + 1;       // Move past
            }
            bar.Value = value;               // Move to correct value
        }

    }
}