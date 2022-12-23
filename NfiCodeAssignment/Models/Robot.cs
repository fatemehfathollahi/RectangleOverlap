namespace NfiCodeAssignment.Models
{
    public class Robot
    {
        /// <summary>
        /// left coordinate of rectangle
        /// </summary>
        public readonly int Left;
        /// <summary>
        /// Right coordinate of rectangle
        /// </summary>
        public readonly int Right;
        /// <summary>
        /// Top coordinate of rectangle
        /// </summary>
        public readonly int Top;
        /// <summary>
        /// Bottom coordinate of rectangle
        /// </summary>
        public readonly int Bottom;
        public Robot(int top, int left, int bottom, int right)
        {
            this.Top = top;
            this.Left = left;
            this.Bottom = bottom;
            this.Right = right;
        }
    }
}
