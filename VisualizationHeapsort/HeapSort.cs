using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualizationHeapsort
{
    static class HeapSort
    {
        public static event Action<List<Line>, Bitmap> Draw;
        public static void Sort(List<Line> lines, int count, Bitmap bmp)
        {
            int temp = lines[0].Angle;
            lines[0].Angle = lines[count].Angle;
            lines[count].Angle = temp;
            Heapsort(lines, count, 0);
            Draw(lines, bmp);
        }

        public static void Heapsort(List<Line> arr, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && arr[left].Angle > arr[largest].Angle)
                largest = left;
            if (right < n && arr[right].Angle > arr[largest].Angle)
                largest = right;
            if (largest != i)
            {
                int swap = arr[i].Angle;
                arr[i].Angle = arr[largest].Angle;
                arr[largest].Angle = swap;
                Heapsort(arr, n, largest);
            }
        }
    }
}
