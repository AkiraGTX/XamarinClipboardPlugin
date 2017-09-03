using Plugin.Clipboard.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;

namespace Plugin.Clipboard
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class ClipboardImplementation : IClipboard
    {
        public async Task<string> GetText()
        {
            DataPackageView dataPackageView = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
            if (dataPackageView.Contains(StandardDataFormats.Text))
            {
                string text = await dataPackageView.GetTextAsync();
                return text;
            }
            return "";
        }

        public void SetText(string data)
        {
            var dataPackage = new DataPackage();
            dataPackage.SetText(data);
            Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
        }

       
    }
}