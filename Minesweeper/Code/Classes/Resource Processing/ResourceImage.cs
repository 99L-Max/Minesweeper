using System;
using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper
{
    static class ResourceImage
    {
        public static List<Image> CutColumnIntoFrames(Image sprite, int framesCount, bool isDisposeSprite = true)
        {
            var frameHeight = sprite.Height / framesCount;
            var destRect = new Rectangle(0, 0, sprite.Width, frameHeight);
            var frames = new List<Image>(framesCount);

            for (int i = 0; i < framesCount; i++)
            {
                var frame = new Bitmap(sprite.Width, frameHeight);

                using (var g = Graphics.FromImage(frame))
                {
                    Rectangle srcRect = new Rectangle(0, i * frameHeight, sprite.Width, frameHeight);

                    g.DrawImage(sprite, destRect, srcRect, GraphicsUnit.Pixel);

                    frames.Add(frame);
                }
            }

            if (isDisposeSprite)
                sprite.Dispose();

            return frames;
        }

        public static Image CutImageFromColumn(Image sprite, int rowsCount, int row, byte alpha = byte.MaxValue, bool isDisposeSprite = true)
        {
            var height = sprite.Height / rowsCount;
            var resultSize = new Size(sprite.Width, height);

            var destRect = new Rectangle(new Point(), resultSize);
            var srcRect = new Rectangle(0, row * height, sprite.Width, height);

            var result = Painter.DrawImageAlpha(sprite, destRect, srcRect, alpha);

            if (isDisposeSprite)
                sprite.Dispose();

            return result;
        }

        public static Dictionary<T, Image> CutImagesByEnum<T>(Image sprite, bool isDisposeSprite = true)
        {
            var keys = EnumFactory.GetValues<T>();
            var images = CutColumnIntoFrames(sprite, keys.Length, isDisposeSprite);
            var dictionary = new Dictionary<T, Image>();

            for (int i = 0; i < keys.Length; i++)
                dictionary.Add(keys[i], images[i]);

            return dictionary;
        }

        public static Image CutImageByEnum<T>(Image sprite, T value, byte alpha = byte.MaxValue, bool isDisposeSprite = true)
        {
            return CutImageFromColumn(sprite, EnumFactory.GetCount<T>(), Convert.ToInt32(value), alpha, isDisposeSprite);
        }
    }
}
