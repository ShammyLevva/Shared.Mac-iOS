using System;
using Foundation;

#if __MACOS__
using AppKit;
#elif __IOS__
using UIKit;
#endif

namespace FTAnalyzer.Properties
{
    [Register ("FileHandling")]
#if __MACOS__
    public class FileHandling : NSViewController
#elif __IOS__
    public class FileHandling : UIViewController
#endif
    {
        public FileHandling(IntPtr handle) : base(handle) { }

        public static FileHandling Default { get; } = (FileHandling)SettingsBase.Load(new FileHandling(new IntPtr()), typeof(FileHandling));

        [DefaultSettingValue("False")]
        public bool LoadWithFilters { get; set; }

        [DefaultSettingValue("True")]
        public bool RetryFailedLines { get; set; }

        [DefaultSettingValue("True")]
        public bool ConvertDiacritics { get; set; }

        public void Save() => SettingsBase.Save(Default, typeof(FileHandling));
    }
}
