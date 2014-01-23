using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Gst
{
    public static class Win32
    {
        public const int StdOutputHandle = -11;
        public const int StdInputHandle = -10;

        public const int StdErrorHandle = -12;

        [DllImport("Kernel32.dll")]
        public static extern IntPtr CreateConsoleScreenBuffer(
             UInt32 dwDesiredAccess,
             UInt32 dwShareMode,
             IntPtr secutiryAttributes,
             UInt32 flags,
             [MarshalAs(UnmanagedType.U4)] UInt32 screenBufferData
             );

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        public static extern bool SetConsoleActiveScreenBuffer(IntPtr hConsoleOutput);

        [DllImport("kernel32.dll", BestFitMapping = false, ThrowOnUnmappableChar = true)]
        public static extern int OpenFile([MarshalAs(UnmanagedType.LPStr)]string lpFileName, out Ofstruct lpReOpenBuff,
           OpenFileStyle uStyle);

        [StructLayout(LayoutKind.Sequential)]
        public struct Ofstruct
        {
            public byte cBytes;
            public byte fFixedDisc;
            public UInt16 nErrCode;
            public UInt16 Reserved1;
            public UInt16 Reserved2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szPathName;
        }

        [Flags]
        public enum OpenFileStyle : uint
        {
            Cancel = 0x00000800,  // Ignored. For a dialog box with a Cancel button, use OF_PROMPT.
            Create = 0x00001000,  // Creates a new file. If file exists, it is truncated to zero (0) length.
            Delete = 0x00000200,  // Deletes a file.
            Exist = 0x00004000,  // Opens a file and then closes it. Used to test that a file exists
            Parse = 0x00000100,  // Fills the OFSTRUCT structure, but does not do anything else.
            Prompt = 0x00002000,  // Displays a dialog box if a requested file does not exist 
            Read = 0x00000000,  // Opens a file for reading only.
            Readwrite = 0x00000002,  // Opens a file with read/write permissions.
            Reopen = 0x00008000,  // Opens a file by using information in the reopen buffer.

            // For MS-DOS–based file systems, opens a file with compatibility mode, allows any process on a 
            // specified computer to open the file any number of times.
            // Other efforts to open a file with other sharing modes fail. This flag is mapped to the 
            // FILE_SHARE_READ|FILE_SHARE_WRITE flags of the CreateFile function.
            ShareCompat = 0x00000000,

            // Opens a file without denying read or write access to other processes.
            // On MS-DOS-based file systems, if the file has been opened in compatibility mode
            // by any other process, the function fails.
            // This flag is mapped to the FILE_SHARE_READ|FILE_SHARE_WRITE flags of the CreateFile function.
            ShareDenyNone = 0x00000040,

            // Opens a file and denies read access to other processes.
            // On MS-DOS-based file systems, if the file has been opened in compatibility mode,
            // or for read access by any other process, the function fails.
            // This flag is mapped to the FILE_SHARE_WRITE flag of the CreateFile function.
            ShareDenyRead = 0x00000030,

            // Opens a file and denies write access to other processes.
            // On MS-DOS-based file systems, if a file has been opened in compatibility mode,
            // or for write access by any other process, the function fails.
            // This flag is mapped to the FILE_SHARE_READ flag of the CreateFile function.
            ShareDenyWrite = 0x00000020,

            // Opens a file with exclusive mode, and denies both read/write access to other processes.
            // If a file has been opened in any other mode for read/write access, even by the current process,
            // the function fails.
            ShareExclusive = 0x00000010,

            // Verifies that the date and time of a file are the same as when it was opened previously.
            // This is useful as an extra check for read-only files.
            Verify = 0x00000400,

            // Opens a file for write access only.
            Write = 0x00000001
        }
    }
}
