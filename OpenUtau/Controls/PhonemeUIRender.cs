using Avalonia;
using Avalonia.Media.TextFormatting;
using OpenUtau.App.ViewModels;
using OpenUtau.Core;
using OpenUtau.Core.Ustx;
using OpenUtau.Core.Util;

namespace OpenUtau.App.Controls {
    static class PhonemeUIRender{
        public static string getLangCode(UVoicePart part){
            return "";
        }
        //Calculates the position of a phoneme alias on a piano roll view, 
        //considering factors like tick width, phoneme text, and text layout. 
        //It returns the x-coordinate and text y-coordinate of the alias
        public static (double textX, double textY, Size size, TextLayout textLayout) 
            AliasPosition(NotesViewModel viewModel, UPhoneme phoneme, string? langCode, ref double lastTextEndX, ref bool raiseText){

            string phonemeText = !string.IsNullOrEmpty(phoneme.phonemeMapped) ? phoneme.phonemeMapped : phoneme.phoneme;
            var x = viewModel.TickToneToPoint(phoneme.position, 0).X;
            var bold = phoneme.phoneme != phoneme.rawPhoneme;
            var textLayout = TextLayoutCache.Get(phonemeText, ThemeManager.ForegroundBrush!, 12, bold);
            if (x < lastTextEndX) {
                raiseText = !raiseText;
            } else {
                raiseText = false;
            }
            double textY = raiseText ? 2 : 18;
            var size = new Size(textLayout.Width + 4, textLayout.Height - 2);
            //var rect = new Rect(new Point(x - 2, textY + 1.5), size);
            /*if (rect.Contains(mousePos)) {
                result.phoneme = phoneme;
                result.hit = true;
                return result;
            }*/
            lastTextEndX = x + size.Width;
            return (x, textY, size, textLayout);
        }
    }
}
